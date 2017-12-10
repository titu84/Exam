using Exam.QuestionForms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

namespace Exam
{
    public partial class DeleteRangeForm : Form
    {
        public DeleteRangeForm(string path, List<int> markedQuestions)
        {
            if (path.Length == 0)
            {
                MessageBox.Show("Problem z przekazanym parametrem path");
                Close();
            }
            InitializeComponent();
            this.path = path;
            this.markedQuestions = markedQuestions;
        }
        string path;
        List<int> markedQuestions;
        List<long> ids = new List<long>();
        private void DeleteRangeForm_Load(object sender, EventArgs e)
        {
            loadQuestions();
        }

        private void loadQuestions()
        {
            clb1.Items.Clear();
            cb1.Checked = false;
            try
            {
                using (Repository r = new Repository(path))
                {
                    foreach (var item in r.GetQuestions(false))
                    {
                        clb1.Items.Add(item.ID.ToString());
                    }
                }
                foreach (var marked in markedQuestions)
                {
                    int id = clb1.Items.IndexOf(marked.ToString());
                    if (id != -1)
                        clb1.SetItemChecked(id, true);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Nie udało się pobrać pytań\n" + exc.Message);
            }
        }

        private void cb1_CheckedChanged(object sender, EventArgs e)
        {
            if (cb1.Checked)
            {
                for (int i = 0; i < clb1.Items.Count; i++)
                {
                    clb1.SetItemChecked(i, true);
                }
            }
            else
            {
                for (int i = 0; i < clb1.Items.Count; i++)
                {
                    clb1.SetItemChecked(i, false);
                }
            }
        }

        private void btnDeleteChecked_Click(object sender, EventArgs e)
        {
            deleteQuestions(true);
        }

        private void btnDeleteNotChecked_Click(object sender, EventArgs e)
        {
            deleteQuestions(false);
        }

        private void deleteQuestions(bool checkedQuestions)
        {
            getIds();
            using (Repository r = new Repository(path))
            {
                r.Delete(ids, checkedQuestions);
                markedQuestions.Clear();
                loadQuestions();
                MessageBox.Show("OK");
            }
        }

        void getIds()
        {
            ids.Clear();
            foreach (var item in clb1.CheckedItems)
            {
                ids.Add(Convert.ToInt64(item));
            }
        }
    }
}
