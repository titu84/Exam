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
    public partial class Type4q : UserControl
    {
        public Type4q()
        {
            InitializeComponent();
        }
        public DbQuestion q;
        public string h; // Opcje
        private void groupBox1_Leave(object sender, EventArgs e)
        {
            go();
        }
        private void go()
        {
            q = new DbQuestion();
            q.Type = 4;
            q.ID = -1;
            q.A = A.Text == "_" || A.Text == " " ? null: A.Text.ReplaceApostropheToSymbol();
            q.B = B.Text == "_" || B.Text == " " ? null: B.Text.ReplaceApostropheToSymbol();
            q.C = C.Text == "_" || C.Text == " " ? null: C.Text.ReplaceApostropheToSymbol();
            q.D = D.Text == "_" || D.Text == " " ? null: D.Text.ReplaceApostropheToSymbol();
            q.E = E.Text == "_" || E.Text == " " ? null: E.Text.ReplaceApostropheToSymbol();
            q.F = F.Text == "_" || F.Text == " " ? null: F.Text.ReplaceApostropheToSymbol();
            q.G = G.Text == "_" || G.Text == " " ? null: G.Text.ReplaceApostropheToSymbol();
            q.HH = HH.Text == "_" || HH.Text == " " ? null: HH.Text.ReplaceApostropheToSymbol();
            q.I = I.Text == "_" || I.Text == " " ? null: I.Text.ReplaceApostropheToSymbol();
            q.J = J.Text == "_" || J.Text == " " ? null: J.Text.ReplaceApostropheToSymbol();
            q.K = K.Text == "_" || K.Text == " " ? null: K.Text.ReplaceApostropheToSymbol();
        }

        private void Type4_Load(object sender, EventArgs e)
        {
            if (q != null)
            {                
                foreach (Control c in groupBox1.Controls)
                {
                    if (c is ComboBox)
                    {
                        ((ComboBox)c).Items.Clear();
                        foreach (var item in splitArray(q.H))
                        {
                            ((ComboBox)c).Items.Add(item);
                        }
                    }
                }
                A.Text = q.A == null ? "" : q.A;
                B.Text = q.B == null ? "" : q.B;
                C.Text = q.C == null ? "" : q.C;
                D.Text = q.D == null ? "" : q.D;
                E.Text = q.E == null ? "" : q.E;
                F.Text = q.F == null ? "" : q.F;
                G.Text = q.G == null ? "" : q.G;
                HH.Text = q.HH == null ? "" : q.HH;
                I.Text = q.I == null ? "" : q.I;
                J.Text = q.J == null ? "" : q.J;
                K.Text = q.K == null ? "" : q.K;
            }
            else
            {
                foreach (Control c in groupBox1.Controls)
                {
                    if (c is ComboBox)
                    {
                        ((ComboBox)c).Items.Clear();
                        foreach (var item in splitArray(h))
                        {
                            ((ComboBox)c).Items.Add(item);
                        }
                    }
                }
            }
        }
        List<object> splitArray(string str)
        {
            List<object> l = new List<object>();
            try
            {
                string[] temp = str.Split(';').ToArray();
                foreach (var item in temp)
                {
                    l.Add(item.ReplaceApostropheToSymbol());
                }
            }
            catch
            {
                l.Add(str);
            }
            return l;
        }

        private void A_DropDown(object sender, EventArgs e)
        {
            setDropDown(sender);
        }
       
        private void B_DropDown(object sender, EventArgs e)
        {
            setDropDown(sender);
        }

        private void C_DropDown(object sender, EventArgs e)
        {
            setDropDown(sender);
        }

        private void D_DropDown(object sender, EventArgs e)
        {
            setDropDown(sender);
        }

        private void E_DropDown(object sender, EventArgs e)
        {
            setDropDown(sender);
        }

        private void F_DropDown(object sender, EventArgs e)
        {
            setDropDown(sender);
        }

        private void G_DropDown(object sender, EventArgs e)
        {
            setDropDown(sender);
        }
        private void HH_DropDown(object sender, EventArgs e)
        {
            setDropDown(sender);
        }

        private void I_DropDown(object sender, EventArgs e)
        {
            setDropDown(sender);
        }

        private void J_DropDown(object sender, EventArgs e)
        {
            setDropDown(sender);
        }

        private void K_DropDown(object sender, EventArgs e)
        {
            setDropDown(sender);
        }
        void setDropDown(object sender)
        {
            ComboBox senderComboBox = (ComboBox)sender;
            int width = senderComboBox.DropDownWidth;
            Graphics g = senderComboBox.CreateGraphics();
            Font font = senderComboBox.Font;
            int vertScrollBarWidth =
                (senderComboBox.Items.Count > senderComboBox.MaxDropDownItems)
                ? SystemInformation.VerticalScrollBarWidth : 0;

            int newWidth;
            foreach (string s in ((ComboBox)sender).Items)
            {
                newWidth = (int)g.MeasureString(s, font).Width
                    + vertScrollBarWidth;
                if (width < newWidth)
                {
                    width = newWidth;
                }
            }
            senderComboBox.DropDownWidth = width;
        }
    }
}
