using Exam.QuestionForms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Exam
{
    public partial class AddRangeForm : Form
    {
        public AddRangeForm()
        {
            InitializeComponent();
        }       
        List<DbQuestion> list = new List<DbQuestion>();
        private void tbFrom_TextChanged(object sender, EventArgs e)
        {
            enableOkButton();
        }
        private void tbTo_TextChanged(object sender, EventArgs e)
        {
            enableOkButton();
        }
        private void enableOkButton()
        {
            if (tbFrom.Text.Length > 0 && tbTo.Text.Length > 0)
                btnOK.Enabled = true;
            else
                btnOK.Enabled = false;
        }
        private void btnFrom_Click(object sender, EventArgs e)
        {  
            DialogResult dialogFrom = openFileDialog1.ShowDialog();            
            if (dialogFrom == DialogResult.OK)
            {
                try
                {
                    tbFrom.Text = openFileDialog1.FileName;                   
                }
                catch (Exception)
                {
                    MessageBox.Show("Nie udało pobrać bazy 'Z'", "Uwaga!!!");
                    return;
                }               
            }
            openFileDialog1.FileName = "";        
        }

        private void btnTo_Click(object sender, EventArgs e)
        {
            DialogResult dialogTo = openFileDialog1.ShowDialog();
            if (dialogTo == DialogResult.OK)
            {
                try
                {
                    tbTo.Text = openFileDialog1.FileName;                   
                }
                catch (Exception)
                {
                    MessageBox.Show("Nie udało pobrać bazy 'DO'", "Uwaga!!!");
                    return;
                }
            }
            openFileDialog1.FileName = "";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {            
            btnOK.Enabled = false;
            try
            {
                Repository r = new Repository(tbFrom.Text);
                if (!r.CheckDB())
                {
                    MessageBox.Show("Nie aktualna baza - musisz ją zaktualizować.");
                    return;
                }
                List<short> ids = r.GetIds();
                //list = r.GetQuestions(false);
                //r.Dispose();
                Repository r1 = new Repository(tbTo.Text);
                if (!r1.CheckDB())
                {
                    MessageBox.Show("Nie aktualna baza - musisz ją zaktualizować.");
                    return;
                }
                foreach (var item in ids)
                    r1.Add(r.GetQuestion(item, true));
                MessageBox.Show("Dodawanie zakończone. Dodano " + ids.Count.ToString() + " pytań.", "OK.");
                btnOK.Enabled = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Nie udało dodać pytań", "Uwaga!!!");
                btnOK.Enabled = true;
                return;
            }
        }
    }
}
