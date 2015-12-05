namespace HymmnosRecognize
{
    partial class DictionaryForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.wordList = new System.Windows.Forms.ListView();
            this.words = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.partOfSpeechList = new System.Windows.Forms.ListView();
            this.partsOfSpeech = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pronunciationList = new System.Windows.Forms.ListView();
            this.pronunciations = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.testPronunciationButton = new System.Windows.Forms.Button();
            this.pronunciationBox = new System.Windows.Forms.TextBox();
            this.addPronunciationButton = new System.Windows.Forms.Button();
            this.removePronunciationButton = new System.Windows.Forms.Button();
            this.addWordButton = new System.Windows.Forms.Button();
            this.wordBox = new System.Windows.Forms.TextBox();
            this.removeWordButton = new System.Windows.Forms.Button();
            this.pronunciationLabel = new System.Windows.Forms.Label();
            this.wordLabel = new System.Windows.Forms.Label();
            this.removePartOfSpeechButton = new System.Windows.Forms.Button();
            this.addPartOfSpeechButton = new System.Windows.Forms.Button();
            this.writeButton = new System.Windows.Forms.Button();
            this.wordFilter = new System.Windows.Forms.TextBox();
            this.wordFilterLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // wordList
            // 
            this.wordList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wordList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.words});
            this.wordList.FullRowSelect = true;
            this.wordList.GridLines = true;
            this.wordList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.wordList.HideSelection = false;
            this.wordList.Location = new System.Drawing.Point(180, 12);
            this.wordList.MultiSelect = false;
            this.wordList.Name = "wordList";
            this.wordList.ShowGroups = false;
            this.wordList.Size = new System.Drawing.Size(179, 268);
            this.wordList.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.wordList.TabIndex = 0;
            this.wordList.UseCompatibleStateImageBehavior = false;
            this.wordList.View = System.Windows.Forms.View.Details;
            this.wordList.SelectedIndexChanged += new System.EventHandler(this.wordList_SelectedIndexChanged);
            // 
            // words
            // 
            this.words.Text = "Words";
            // 
            // partOfSpeechList
            // 
            this.partOfSpeechList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.partOfSpeechList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.partsOfSpeech});
            this.partOfSpeechList.FullRowSelect = true;
            this.partOfSpeechList.GridLines = true;
            this.partOfSpeechList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.partOfSpeechList.HideSelection = false;
            this.partOfSpeechList.Location = new System.Drawing.Point(365, 12);
            this.partOfSpeechList.Name = "partOfSpeechList";
            this.partOfSpeechList.ShowGroups = false;
            this.partOfSpeechList.Size = new System.Drawing.Size(142, 268);
            this.partOfSpeechList.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.partOfSpeechList.TabIndex = 1;
            this.partOfSpeechList.UseCompatibleStateImageBehavior = false;
            this.partOfSpeechList.View = System.Windows.Forms.View.Details;
            // 
            // partsOfSpeech
            // 
            this.partsOfSpeech.Text = "Parts Of Speech";
            // 
            // pronunciationList
            // 
            this.pronunciationList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pronunciationList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.pronunciations});
            this.pronunciationList.FullRowSelect = true;
            this.pronunciationList.GridLines = true;
            this.pronunciationList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.pronunciationList.HideSelection = false;
            this.pronunciationList.Location = new System.Drawing.Point(12, 12);
            this.pronunciationList.MultiSelect = false;
            this.pronunciationList.Name = "pronunciationList";
            this.pronunciationList.ShowGroups = false;
            this.pronunciationList.Size = new System.Drawing.Size(162, 268);
            this.pronunciationList.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.pronunciationList.TabIndex = 2;
            this.pronunciationList.UseCompatibleStateImageBehavior = false;
            this.pronunciationList.View = System.Windows.Forms.View.Details;
            // 
            // pronunciations
            // 
            this.pronunciations.Text = "Pronunciations";
            // 
            // testPronunciationButton
            // 
            this.testPronunciationButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.testPronunciationButton.Location = new System.Drawing.Point(13, 299);
            this.testPronunciationButton.Name = "testPronunciationButton";
            this.testPronunciationButton.Size = new System.Drawing.Size(161, 23);
            this.testPronunciationButton.TabIndex = 3;
            this.testPronunciationButton.Text = "Test Selected Pronunciation";
            this.testPronunciationButton.UseVisualStyleBackColor = true;
            this.testPronunciationButton.Click += new System.EventHandler(this.testPronunciationButton_Click);
            // 
            // pronunciationBox
            // 
            this.pronunciationBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pronunciationBox.Location = new System.Drawing.Point(12, 341);
            this.pronunciationBox.Name = "pronunciationBox";
            this.pronunciationBox.Size = new System.Drawing.Size(161, 20);
            this.pronunciationBox.TabIndex = 4;
            // 
            // addPronunciationButton
            // 
            this.addPronunciationButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addPronunciationButton.Location = new System.Drawing.Point(12, 367);
            this.addPronunciationButton.Name = "addPronunciationButton";
            this.addPronunciationButton.Size = new System.Drawing.Size(162, 23);
            this.addPronunciationButton.TabIndex = 5;
            this.addPronunciationButton.Text = "Add Pronunciation";
            this.addPronunciationButton.UseVisualStyleBackColor = true;
            this.addPronunciationButton.Click += new System.EventHandler(this.addPronunciationButton_Click);
            // 
            // removePronunciationButton
            // 
            this.removePronunciationButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.removePronunciationButton.Location = new System.Drawing.Point(12, 396);
            this.removePronunciationButton.Name = "removePronunciationButton";
            this.removePronunciationButton.Size = new System.Drawing.Size(162, 23);
            this.removePronunciationButton.TabIndex = 6;
            this.removePronunciationButton.Text = "Remove Pronunciation";
            this.removePronunciationButton.UseVisualStyleBackColor = true;
            this.removePronunciationButton.Click += new System.EventHandler(this.removePronunciationButton_Click);
            // 
            // addWordButton
            // 
            this.addWordButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.addWordButton.Location = new System.Drawing.Point(180, 367);
            this.addWordButton.Name = "addWordButton";
            this.addWordButton.Size = new System.Drawing.Size(179, 23);
            this.addWordButton.TabIndex = 7;
            this.addWordButton.Text = "Add Word";
            this.addWordButton.UseVisualStyleBackColor = true;
            this.addWordButton.Click += new System.EventHandler(this.addWordButton_Click);
            // 
            // wordBox
            // 
            this.wordBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wordBox.Location = new System.Drawing.Point(180, 341);
            this.wordBox.Name = "wordBox";
            this.wordBox.Size = new System.Drawing.Size(179, 20);
            this.wordBox.TabIndex = 8;
            // 
            // removeWordButton
            // 
            this.removeWordButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.removeWordButton.Location = new System.Drawing.Point(180, 396);
            this.removeWordButton.Name = "removeWordButton";
            this.removeWordButton.Size = new System.Drawing.Size(179, 23);
            this.removeWordButton.TabIndex = 9;
            this.removeWordButton.Text = "Remove Word";
            this.removeWordButton.UseVisualStyleBackColor = true;
            this.removeWordButton.Click += new System.EventHandler(this.removeWordButton_Click);
            // 
            // pronunciationLabel
            // 
            this.pronunciationLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pronunciationLabel.AutoSize = true;
            this.pronunciationLabel.Location = new System.Drawing.Point(12, 325);
            this.pronunciationLabel.Name = "pronunciationLabel";
            this.pronunciationLabel.Size = new System.Drawing.Size(75, 13);
            this.pronunciationLabel.TabIndex = 10;
            this.pronunciationLabel.Text = "Pronunciation:";
            // 
            // wordLabel
            // 
            this.wordLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wordLabel.AutoSize = true;
            this.wordLabel.Location = new System.Drawing.Point(180, 324);
            this.wordLabel.Name = "wordLabel";
            this.wordLabel.Size = new System.Drawing.Size(36, 13);
            this.wordLabel.TabIndex = 11;
            this.wordLabel.Text = "Word:";
            // 
            // removePartOfSpeechButton
            // 
            this.removePartOfSpeechButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.removePartOfSpeechButton.Location = new System.Drawing.Point(365, 396);
            this.removePartOfSpeechButton.Name = "removePartOfSpeechButton";
            this.removePartOfSpeechButton.Size = new System.Drawing.Size(142, 23);
            this.removePartOfSpeechButton.TabIndex = 12;
            this.removePartOfSpeechButton.Text = "Remove Part of Speech";
            this.removePartOfSpeechButton.UseVisualStyleBackColor = true;
            this.removePartOfSpeechButton.Click += new System.EventHandler(this.removePartOfSpeechButton_Click);
            // 
            // addPartOfSpeechButton
            // 
            this.addPartOfSpeechButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addPartOfSpeechButton.Location = new System.Drawing.Point(365, 367);
            this.addPartOfSpeechButton.Name = "addPartOfSpeechButton";
            this.addPartOfSpeechButton.Size = new System.Drawing.Size(142, 23);
            this.addPartOfSpeechButton.TabIndex = 13;
            this.addPartOfSpeechButton.Text = "Add Part of Speech";
            this.addPartOfSpeechButton.UseVisualStyleBackColor = true;
            this.addPartOfSpeechButton.Click += new System.EventHandler(this.addPartOfSpeechButton_Click);
            // 
            // writeButton
            // 
            this.writeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.writeButton.Location = new System.Drawing.Point(365, 286);
            this.writeButton.Name = "writeButton";
            this.writeButton.Size = new System.Drawing.Size(142, 23);
            this.writeButton.TabIndex = 16;
            this.writeButton.Text = "Write Dictionary To File";
            this.writeButton.UseVisualStyleBackColor = true;
            this.writeButton.Click += new System.EventHandler(this.writeButton_Click);
            // 
            // wordFilter
            // 
            this.wordFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wordFilter.Location = new System.Drawing.Point(180, 302);
            this.wordFilter.Name = "wordFilter";
            this.wordFilter.Size = new System.Drawing.Size(179, 20);
            this.wordFilter.TabIndex = 17;
            this.wordFilter.TextChanged += new System.EventHandler(this.wordFilter_TextChanged);
            // 
            // wordFilterLabel
            // 
            this.wordFilterLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wordFilterLabel.AutoSize = true;
            this.wordFilterLabel.Location = new System.Drawing.Point(177, 283);
            this.wordFilterLabel.Name = "wordFilterLabel";
            this.wordFilterLabel.Size = new System.Drawing.Size(61, 13);
            this.wordFilterLabel.TabIndex = 18;
            this.wordFilterLabel.Text = "Word Filter:";
            // 
            // DictionaryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 431);
            this.Controls.Add(this.wordFilterLabel);
            this.Controls.Add(this.wordFilter);
            this.Controls.Add(this.writeButton);
            this.Controls.Add(this.addPartOfSpeechButton);
            this.Controls.Add(this.removePartOfSpeechButton);
            this.Controls.Add(this.wordLabel);
            this.Controls.Add(this.pronunciationLabel);
            this.Controls.Add(this.removeWordButton);
            this.Controls.Add(this.wordBox);
            this.Controls.Add(this.addWordButton);
            this.Controls.Add(this.removePronunciationButton);
            this.Controls.Add(this.addPronunciationButton);
            this.Controls.Add(this.pronunciationBox);
            this.Controls.Add(this.testPronunciationButton);
            this.Controls.Add(this.pronunciationList);
            this.Controls.Add(this.partOfSpeechList);
            this.Controls.Add(this.wordList);
            this.Name = "DictionaryForm";
            this.Text = "Manage Dictionary";
            this.Resize += new System.EventHandler(this.DictionaryForm_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView wordList;
        private System.Windows.Forms.ListView partOfSpeechList;
        private System.Windows.Forms.ListView pronunciationList;
        private System.Windows.Forms.ColumnHeader words;
        private System.Windows.Forms.ColumnHeader partsOfSpeech;
        private System.Windows.Forms.ColumnHeader pronunciations;
        private System.Windows.Forms.Button testPronunciationButton;
        private System.Windows.Forms.TextBox pronunciationBox;
        private System.Windows.Forms.Button addPronunciationButton;
        private System.Windows.Forms.Button removePronunciationButton;
        private System.Windows.Forms.Button addWordButton;
        private System.Windows.Forms.TextBox wordBox;
        private System.Windows.Forms.Button removeWordButton;
        private System.Windows.Forms.Label pronunciationLabel;
        private System.Windows.Forms.Label wordLabel;
        private System.Windows.Forms.Button removePartOfSpeechButton;
        private System.Windows.Forms.Button addPartOfSpeechButton;
        private System.Windows.Forms.Button writeButton;
        private System.Windows.Forms.TextBox wordFilter;
        private System.Windows.Forms.Label wordFilterLabel;


    }
}