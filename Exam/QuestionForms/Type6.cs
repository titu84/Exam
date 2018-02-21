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
    public partial class Type6 : UserControl
    {
        public Type6()
        {
            InitializeComponent();
        }
        public DbQuestion q;     
       
        private void go()
        {
            q = new DbQuestion();
            q.Type = 7;
            q.ID = -1;
            q.A = tb.Text;          
        }

        private void Type6_Load(object sender, EventArgs e)
        {
            if (q != null)
            {
                tb.Text = q.A;
            }
        }

        private void tb_TextChanged(object sender, EventArgs e)
        {
            go();
        }
    }
}
