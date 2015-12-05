namespace HymmnosRecognize
{
    partial class MainForm
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
            this.Listen = new System.Windows.Forms.Button();
            this.dictionaryText = new System.Windows.Forms.TextBox();
            this.dictionaryLabel = new System.Windows.Forms.Label();
            this.dictionaryOpen = new System.Windows.Forms.Button();
            this.macroLabel = new System.Windows.Forms.Label();
            this.macroText = new System.Windows.Forms.TextBox();
            this.macroOpen = new System.Windows.Forms.Button();
            this.logBox = new System.Windows.Forms.TextBox();
            this.dictionaryManage = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Listen
            // 
            this.Listen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Listen.Location = new System.Drawing.Point(12, 238);
            this.Listen.Name = "Listen";
            this.Listen.Size = new System.Drawing.Size(75, 23);
            this.Listen.TabIndex = 0;
            this.Listen.Text = "Listen";
            this.Listen.UseVisualStyleBackColor = true;
            this.Listen.Click += new System.EventHandler(this.TestButton_Click);
            // 
            // dictionaryText
            // 
            this.dictionaryText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dictionaryText.Location = new System.Drawing.Point(12, 29);
            this.dictionaryText.Name = "dictionaryText";
            this.dictionaryText.ReadOnly = true;
            this.dictionaryText.Size = new System.Drawing.Size(268, 20);
            this.dictionaryText.TabIndex = 1;
            // 
            // dictionaryLabel
            // 
            this.dictionaryLabel.AutoSize = true;
            this.dictionaryLabel.Location = new System.Drawing.Point(13, 13);
            this.dictionaryLabel.Name = "dictionaryLabel";
            this.dictionaryLabel.Size = new System.Drawing.Size(76, 13);
            this.dictionaryLabel.TabIndex = 2;
            this.dictionaryLabel.Text = "Dictionary File:";
            // 
            // dictionaryOpen
            // 
            this.dictionaryOpen.Location = new System.Drawing.Point(16, 56);
            this.dictionaryOpen.Name = "dictionaryOpen";
            this.dictionaryOpen.Size = new System.Drawing.Size(128, 23);
            this.dictionaryOpen.TabIndex = 3;
            this.dictionaryOpen.Text = "Choose Dicationary File";
            this.dictionaryOpen.UseVisualStyleBackColor = true;
            this.dictionaryOpen.Click += new System.EventHandler(this.dictionaryOpen_Click);
            // 
            // macroLabel
            // 
            this.macroLabel.AutoSize = true;
            this.macroLabel.Location = new System.Drawing.Point(13, 82);
            this.macroLabel.Name = "macroLabel";
            this.macroLabel.Size = new System.Drawing.Size(59, 13);
            this.macroLabel.TabIndex = 4;
            this.macroLabel.Text = "Macro File:";
            // 
            // macroText
            // 
            this.macroText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.macroText.Location = new System.Drawing.Point(12, 98);
            this.macroText.Name = "macroText";
            this.macroText.ReadOnly = true;
            this.macroText.Size = new System.Drawing.Size(268, 20);
            this.macroText.TabIndex = 5;
            // 
            // macroOpen
            // 
            this.macroOpen.Location = new System.Drawing.Point(16, 125);
            this.macroOpen.Name = "macroOpen";
            this.macroOpen.Size = new System.Drawing.Size(128, 23);
            this.macroOpen.TabIndex = 6;
            this.macroOpen.Text = "Choose Macro File";
            this.macroOpen.UseVisualStyleBackColor = true;
            this.macroOpen.Click += new System.EventHandler(this.macroOpen_Click);
            // 
            // logBox
            // 
            this.logBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logBox.Location = new System.Drawing.Point(12, 155);
            this.logBox.Multiline = true;
            this.logBox.Name = "logBox";
            this.logBox.ReadOnly = true;
            this.logBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.logBox.Size = new System.Drawing.Size(268, 77);
            this.logBox.TabIndex = 7;
            // 
            // dictionaryManage
            // 
            this.dictionaryManage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dictionaryManage.Location = new System.Drawing.Point(171, 238);
            this.dictionaryManage.Name = "dictionaryManage";
            this.dictionaryManage.Size = new System.Drawing.Size(109, 23);
            this.dictionaryManage.TabIndex = 8;
            this.dictionaryManage.Text = "Manage Dictionary";
            this.dictionaryManage.UseVisualStyleBackColor = true;
            this.dictionaryManage.Click += new System.EventHandler(this.dictionaryManage_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.dictionaryManage);
            this.Controls.Add(this.logBox);
            this.Controls.Add(this.macroOpen);
            this.Controls.Add(this.macroText);
            this.Controls.Add(this.macroLabel);
            this.Controls.Add(this.dictionaryOpen);
            this.Controls.Add(this.dictionaryLabel);
            this.Controls.Add(this.dictionaryText);
            this.Controls.Add(this.Listen);
            this.Name = "MainForm";
            this.Text = "Hymmnos Command Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Listen;
        private System.Windows.Forms.TextBox dictionaryText;
        private System.Windows.Forms.Label dictionaryLabel;
        private System.Windows.Forms.Button dictionaryOpen;
        private System.Windows.Forms.Label macroLabel;
        private System.Windows.Forms.TextBox macroText;
        private System.Windows.Forms.Button macroOpen;
        private System.Windows.Forms.TextBox logBox;
        private System.Windows.Forms.Button dictionaryManage;

    }
}

