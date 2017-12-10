namespace Exam
{
    partial class QuestionForm
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
            this.buttonNext = new System.Windows.Forms.Button();
            this.labelQuestion = new System.Windows.Forms.Label();
            this.buttonPrevious = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.btnCheckAll = new System.Windows.Forms.Button();
            this.btnTranslate = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.labelShow = new System.Windows.Forms.Label();
            this.btnSpeak = new System.Windows.Forms.Button();
            this.cbMark = new System.Windows.Forms.CheckBox();
            this.btnDecrease = new System.Windows.Forms.Button();
            this.btnIncrease = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonNext
            // 
            this.buttonNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonNext.Location = new System.Drawing.Point(875, 465);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(90, 23);
            this.buttonNext.TabIndex = 0;
            this.buttonNext.Text = "Następne ";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // labelQuestion
            // 
            this.labelQuestion.AutoSize = true;
            this.labelQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelQuestion.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labelQuestion.Location = new System.Drawing.Point(117, 8);
            this.labelQuestion.Name = "labelQuestion";
            this.labelQuestion.Size = new System.Drawing.Size(62, 17);
            this.labelQuestion.TabIndex = 2;
            this.labelQuestion.Text = "Pytanie";
            // 
            // buttonPrevious
            // 
            this.buttonPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPrevious.Location = new System.Drawing.Point(783, 465);
            this.buttonPrevious.Name = "buttonPrevious";
            this.buttonPrevious.Size = new System.Drawing.Size(90, 23);
            this.buttonPrevious.TabIndex = 5;
            this.buttonPrevious.Text = "Poprzednie";
            this.buttonPrevious.UseVisualStyleBackColor = true;
            this.buttonPrevious.Click += new System.EventHandler(this.buttonPrevious_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.webBrowser1);
            this.panel1.Location = new System.Drawing.Point(106, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(862, 370);
            this.panel1.TabIndex = 4;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(860, 368);
            this.webBrowser1.TabIndex = 5;
            // 
            // btnCheckAll
            // 
            this.btnCheckAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheckAll.Location = new System.Drawing.Point(901, 427);
            this.btnCheckAll.Name = "btnCheckAll";
            this.btnCheckAll.Size = new System.Drawing.Size(64, 23);
            this.btnCheckAll.TabIndex = 4;
            this.btnCheckAll.Text = "Wyniki";
            this.btnCheckAll.UseVisualStyleBackColor = true;
            this.btnCheckAll.Visible = false;
            this.btnCheckAll.Click += new System.EventHandler(this.btnCheckAll_Click);
            // 
            // btnTranslate
            // 
            this.btnTranslate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTranslate.Location = new System.Drawing.Point(837, 427);
            this.btnTranslate.Name = "btnTranslate";
            this.btnTranslate.Size = new System.Drawing.Size(58, 23);
            this.btnTranslate.TabIndex = 3;
            this.btnTranslate.Text = "Tłumacz";
            this.btnTranslate.UseVisualStyleBackColor = true;
            this.btnTranslate.Click += new System.EventHandler(this.btnTranslate_Click);
            this.btnTranslate.MouseLeave += new System.EventHandler(this.btnTranslate_MouseLeave);
            this.btnTranslate.MouseHover += new System.EventHandler(this.btnTranslate_MouseHover);
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 50;
            this.toolTip1.ReshowDelay = 100;
            // 
            // labelShow
            // 
            this.labelShow.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelShow.AutoSize = true;
            this.labelShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelShow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.labelShow.Location = new System.Drawing.Point(228, 8);
            this.labelShow.Name = "labelShow";
            this.labelShow.Size = new System.Drawing.Size(149, 17);
            this.labelShow.TabIndex = 7;
            this.labelShow.Text = "Prawidłowa odpowiedź";
            this.labelShow.Visible = false;
            this.labelShow.MouseLeave += new System.EventHandler(this.labelShow_MouseLeave);
            this.labelShow.MouseHover += new System.EventHandler(this.labelShow_MouseHover);
            // 
            // btnSpeak
            // 
            this.btnSpeak.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSpeak.Location = new System.Drawing.Point(783, 427);
            this.btnSpeak.Name = "btnSpeak";
            this.btnSpeak.Size = new System.Drawing.Size(48, 23);
            this.btnSpeak.TabIndex = 2;
            this.btnSpeak.Text = "Czytaj";
            this.btnSpeak.UseVisualStyleBackColor = true;
            this.btnSpeak.Click += new System.EventHandler(this.btnSpeak_Click);
            this.btnSpeak.MouseLeave += new System.EventHandler(this.btnSpeak_MouseLeave);
            this.btnSpeak.MouseHover += new System.EventHandler(this.btnSpeak_MouseHover);
            // 
            // cbMark
            // 
            this.cbMark.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbMark.AutoSize = true;
            this.cbMark.Location = new System.Drawing.Point(796, 9);
            this.cbMark.Name = "cbMark";
            this.cbMark.Size = new System.Drawing.Size(99, 17);
            this.cbMark.TabIndex = 8;
            this.cbMark.Text = "Oznacz pytanie";
            this.cbMark.UseVisualStyleBackColor = true;
            this.cbMark.CheckedChanged += new System.EventHandler(this.cbMark_CheckedChanged);
            // 
            // btnDecrease
            // 
            this.btnDecrease.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDecrease.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnDecrease.Location = new System.Drawing.Point(901, 6);
            this.btnDecrease.Name = "btnDecrease";
            this.btnDecrease.Size = new System.Drawing.Size(29, 23);
            this.btnDecrease.TabIndex = 9;
            this.btnDecrease.Text = "-";
            this.btnDecrease.UseVisualStyleBackColor = true;
            this.btnDecrease.Click += new System.EventHandler(this.btnDecrease_Click);
            // 
            // btnIncrease
            // 
            this.btnIncrease.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIncrease.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnIncrease.Location = new System.Drawing.Point(936, 6);
            this.btnIncrease.Name = "btnIncrease";
            this.btnIncrease.Size = new System.Drawing.Size(29, 23);
            this.btnIncrease.TabIndex = 10;
            this.btnIncrease.Text = "+";
            this.btnIncrease.UseVisualStyleBackColor = true;
            this.btnIncrease.Click += new System.EventHandler(this.btnIncrease_Click);
            // 
            // QuestionForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1000, 550);
            this.Controls.Add(this.btnIncrease);
            this.Controls.Add(this.btnDecrease);
            this.Controls.Add(this.cbMark);
            this.Controls.Add(this.btnSpeak);
            this.Controls.Add(this.labelShow);
            this.Controls.Add(this.btnTranslate);
            this.Controls.Add(this.btnCheckAll);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonPrevious);
            this.Controls.Add(this.labelQuestion);
            this.Controls.Add(this.buttonNext);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "QuestionForm";
            this.Padding = new System.Windows.Forms.Padding(353, 5, 0, 0);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.QuestionForm_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Button buttonNext;
        public System.Windows.Forms.Label labelQuestion;
        public System.Windows.Forms.Button buttonPrevious;
        public System.Windows.Forms.Button btnCheckAll;
        public System.Windows.Forms.WebBrowser webBrowser1;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Button btnTranslate;
        private System.Windows.Forms.ToolTip toolTip1;
        public System.Windows.Forms.Label labelShow;
        public System.Windows.Forms.Button btnSpeak;
        internal System.Windows.Forms.CheckBox cbMark;
        private System.Windows.Forms.Button btnDecrease;
        private System.Windows.Forms.Button btnIncrease;
    }
}