namespace Exam
{
    partial class ParentForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ParentForm));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.timeLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItemAddRange = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemEditQuestions = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemCreateDB = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemOK = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemExport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemExportCarousel = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemDeleteQuestions = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBoxDbFile = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripMenuItemSelectDb = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.saveFileDialog2 = new System.Windows.Forms.SaveFileDialog();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.timeLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 676);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1192, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // timeLabel
            // 
            this.timeLabel.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.timeLabel.ForeColor = System.Drawing.Color.Blue;
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemAddRange,
            this.toolStripMenuItem1,
            this.toolStripTextBoxDbFile,
            this.toolStripMenuItemSelectDb,
            this.toolStripMenuItem3,
            this.toolStripMenuItemLoad,
            this.toolStripComboBox1,
            this.toolStripMenuItem2});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1192, 27);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItemAddRange
            // 
            this.toolStripMenuItemAddRange.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemEditQuestions,
            this.toolStripMenuItemCreateDB,
            this.toolStripMenuItemAdd,
            this.toolStripSeparator1,
            this.toolStripMenuItemOK,
            this.toolStripSeparator2,
            this.toolStripMenuItemExport,
            this.toolStripMenuItemExportCarousel,
            this.toolStripSeparator3,
            this.toolStripMenuItemDeleteQuestions});
            this.toolStripMenuItemAddRange.Font = new System.Drawing.Font("Tahoma", 8.336843F);
            this.toolStripMenuItemAddRange.Name = "toolStripMenuItemAddRange";
            this.toolStripMenuItemAddRange.Size = new System.Drawing.Size(49, 23);
            this.toolStripMenuItemAddRange.Text = "Menu";
            // 
            // toolStripMenuItemEditQuestions
            // 
            this.toolStripMenuItemEditQuestions.Font = new System.Drawing.Font("Tahoma", 8.336843F);
            this.toolStripMenuItemEditQuestions.Name = "toolStripMenuItemEditQuestions";
            this.toolStripMenuItemEditQuestions.Size = new System.Drawing.Size(223, 22);
            this.toolStripMenuItemEditQuestions.Text = "[Edytuj] Pytania";
            this.toolStripMenuItemEditQuestions.Click += new System.EventHandler(this.toolStripMenuItemEditQuestions_Click);
            // 
            // toolStripMenuItemCreateDB
            // 
            this.toolStripMenuItemCreateDB.Font = new System.Drawing.Font("Tahoma", 8.336843F);
            this.toolStripMenuItemCreateDB.Name = "toolStripMenuItemCreateDB";
            this.toolStripMenuItemCreateDB.Size = new System.Drawing.Size(223, 22);
            this.toolStripMenuItemCreateDB.Text = "[Utwórz] Nową bazę pytań";
            this.toolStripMenuItemCreateDB.Click += new System.EventHandler(this.toolStripMenuItemCreateDB_Click);
            // 
            // toolStripMenuItemAdd
            // 
            this.toolStripMenuItemAdd.Name = "toolStripMenuItemAdd";
            this.toolStripMenuItemAdd.Size = new System.Drawing.Size(223, 22);
            this.toolStripMenuItemAdd.Text = "[Scal] Dwie bazy";
            this.toolStripMenuItemAdd.Click += new System.EventHandler(this.toolStripMenuItemAdd_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(220, 6);
            // 
            // toolStripMenuItemOK
            // 
            this.toolStripMenuItemOK.Font = new System.Drawing.Font("Tahoma", 8.336843F);
            this.toolStripMenuItemOK.Name = "toolStripMenuItemOK";
            this.toolStripMenuItemOK.Size = new System.Drawing.Size(223, 22);
            this.toolStripMenuItemOK.Text = "[Szukaj] Pytań";
            this.toolStripMenuItemOK.Click += new System.EventHandler(this.toolStripMenuItemOK_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(220, 6);
            // 
            // toolStripMenuItemExport
            // 
            this.toolStripMenuItemExport.Name = "toolStripMenuItemExport";
            this.toolStripMenuItemExport.Size = new System.Drawing.Size(223, 22);
            this.toolStripMenuItemExport.Text = "[Export] Pytań";
            this.toolStripMenuItemExport.Click += new System.EventHandler(this.toolStripMenuItemExport_Click);
            // 
            // toolStripMenuItemExportCarousel
            // 
            this.toolStripMenuItemExportCarousel.Name = "toolStripMenuItemExportCarousel";
            this.toolStripMenuItemExportCarousel.Size = new System.Drawing.Size(223, 22);
            this.toolStripMenuItemExportCarousel.Text = "[Export] Pytań Karuzela";
            this.toolStripMenuItemExportCarousel.Click += new System.EventHandler(this.toolStripMenuItemExportCarousel_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(220, 6);
            // 
            // toolStripMenuItemDeleteQuestions
            // 
            this.toolStripMenuItemDeleteQuestions.Name = "toolStripMenuItemDeleteQuestions";
            this.toolStripMenuItemDeleteQuestions.Size = new System.Drawing.Size(223, 22);
            this.toolStripMenuItemDeleteQuestions.Text = "[Usuń] Pytania - oznaczone";
            this.toolStripMenuItemDeleteQuestions.Click += new System.EventHandler(this.toolStripMenuItemDeleteQuestions_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Enabled = false;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(46, 23);
            this.toolStripMenuItem1.Text = "baza:";
            // 
            // toolStripTextBoxDbFile
            // 
            this.toolStripTextBoxDbFile.Name = "toolStripTextBoxDbFile";
            this.toolStripTextBoxDbFile.Size = new System.Drawing.Size(320, 23);
            // 
            // toolStripMenuItemSelectDb
            // 
            this.toolStripMenuItemSelectDb.Name = "toolStripMenuItemSelectDb";
            this.toolStripMenuItemSelectDb.Size = new System.Drawing.Size(81, 23);
            this.toolStripMenuItemSelectDb.Text = "[...] Wybierz";
            this.toolStripMenuItemSelectDb.ToolTipText = "Wybierz bazę";
            this.toolStripMenuItemSelectDb.Click += new System.EventHandler(this.toolStripMenuItemSelectDb_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(74, 23);
            this.toolStripMenuItem3.Text = "O aplikacji";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripMenuItemLoad
            // 
            this.toolStripMenuItemLoad.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripMenuItemLoad.Name = "toolStripMenuItemLoad";
            this.toolStripMenuItemLoad.Size = new System.Drawing.Size(85, 23);
            this.toolStripMenuItemLoad.Text = "[OK] Pobierz";
            this.toolStripMenuItemLoad.ToolTipText = "Pobierz pytania z bazy";
            this.toolStripMenuItemLoad.Click += new System.EventHandler(this.toolStripMenuItemLoad_Click);
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(120, 23);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripMenuItem2.Enabled = false;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(45, 23);
            this.toolStripMenuItem2.Text = "Tryb:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Sqlite| *.db";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeView1.Location = new System.Drawing.Point(0, 29);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(101, 640);
            this.treeView1.TabIndex = 4;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            this.treeView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeView1_KeyDown);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Sqlite| *.db";
            // 
            // saveFileDialog2
            // 
            this.saveFileDialog2.Filter = "HTML| *.html";
            // 
            // ParentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1192, 698);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(800, 640);
            this.Name = "ParentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Exam";
            this.Load += new System.EventHandler(this.ParentForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSelectDb;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        public System.Windows.Forms.ToolStripTextBox toolStripTextBoxDbFile;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemLoad;
        public System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        internal System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAddRange;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemEditQuestions;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCreateDB;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripStatusLabel timeLabel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOK;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAdd;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemExport;
        private System.Windows.Forms.SaveFileDialog saveFileDialog2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemExportCarousel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDeleteQuestions;
    }
}

