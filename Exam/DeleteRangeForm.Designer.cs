namespace Exam
{
    partial class DeleteRangeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeleteRangeForm));
            this.btnDeleteNotChecked = new System.Windows.Forms.Button();
            this.btnDeleteChecked = new System.Windows.Forms.Button();
            this.clb1 = new System.Windows.Forms.CheckedListBox();
            this.cb1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnDeleteNotChecked
            // 
            this.btnDeleteNotChecked.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteNotChecked.Location = new System.Drawing.Point(159, 545);
            this.btnDeleteNotChecked.Name = "btnDeleteNotChecked";
            this.btnDeleteNotChecked.Size = new System.Drawing.Size(187, 23);
            this.btnDeleteNotChecked.TabIndex = 9;
            this.btnDeleteNotChecked.Text = "pozostaw zaznaczone";
            this.btnDeleteNotChecked.UseVisualStyleBackColor = true;
            this.btnDeleteNotChecked.Click += new System.EventHandler(this.btnDeleteNotChecked_Click);
            // 
            // btnDeleteChecked
            // 
            this.btnDeleteChecked.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteChecked.Location = new System.Drawing.Point(159, 505);
            this.btnDeleteChecked.Name = "btnDeleteChecked";
            this.btnDeleteChecked.Size = new System.Drawing.Size(187, 23);
            this.btnDeleteChecked.TabIndex = 10;
            this.btnDeleteChecked.Text = "usuń zaznaczone";
            this.btnDeleteChecked.UseVisualStyleBackColor = true;
            this.btnDeleteChecked.Click += new System.EventHandler(this.btnDeleteChecked_Click);
            // 
            // clb1
            // 
            this.clb1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.clb1.CheckOnClick = true;
            this.clb1.FormattingEnabled = true;
            this.clb1.Location = new System.Drawing.Point(12, 42);
            this.clb1.Name = "clb1";
            this.clb1.Size = new System.Drawing.Size(126, 529);
            this.clb1.TabIndex = 11;
            // 
            // cb1
            // 
            this.cb1.AutoSize = true;
            this.cb1.Location = new System.Drawing.Point(12, 13);
            this.cb1.Name = "cb1";
            this.cb1.Size = new System.Drawing.Size(125, 19);
            this.cb1.TabIndex = 12;
            this.cb1.Text = "Zaznacz wszystkie";
            this.cb1.UseVisualStyleBackColor = true;
            this.cb1.CheckedChanged += new System.EventHandler(this.cb1_CheckedChanged);
            // 
            // DeleteRangeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 580);
            this.Controls.Add(this.cb1);
            this.Controls.Add(this.clb1);
            this.Controls.Add(this.btnDeleteChecked);
            this.Controls.Add(this.btnDeleteNotChecked);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(250, 250);
            this.Name = "DeleteRangeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Oznaczone pytania";
            this.Load += new System.EventHandler(this.DeleteRangeForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnDeleteNotChecked;
        private System.Windows.Forms.Button btnDeleteChecked;
        private System.Windows.Forms.CheckedListBox clb1;
        private System.Windows.Forms.CheckBox cb1;
    }
}