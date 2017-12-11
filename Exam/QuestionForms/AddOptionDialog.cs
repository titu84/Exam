using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exam.QuestionForms
{
    public partial class AddOptionDialog : Form
    {
        public AddOptionDialog()
        {
            InitializeComponent();
        }
        
        public string resultStr { get; internal set; }
        private void button1_Click(object sender, EventArgs e)
        {           
            if (String.IsNullOrEmpty(tb.Text))
            {
                MessageBox.Show("Wprowadź jakąś watrość.");
                tb.Focus();
                this.DialogResult = DialogResult.None;
            }
            resultStr = tb.Text;
        }

        private void tb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (int)Keys.Enter)
            {
                button1.PerformClick();
            }
        }
    }
}
