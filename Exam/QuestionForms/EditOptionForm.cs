using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Exam.QuestionForms
{
    public partial class EditOptionForm : Exam.QuestionForms.AddOptionDialog
    {
        public EditOptionForm()
        {
            InitializeComponent();
        }       
        private void EditOptionForm_Load(object sender, EventArgs e)
        {
            button1.Text = "Zapisz";
            Text = "Edytuj";
            tb.Text = resultStr;         
        }

        private void EditOptionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            resultStr = tb.Text;
        }
    }
}
