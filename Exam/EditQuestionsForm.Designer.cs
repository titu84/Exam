namespace Exam
{
    partial class EditQuestionsForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditQuestionsForm));
            this.cbAnswerType = new System.Windows.Forms.ComboBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.cbQuestionList = new System.Windows.Forms.ComboBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.cbQuestionType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelDescription = new System.Windows.Forms.Label();
            this.btnImageAdd = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.wklejToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnImageAltAdd = new System.Windows.Forms.Button();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnGreen = new System.Windows.Forms.Button();
            this.btnBold = new System.Windows.Forms.Button();
            this.btnUnderlined = new System.Windows.Forms.Button();
            this.btnLt = new System.Windows.Forms.Button();
            this.btnGt = new System.Windows.Forms.Button();
            this.btnReplaceLtGt = new System.Windows.Forms.Button();
            this.btnNbsp = new System.Windows.Forms.Button();
            this.btnItalic = new System.Windows.Forms.Button();
            this.btnReplaceNewLine = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbAnswerType
            // 
            this.cbAnswerType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbAnswerType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAnswerType.FormattingEnabled = true;
            this.cbAnswerType.Items.AddRange(new object[] {
            "True/False",
            "Jednokrotny wybór",
            "Wielokrotny wybór",
            "Dopasowanie",
            "Przenoszenie",
            "Wpisywanie"});
            this.cbAnswerType.Location = new System.Drawing.Point(126, 708);
            this.cbAnswerType.Name = "cbAnswerType";
            this.cbAnswerType.Size = new System.Drawing.Size(117, 21);
            this.cbAnswerType.TabIndex = 1;
            this.cbAnswerType.SelectedIndexChanged += new System.EventHandler(this.cbAnswerType_SelectedIndexChanged);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubmit.Location = new System.Drawing.Point(1296, 720);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(81, 23);
            this.btnSubmit.TabIndex = 10;
            this.btnSubmit.Text = "Dodaj";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // cbQuestionList
            // 
            this.cbQuestionList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbQuestionList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbQuestionList.FormattingEnabled = true;
            this.cbQuestionList.Location = new System.Drawing.Point(12, 708);
            this.cbQuestionList.Name = "cbQuestionList";
            this.cbQuestionList.Size = new System.Drawing.Size(108, 21);
            this.cbQuestionList.TabIndex = 11;
            this.cbQuestionList.SelectedIndexChanged += new System.EventHandler(this.cbQuestionList_SelectedIndexChanged);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(1296, 693);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(81, 23);
            this.btnDelete.TabIndex = 12;
            this.btnDelete.Text = "Usuń ";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // cbQuestionType
            // 
            this.cbQuestionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbQuestionType.FormattingEnabled = true;
            this.cbQuestionType.Items.AddRange(new object[] {
            "Tekst",
            "Obrazek"});
            this.cbQuestionType.Location = new System.Drawing.Point(94, 3);
            this.cbQuestionType.Name = "cbQuestionType";
            this.cbQuestionType.Size = new System.Drawing.Size(275, 21);
            this.cbQuestionType.TabIndex = 15;
            this.cbQuestionType.SelectedIndexChanged += new System.EventHandler(this.cbQuestionType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Typ pytania";
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(13, 30);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(19, 13);
            this.labelDescription.TabIndex = 17;
            this.labelDescription.Text = "....";
            // 
            // btnImageAdd
            // 
            this.btnImageAdd.Location = new System.Drawing.Point(375, 3);
            this.btnImageAdd.Name = "btnImageAdd";
            this.btnImageAdd.Size = new System.Drawing.Size(116, 23);
            this.btnImageAdd.TabIndex = 18;
            this.btnImageAdd.Text = "Wybierz obrazek";
            this.btnImageAdd.UseVisualStyleBackColor = true;
            this.btnImageAdd.Visible = false;
            this.btnImageAdd.Click += new System.EventHandler(this.btnImageAdd_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "jpg| *.jpg|png| *.png";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(13, 110);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(659, 572);
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.DoubleClick += new System.EventHandler(this.pictureBox1_DoubleClick);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.richTextBox1.Location = new System.Drawing.Point(13, 51);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(1364, 631);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            this.richTextBox1.SelectionChanged += new System.EventHandler(this.richTextBox1_SelectionChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wklejToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(104, 26);
            // 
            // wklejToolStripMenuItem
            // 
            this.wklejToolStripMenuItem.Name = "wklejToolStripMenuItem";
            this.wklejToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.wklejToolStripMenuItem.Text = "Wklej";
            this.wklejToolStripMenuItem.Click += new System.EventHandler(this.wklejToolStripMenuItem_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox2.Location = new System.Drawing.Point(678, 110);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(699, 572);
            this.pictureBox2.TabIndex = 20;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Visible = false;
            this.pictureBox2.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox2_Paint);
            this.pictureBox2.DoubleClick += new System.EventHandler(this.pictureBox2_DoubleClick);
            this.pictureBox2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseDown);
            // 
            // btnImageAltAdd
            // 
            this.btnImageAltAdd.Location = new System.Drawing.Point(558, 3);
            this.btnImageAltAdd.Name = "btnImageAltAdd";
            this.btnImageAltAdd.Size = new System.Drawing.Size(212, 23);
            this.btnImageAltAdd.TabIndex = 21;
            this.btnImageAltAdd.Text = "Wybierz alternatywny obrazek";
            this.btnImageAltAdd.UseVisualStyleBackColor = true;
            this.btnImageAltAdd.Visible = false;
            this.btnImageAltAdd.Click += new System.EventHandler(this.btnImageAltAdd_Click);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.contextMenuStrip2.Name = "contextMenuStrip1";
            this.contextMenuStrip2.Size = new System.Drawing.Size(104, 26);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(103, 22);
            this.toolStripMenuItem1.Text = "Wklej";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // btnGreen
            // 
            this.btnGreen.BackColor = System.Drawing.Color.LightGreen;
            this.btnGreen.Enabled = false;
            this.btnGreen.ForeColor = System.Drawing.Color.Black;
            this.btnGreen.Location = new System.Drawing.Point(321, 27);
            this.btnGreen.Name = "btnGreen";
            this.btnGreen.Size = new System.Drawing.Size(58, 23);
            this.btnGreen.TabIndex = 22;
            this.btnGreen.Text = "Zielony";
            this.btnGreen.UseVisualStyleBackColor = false;
            this.btnGreen.Click += new System.EventHandler(this.btnGreen_Click);
            // 
            // btnBold
            // 
            this.btnBold.BackColor = System.Drawing.SystemColors.Control;
            this.btnBold.Enabled = false;
            this.btnBold.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.336843F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnBold.ForeColor = System.Drawing.Color.Black;
            this.btnBold.Location = new System.Drawing.Point(385, 27);
            this.btnBold.Name = "btnBold";
            this.btnBold.Size = new System.Drawing.Size(37, 23);
            this.btnBold.TabIndex = 23;
            this.btnBold.Text = "B";
            this.btnBold.UseVisualStyleBackColor = false;
            this.btnBold.Click += new System.EventHandler(this.btnBold_Click);
            // 
            // btnUnderlined
            // 
            this.btnUnderlined.BackColor = System.Drawing.SystemColors.Control;
            this.btnUnderlined.Enabled = false;
            this.btnUnderlined.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.336843F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnUnderlined.ForeColor = System.Drawing.Color.Black;
            this.btnUnderlined.Location = new System.Drawing.Point(428, 27);
            this.btnUnderlined.Name = "btnUnderlined";
            this.btnUnderlined.Size = new System.Drawing.Size(38, 23);
            this.btnUnderlined.TabIndex = 24;
            this.btnUnderlined.Text = "U";
            this.btnUnderlined.UseVisualStyleBackColor = false;
            this.btnUnderlined.Click += new System.EventHandler(this.btnUnderlined_Click);
            // 
            // btnLt
            // 
            this.btnLt.BackColor = System.Drawing.SystemColors.Control;
            this.btnLt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.336843F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnLt.ForeColor = System.Drawing.Color.Black;
            this.btnLt.Location = new System.Drawing.Point(94, 27);
            this.btnLt.Name = "btnLt";
            this.btnLt.Size = new System.Drawing.Size(26, 23);
            this.btnLt.TabIndex = 25;
            this.btnLt.Text = "<";
            this.btnLt.UseVisualStyleBackColor = false;
            this.btnLt.Click += new System.EventHandler(this.btnLt_Click);
            // 
            // btnGt
            // 
            this.btnGt.BackColor = System.Drawing.SystemColors.Control;
            this.btnGt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.336843F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnGt.ForeColor = System.Drawing.Color.Black;
            this.btnGt.Location = new System.Drawing.Point(156, 27);
            this.btnGt.Name = "btnGt";
            this.btnGt.Size = new System.Drawing.Size(23, 23);
            this.btnGt.TabIndex = 26;
            this.btnGt.Text = ">";
            this.btnGt.UseVisualStyleBackColor = false;
            this.btnGt.Click += new System.EventHandler(this.btnGt_Click);
            // 
            // btnReplaceLtGt
            // 
            this.btnReplaceLtGt.BackColor = System.Drawing.SystemColors.Control;
            this.btnReplaceLtGt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.336843F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnReplaceLtGt.ForeColor = System.Drawing.Color.Black;
            this.btnReplaceLtGt.Location = new System.Drawing.Point(185, 27);
            this.btnReplaceLtGt.Name = "btnReplaceLtGt";
            this.btnReplaceLtGt.Size = new System.Drawing.Size(130, 23);
            this.btnReplaceLtGt.TabIndex = 27;
            this.btnReplaceLtGt.Text = "Zamiań <> na lt i gt";
            this.btnReplaceLtGt.UseVisualStyleBackColor = false;
            this.btnReplaceLtGt.Click += new System.EventHandler(this.btnReplaceLtGt_Click);
            // 
            // btnNbsp
            // 
            this.btnNbsp.BackColor = System.Drawing.SystemColors.Control;
            this.btnNbsp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.336843F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnNbsp.ForeColor = System.Drawing.Color.Black;
            this.btnNbsp.Location = new System.Drawing.Point(126, 27);
            this.btnNbsp.Name = "btnNbsp";
            this.btnNbsp.Size = new System.Drawing.Size(24, 23);
            this.btnNbsp.TabIndex = 28;
            this.btnNbsp.Text = "_";
            this.btnNbsp.UseVisualStyleBackColor = false;
            this.btnNbsp.Click += new System.EventHandler(this.btnNbsp_Click);
            // 
            // btnItalic
            // 
            this.btnItalic.BackColor = System.Drawing.SystemColors.Control;
            this.btnItalic.Enabled = false;
            this.btnItalic.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.336843F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnItalic.ForeColor = System.Drawing.Color.Black;
            this.btnItalic.Location = new System.Drawing.Point(472, 27);
            this.btnItalic.Name = "btnItalic";
            this.btnItalic.Size = new System.Drawing.Size(38, 23);
            this.btnItalic.TabIndex = 29;
            this.btnItalic.Text = "I";
            this.btnItalic.UseVisualStyleBackColor = false;
            this.btnItalic.Click += new System.EventHandler(this.btnItalic_Click);
            // 
            // btnReplaceNewLine
            // 
            this.btnReplaceNewLine.BackColor = System.Drawing.SystemColors.Control;
            this.btnReplaceNewLine.Enabled = false;
            this.btnReplaceNewLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.336843F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnReplaceNewLine.ForeColor = System.Drawing.Color.Black;
            this.btnReplaceNewLine.Location = new System.Drawing.Point(516, 27);
            this.btnReplaceNewLine.Name = "btnReplaceNewLine";
            this.btnReplaceNewLine.Size = new System.Drawing.Size(156, 23);
            this.btnReplaceNewLine.TabIndex = 30;
            this.btnReplaceNewLine.Text = "Skasuj znak nowej linii";
            this.btnReplaceNewLine.UseVisualStyleBackColor = false;
            this.btnReplaceNewLine.Click += new System.EventHandler(this.btnReplaceNewLine_Click);
            // 
            // EditQuestionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1389, 750);
            this.Controls.Add(this.btnReplaceNewLine);
            this.Controls.Add(this.btnItalic);
            this.Controls.Add(this.btnNbsp);
            this.Controls.Add(this.btnReplaceLtGt);
            this.Controls.Add(this.btnGt);
            this.Controls.Add(this.btnLt);
            this.Controls.Add(this.btnUnderlined);
            this.Controls.Add(this.btnBold);
            this.Controls.Add(this.btnGreen);
            this.Controls.Add(this.btnImageAltAdd);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnImageAdd);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbQuestionType);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.cbQuestionList);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.cbAnswerType);
            this.Controls.Add(this.richTextBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1070, 660);
            this.Name = "EditQuestionsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dodaj nowe pytanie";
            this.Load += new System.EventHandler(this.EditQuestionsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cbAnswerType;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.ComboBox cbQuestionList;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ComboBox cbQuestionType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Button btnImageAdd;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem wklejToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnImageAltAdd;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.Button btnGreen;
        private System.Windows.Forms.Button btnBold;
        private System.Windows.Forms.Button btnUnderlined;
        private System.Windows.Forms.Button btnLt;
        private System.Windows.Forms.Button btnGt;
        private System.Windows.Forms.Button btnReplaceLtGt;
        private System.Windows.Forms.Button btnNbsp;
        private System.Windows.Forms.Button btnItalic;
        private System.Windows.Forms.Button btnReplaceNewLine;
    }
}