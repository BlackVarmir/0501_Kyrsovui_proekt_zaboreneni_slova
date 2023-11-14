using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _0501_курсовий_проект__заборонені_слова
{
    public partial class Form1 : Form
    {
        private CancellationTokenSource cancellationTokenSource;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void BrowseButton_Click(object sender, EventArgs e)
        {
            string inputFolderPath = "InputFiles";
            if (!Directory.Exists(inputFolderPath))
            {
                Directory.CreateDirectory(inputFolderPath);
            }
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Text Files|*.txt|All Files|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Завантажити заборонені слова з файлу
                    LoadForbiddenWords(openFileDialog.FileName);
                }
            }
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            // Очистити попередні результати
            ClearResults();

            // Створити папку для збереження результатів
            string outputPath = "Results";
            if (!Directory.Exists(outputPath))
            {
                Directory.CreateDirectory(outputPath);
            }

            // Запустити в пошуку
            cancellationTokenSource = new CancellationTokenSource();
            Task.Run(() => SearchFilesForForbiddenWords(outputPath, cancellationTokenSource.Token));
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            // Припинити пошук
            cancellationTokenSource?.Cancel();
        }

        private void LoadForbiddenWords(string filePath)
        {
            // Завантажити заборонені слова з файлу
            // Очистити попередні слова
            ForbiddenWordsListBox.Items.Clear();

            // Додати нові слова
            string[] words = File.ReadAllLines(filePath);
            ForbiddenWordsListBox.Items.AddRange(words);
        }

        private void ClearResults()
        {
            // Очистити результати
            ResultsListBox.Items.Clear();
        }

        private void SearchFilesForForbiddenWords(string outputPath, CancellationToken cancellationToken)
        {
            string[] forbiddenWords = ForbiddenWordsListBox.Items.OfType<string>().ToArray();

            // Отримати список файлів у папці
            string inputFolderPath = "InputFiles";
            if (!Directory.Exists(inputFolderPath))
            {
                MessageBox.Show("Папка з файлами не знайдена.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string[] files = Directory.GetFiles(inputFolderPath, "*.*", SearchOption.AllDirectories);

            // Ініціалізувати прогрес-бар
            Invoke((Action)delegate { ProgressBar.Maximum = files.Length; });

            foreach (string file in files)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    // Припинити пошук, якщо користувач вибрав "Стоп"
                    Invoke((Action)delegate { ProgressBar.Value = 0; });
                    return;
                }

                // Читати вміст файлу
                string fileContent = File.ReadAllText(file);

                // Перевірка наявності заборонених слів
                if (ContainsForbiddenWords(fileContent, forbiddenWords))
                {
                    // Створити копію файлу із заміною заборонених слів
                    string outputFilePath = Path.Combine(outputPath, Path.GetFileName(file));
                    string replacedContent = ReplaceForbiddenWords(fileContent, forbiddenWords);
                    File.WriteAllText(outputFilePath, replacedContent);

                    // Додати інформацію про файл у звіт
                    string reportEntry = $"{outputFilePath}\t{new FileInfo(file).Length} bytes";
                    Invoke((Action)delegate { ResultsListBox.Items.Add(reportEntry); });
                }

                // Збільшити значення прогрес-бару
                int currentValue = ProgressBar.Value;
                int maximumValue = ProgressBar.Maximum;

                if (currentValue + 1 <= maximumValue)
                {
                    Invoke((Action)delegate { ProgressBar.Value += 1; });
                }
            }
        }

        private bool ContainsForbiddenWords(string content, string[] forbiddenWords)
        {
            // Перевірити, чи містить вміст хоча б одне заборонене слово
            return forbiddenWords.Any(word => content.Contains(word, StringComparison.OrdinalIgnoreCase));
        }

        private string ReplaceForbiddenWords(string content, string[] forbiddenWords)
        {
            foreach (string word in forbiddenWords)
            {
                // Перевірити, чи слово не є порожнім рядком
                if (!string.IsNullOrEmpty(word))
                {
                    // Екранувати метасимволи регулярних виразів у слові
                    string escapedWord = Regex.Escape(word);

                    // Замінити слово у вмісті
                    content = Regex.Replace(content, escapedWord, "*******", RegexOptions.IgnoreCase);
                }
            }
            return content;
        }
    }
}