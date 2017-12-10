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
    public partial class Type2 : UserControl
    {
        public Type2()
        {
            InitializeComponent();
        }
        public DbQuestion q;     
        private void rbA_CheckedChanged(object sender, EventArgs e)
        {
            go();
        }
        private void rbB_CheckedChanged(object sender, EventArgs e)
        {
            go();
        }
        private void rbC_CheckedChanged(object sender, EventArgs e)
        {
            go();
        }

        private void rbD_CheckedChanged(object sender, EventArgs e)
        {
            go();
        }
        private void rbE_CheckedChanged(object sender, EventArgs e)
        {
            go();
        }
        private void fbF_CheckedChanged(object sender, EventArgs e)
        {
            go();
        }

        private void rbG_CheckedChanged(object sender, EventArgs e)
        {
            go();
        }

        private void rbH_CheckedChanged(object sender, EventArgs e)
        {
            go();
        }

        private void rbI_CheckedChanged(object sender, EventArgs e)
        {
            go();
        }

        private void rbJ_CheckedChanged(object sender, EventArgs e)
        {
            go();
        }

        private void rbK_CheckedChanged(object sender, EventArgs e)
        {
            go();
        }
        private void go()
        {
            q = new DbQuestion();
            q.Type = 2;
            q.ID = -1;
            if (rbA.Checked)
            {
                q.A = "1";
                q.B = null;
                q.C = null;
                q.D = null;
                q.E = null;
                q.F = null;
                q.G = null;
                q.H = null;
                q.I = null;
                q.J = null;
                q.K = null;
            }
            else if (rbB.Checked)
            {
                q.A = null;
                q.B = "1";
                q.C = null;
                q.D = null;
                q.E = null;
                q.F = null;
                q.G = null;
                q.H = null;
                q.I = null;
                q.J = null;
                q.K = null;
            }
            else if (rbC.Checked)
            {
                q.A = null;
                q.B = null;
                q.C = "1";
                q.D = null;
                q.E = null;
                q.F = null;
                q.G = null;
                q.H = null;
                q.I = null;
                q.J = null;
                q.K = null;
            }
            else if (rbD.Checked)
            {
                q.A = null;
                q.B = null;
                q.C = null;
                q.D = "1";
                q.E = null;
                q.F = null;
                q.G = null;
                q.H = null;
                q.I = null;
                q.J = null;
                q.K = null;
            }
            else if (rbE.Checked)
            {
                q.A = null;
                q.B = null;
                q.C = null;
                q.D = null;
                q.E = "1";
                q.F = null;
                q.G = null;
                q.H = null;
                q.I = null;
                q.J = null;
                q.K = null;
            }
            else if (rbF.Checked)
            {
                q.A = null;
                q.B = null;
                q.C = null;
                q.D = null;
                q.E = null;
                q.F = "1";
                q.G = null;
                q.H = null;
                q.I = null;
                q.J = null;
                q.K = null;
            }
            else if (rbG.Checked)
            {
                q.A = null;
                q.B = null;
                q.C = null;
                q.D = null;
                q.E = null;
                q.F = null;
                q.G = "1";
                q.H = null;
                q.I = null;
                q.J = null;
                q.K = null;
            }
            else if (rbH.Checked)
            {
                q.A = null;
                q.B = null;
                q.C = null;
                q.D = null;
                q.E = null;
                q.F = null;
                q.G = null;
                q.H = "1";
                q.I = null;
                q.J = null;
                q.K = null;
            }
            else if (rbI.Checked)
            {
                q.A = null;
                q.B = null;
                q.C = null;
                q.D = null;
                q.E = null;
                q.F = null;
                q.G = null;
                q.H = null;
                q.I = "1";
                q.J = null;
                q.K = null;
            }
            else if (rbJ.Checked)
            {
                q.A = null;
                q.B = null;
                q.C = null;
                q.D = null;
                q.E = null;
                q.F = null;
                q.G = null;
                q.H = null;
                q.I = null;
                q.J = "1";
                q.K = null;
            }
            else if (rbK.Checked)
            {
                q.A = null;
                q.B = null;
                q.C = null;
                q.D = null;
                q.E = null;
                q.F = null;
                q.G = null;
                q.H = null;
                q.I = null;
                q.J = null;
                q.K = "1";
            }
        }

        private void Type2_Load(object sender, EventArgs e)
        {
            if (q != null)
            {
                if (q.A == "1")
                    rbA.Checked = true;
                else if (q.B == "1")
                    rbB.Checked = true;
                else if (q.C == "1")
                    rbC.Checked = true;
                else if (q.D == "1")
                    rbD.Checked = true;
                else if (q.E == "1")
                    rbE.Checked = true;
                else if (q.F == "1")
                    rbF.Checked = true;
                else if (q.G == "1")
                    rbG.Checked = true;
                else if (q.H == "1")
                    rbH.Checked = true;
                else if (q.I == "1")
                    rbI.Checked = true;
                else if (q.J == "1")
                    rbJ.Checked = true;
                else if (q.K == "1")
                    rbK.Checked = true;
            }
        }

    }
}
