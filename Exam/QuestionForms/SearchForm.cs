using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Exam.QuestionForms
{
    public partial class SearchForm : Exam.QuestionForms.AddOptionDialog
    {
        public SearchForm()
        {
            InitializeComponent();
        }

        private void SearchForm_Load(object sender, EventArgs e)
        {
            button1.Text = "Szukaj";
            Text = "Szukaj pytań";
        }
    }
}
