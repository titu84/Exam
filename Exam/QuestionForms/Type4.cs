using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace Exam.QuestionForms
{
    public partial class Type4 : UserControl
    {
        public Type4()
        {
            InitializeComponent();
        }
              
        public DbQuestion q;
        public List<object> items = new List<object>();
        int[] indexes;
        private void groupBox1_Leave(object sender, EventArgs e)
        {
            go();
        }
        private void go()
        {
            q = new DbQuestion();
            q.Type = 4;
            q.ID = -1;
            q.A = A.SelectedItem == null ? "" : A.SelectedItem.ToString().ReplaceSymbolToApostrophe();
            q.B = B.SelectedItem == null ? "" : B.SelectedItem.ToString().ReplaceSymbolToApostrophe();
            q.C = C.SelectedItem == null ? "" : C.SelectedItem.ToString().ReplaceSymbolToApostrophe();
            q.D = D.SelectedItem == null ? "" : D.SelectedItem.ToString().ReplaceSymbolToApostrophe();
            q.E = E.SelectedItem == null ? "" : E.SelectedItem.ToString().ReplaceSymbolToApostrophe();
            q.F = F.SelectedItem == null ? "" : F.SelectedItem.ToString().ReplaceSymbolToApostrophe();
            q.G = G.SelectedItem == null ? "" : G.SelectedItem.ToString().ReplaceSymbolToApostrophe();
            q.HH = H.SelectedItem == null ? "" : H.SelectedItem.ToString().ReplaceSymbolToApostrophe();
            q.I = I.SelectedItem == null ? "" : I.SelectedItem.ToString().ReplaceSymbolToApostrophe();
            q.J = J.SelectedItem == null ? "" : J.SelectedItem.ToString().ReplaceSymbolToApostrophe();
            q.K = K.SelectedItem == null ? "" : K.SelectedItem.ToString().ReplaceSymbolToApostrophe();
            q.H = listOptions.Items == null ? "" : concateArray(listOptions.Items).ReplaceSymbolToApostrophe();

            load();
        }
        string concateArray(ListBox.ObjectCollection arr)
        {
            string result = "";
            if (arr.Count > 0)
                for (int i = 0; i < arr.Count; i++)
                {
                    if (i == arr.Count - 1)
                        result += arr[i].ToString();
                    else
                        result += arr[i].ToString() + ";";
                }
            return result;
        }
        List<object> splitArray(string str)
        {
            List<object> l = new List<object>();
            try
            {               
                string[] temp = str.Split(';').ToArray();
                foreach (var item in temp)
                {
                    l.Add(item);
                }
            }
            catch
            {
                l.Add(str);
            }
            return l;
        }
        private void Type4_Load(object sender, EventArgs e)
        {
            load();
        }

        private void load()
        {
            if (q != null)
            {               
                items = splitArray(q.H);
                listOptions.Items.Clear();
                foreach (var item in items)
                {
                    listOptions.Items.Add(item.ToString().ReplaceApostropheToSymbol());
                }
                indexes = new int[] { A.SelectedIndex, B.SelectedIndex, C.SelectedIndex, D.SelectedIndex, E.SelectedIndex, F.SelectedIndex, G.SelectedIndex, H.SelectedIndex, I.SelectedIndex, J.SelectedIndex, K.SelectedIndex };
                updateComboBoxes();
                A.SelectedItem = q.A == null ? "" : q.A.ReplaceApostropheToSymbol();
                B.SelectedItem = q.B == null ? "" : q.B.ReplaceApostropheToSymbol();
                C.SelectedItem = q.C == null ? "" : q.C.ReplaceApostropheToSymbol();
                D.SelectedItem = q.D == null ? "" : q.D.ReplaceApostropheToSymbol();
                E.SelectedItem = q.E == null ? "" : q.E.ReplaceApostropheToSymbol();
                F.SelectedItem = q.F == null ? "" : q.F.ReplaceApostropheToSymbol();
                G.SelectedItem = q.G == null ? "" : q.G.ReplaceApostropheToSymbol();
                H.SelectedItem = q.HH == null ? "" : q.H.ReplaceApostropheToSymbol();
                I.SelectedItem = q.I == null ? "" : q.I.ReplaceApostropheToSymbol();
                J.SelectedItem = q.J == null ? "" : q.J.ReplaceApostropheToSymbol();
                K.SelectedItem = q.K == null ? "" : q.K.ReplaceApostropheToSymbol();
            }
            else
            {
                try
                {
                    items = splitArray(ConfigurationManager.AppSettings["options"]);
                    listOptions.Items.Clear();
                    foreach (var item in items)
                    {
                        listOptions.Items.Add(item.ToString().ReplaceApostropheToSymbol());
                    }
                    updateComboBoxes();
                }
                catch {
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {            
            using (var form = new AddOptionDialog())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string val = form.resultStr;
                    listOptions.Items.Add(val.ReplaceApostropheToSymbol());
                    indexes = new int[] { A.SelectedIndex, B.SelectedIndex, C.SelectedIndex, D.SelectedIndex, E.SelectedIndex, F.SelectedIndex, G.SelectedIndex, H.SelectedIndex, I.SelectedIndex, J.SelectedIndex, K.SelectedIndex };
                    updateComboBoxes();
                }
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {           
            if (listOptions.SelectedIndex < 0)
            {
                MessageBox.Show("Zaznacz opcję na liście.");
                btnDelete.Enabled = false;
                btnEdit.Enabled = false;
                return;
            }
            indexes = new int[] { -1, -1, -1, -1, -1, -1, -1,-1,-1,-1,-1 };
            listOptions.Items.Remove(listOptions.SelectedItem);
            updateComboBoxes();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (listOptions.SelectedIndex < 0)
            {
                MessageBox.Show("Zaznacz opcję na liście.");
                btnDelete.Enabled = false;
                btnEdit.Enabled = false;
                return;
            }
            indexes = new int[] { A.SelectedIndex, B.SelectedIndex, C.SelectedIndex, D.SelectedIndex, E.SelectedIndex, F.SelectedIndex, G.SelectedIndex, H.SelectedIndex, I.SelectedIndex, J.SelectedIndex, K.SelectedIndex };
            editOption();
        }
        private void updateComboBoxes()
        {            
            items.Clear();
            foreach (var loi in listOptions.Items)
            {
                items.Add(loi);
            }
            foreach (Control c in groupBox1.Controls)
            {
                if (c is ComboBox)
                {
                    ((ComboBox)c).Items.Clear();
                    foreach (var item in items)
                    {
                        ((ComboBox)c).Items.Add(item.ToString().ReplaceApostropheToSymbol());
                    }
                }
            }
            try
            {
                A.SelectedIndex = indexes[0];
                B.SelectedIndex = indexes[1];
                C.SelectedIndex = indexes[2];
                D.SelectedIndex = indexes[3];
                E.SelectedIndex = indexes[4];
                F.SelectedIndex = indexes[5];
                G.SelectedIndex = indexes[6];
                H.SelectedIndex = indexes[7];
                I.SelectedIndex = indexes[8];
                J.SelectedIndex = indexes[9];
                K.SelectedIndex = indexes[10];
            }
            catch { 
            }
         
        }

        private void listOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listOptions.SelectedItems.Count > 0)
            {
                btnDelete.Enabled = true;
                btnEdit.Enabled = true;
            }
            else
            {
                btnDelete.Enabled = false;
                btnEdit.Enabled = false;
            }
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

        private void listOptions_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            editOption();
        }
     
        private void editOption()
        {
            if (listOptions.Items.Count == 0)
                return;          
            if (listOptions.SelectedIndex < 0)
            {
                MessageBox.Show("Zaznacz opcję na liście.");
                return;
            }
            using (var form = new EditOptionForm())
            {
                form.resultStr = listOptions.SelectedItem.ToString();
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    listOptions.Items[listOptions.SelectedIndex] = form.resultStr.ReplaceApostropheToSymbol(); 
                    updateComboBoxes();
                }
            }
        }

        private void listOptions_Leave(object sender, EventArgs e)
        {
            if (listOptions.SelectedIndex < 0)
            {
                btnDelete.Enabled = false;
                btnEdit.Enabled = false;
            }
        }

        private void listOptions_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.ToolTipTitle = "Wszystkie opcje";
            StringBuilder options = new StringBuilder();
            foreach (var item in listOptions.Items)
            {
                options.AppendLine(item.ToString());
            }
            toolTip1.Show(options.ToString(), listOptions);
        }

        private void listOptions_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)           
                btnDelete.PerformClick();         
        }
    }
}
