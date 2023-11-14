namespace _0501_курсовий_проект__заборонені_слова
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            StartButton = new Button();
            BrowseButton = new Button();
            StopButton = new Button();
            ResultsListBox = new ListBox();
            ForbiddenWordsListBox = new ListBox();
            ProgressBar = new ProgressBar();
            SuspendLayout();
            // 
            // StartButton
            // 
            StartButton.Location = new Point(288, 140);
            StartButton.Name = "StartButton";
            StartButton.Size = new Size(84, 23);
            StartButton.TabIndex = 0;
            StartButton.Text = "Start";
            StartButton.UseVisualStyleBackColor = true;
            StartButton.Click += StartButton_Click;
            // 
            // BrowseButton
            // 
            BrowseButton.Location = new Point(288, 187);
            BrowseButton.Name = "BrowseButton";
            BrowseButton.Size = new Size(84, 23);
            BrowseButton.TabIndex = 1;
            BrowseButton.Text = "Browse";
            BrowseButton.UseVisualStyleBackColor = true;
            BrowseButton.Click += BrowseButton_Click;
            // 
            // StopButton
            // 
            StopButton.Location = new Point(288, 229);
            StopButton.Name = "StopButton";
            StopButton.Size = new Size(84, 23);
            StopButton.TabIndex = 2;
            StopButton.Text = "Stop";
            StopButton.UseVisualStyleBackColor = true;
            StopButton.Click += StopButton_Click;
            // 
            // ResultsListBox
            // 
            ResultsListBox.FormattingEnabled = true;
            ResultsListBox.ItemHeight = 15;
            ResultsListBox.Location = new Point(12, 12);
            ResultsListBox.Name = "ResultsListBox";
            ResultsListBox.Size = new Size(270, 424);
            ResultsListBox.TabIndex = 3;
            // 
            // ForbiddenWordsListBox
            // 
            ForbiddenWordsListBox.FormattingEnabled = true;
            ForbiddenWordsListBox.ItemHeight = 15;
            ForbiddenWordsListBox.Location = new Point(378, 14);
            ForbiddenWordsListBox.Name = "ForbiddenWordsListBox";
            ForbiddenWordsListBox.Size = new Size(270, 424);
            ForbiddenWordsListBox.TabIndex = 4;
            // 
            // ProgressBar
            // 
            ProgressBar.Location = new Point(12, 454);
            ProgressBar.Name = "ProgressBar";
            ProgressBar.Size = new Size(636, 23);
            ProgressBar.TabIndex = 5;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(660, 489);
            Controls.Add(ProgressBar);
            Controls.Add(ForbiddenWordsListBox);
            Controls.Add(ResultsListBox);
            Controls.Add(StopButton);
            Controls.Add(BrowseButton);
            Controls.Add(StartButton);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button StartButton;
        private Button BrowseButton;
        private Button StopButton;
        private ListBox ResultsListBox;
        private ListBox ForbiddenWordsListBox;
        private ProgressBar ProgressBar;
    }
}