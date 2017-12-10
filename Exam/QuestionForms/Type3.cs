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
    public partial class Type3 : UserControl
    {
        public Type3()
        {
            InitializeComponent();
        }
        public DbQuestion q;
        private void groupBox1_Leave(object sender, EventArgs e)
        {
            go();
        }
        private void go()
        {
            q = new DbQuestion();
            q.Type = 3;
            q.ID = -1;
            if (rbA.Checked)
            {
                q.A = "1";             
            }
            if (rbB.Checked)
            {              
                q.B = "1";             
            }
            if (rbC.Checked)
            {
                q.C = "1";                
            }
            if (rbD.Checked)
            {               
                q.D = "1";             
            }
            if (rbE.Checked)
            {              
                q.E = "1";
            }
            if (rbF.Checked)
            {
                q.F = "1";
            }
            if (rbG.Checked)
            {
                q.G = "1";
            }
            if (rbH.Checked)
            {
                q.H = "1";
            }
            if (rbI.Checked)
            {
                q.I = "1";
            }
            if (rbJ.Checked)
            {
                q.J = "1";
            }
            if (rbK.Checked)
            {
                q.K = "1";
            }
        }

        private void Type3_Load(object sender, EventArgs e)
        {
            if (q != null)
            {
                if (q.A == "1")
                    rbA.Checked = true;
                if (q.B == "1")
                    rbB.Checked = true;
                if (q.C == "1")
                    rbC.Checked = true;
                if (q.D == "1")
                    rbD.Checked = true;
                if (q.E == "1")
                    rbE.Checked = true;
                if (q.F == "1")
                    rbF.Checked = true;
                if (q.G == "1")
                    rbG.Checked = true;
                if (q.H == "1")
                    rbH.Checked = true;
                if (q.I == "1")
                    rbI.Checked = true;
                if (q.J == "1")
                    rbJ.Checked = true;
                if (q.K == "1")
                    rbK.Checked = true;
            }
        }
    }
}
