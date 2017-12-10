using Exam.QuestionForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Exam;
using System.Windows.Forms;
using System.IO;

namespace Exam
{
    public partial class SubmitForm : Form
    {
        public SubmitForm()
        {
            InitializeComponent();
        }        
        private void buttonOK_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Zamknąć podsumowanie?", "Kończenie egzaminu", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {                
                Close();
            }
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            if (!String.IsNullOrEmpty(saveFileDialog1.FileName) && !String.IsNullOrEmpty(webBrowser1.Document.Body.OuterHtml))
            {
                try
                {
                    File.WriteAllText(saveFileDialog1.FileName, webBrowser1.Document.Body.OuterHtml, Encoding.GetEncoding(webBrowser1.Document.Encoding));
                    MessageBox.Show("Zapisano");
                }
                catch (Exception)
                {
                    MessageBox.Show("Nie udało się zapisać");
                }
            }           
        }
    }
}
