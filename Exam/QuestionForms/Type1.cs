using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exam.QuestionForms
{
    public partial class Type1 : UserControl
    {
        public Type1()
        {
            InitializeComponent();
        }
        public DbQuestion q;     
        private void rbTrue_CheckedChanged(object sender, EventArgs e)
        {
            go();
        }
        private void rbFalse_CheckedChanged(object sender, EventArgs e)
        {
            go();
        }
        private void go()
        {           
            q = new DbQuestion();
            q.Type = 1;
            q.ID = -1;
            if (rbTrue.Checked)
            {
                q.A = "1";
                q.B = null;
            }
            else
            {
                q.A = null;
                q.B = "1";
            }
        }

        private void Type1_Load(object sender, EventArgs e)
        {
            if (q != null)
            {
                if (q.A == "1")
                    rbTrue.Checked = true;
                else if (q.B == "1")
                    rbFalse.Checked = true;
            }
        }
    }
}
