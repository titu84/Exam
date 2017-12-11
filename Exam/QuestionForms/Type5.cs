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
    public partial class Type5
        : UserControl
    {
        public Type5()
        {
            InitializeComponent();
        }
        public DbQuestion q;
        bool allowDoubles = false;
        public List<object> items = new List<object>();
        public List<object> items1 = new List<object>();
        public List<object> items2 = new List<object>();
        private void groupBox1_Leave(object sender, EventArgs e)
        {
            go(); //

        }
        private void go()
        {
            q = new DbQuestion();
            q.Type = cbDoubles.Checked == false ? (short)5 : (short)6;
            q.ID = -1;
            q.A = listBox1.Items == null ? "" : concateArray(listBox1.Items).ReplaceSymbolToApostrophe();
            q.B = listBox2.Items == null ? "" : concateArray(listBox2.Items).ReplaceSymbolToApostrophe();
            q.C = cbDoubles.Checked ? "1" : "0";
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
        private void Type5_Load(object sender, EventArgs e)
        {
            load();
        }

        private void load()
        {
            if (q != null)
            {
                items = splitArray(q.H);
                items1 = splitArray(q.A)[0] as string == "" ? null : splitArray(q.A);
                items2 = splitArray(q.B)[0] as string == "" ? null : splitArray(q.B);
                allowDoubles = q.C == "1" ? true : false;
                cbDoubles.CheckState = allowDoubles == true ? CheckState.Checked : CheckState.Unchecked;
                listOptions.Items.Clear();
                foreach (var item in items)
                {
                    listOptions.Items.Add(item.ToString().ReplaceApostropheToSymbol());
                }
                listBox1.Items.Clear();
                if (items1 != null)
                    foreach (var item in items1)
                    {
                        if (item != null)
                            listBox1.Items.Add(item.ToString().ReplaceApostropheToSymbol());
                    }
                listBox2.Items.Clear();
                if (items2 != null)
                    foreach (var item in items2)
                    {
                        if (item != null)
                            listBox2.Items.Add(item.ToString().ReplaceApostropheToSymbol());
                    }
            }
            else
            {
                try
                {
                    items = splitArray(ConfigurationManager.AppSettings["options"]);
                    listOptions.Items.Clear();
                    foreach (var item in items)
                    {
                        if (item != null)
                            listOptions.Items.Add(item.ToString().ReplaceApostropheToSymbol());
                    }
                    listBox1.Items.Clear();
                    listBox2.Items.Clear();
                }
                catch
                {
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
            listOptions.Items.Remove(listOptions.SelectedItem);
            listBox1.Items.Clear();
            listBox2.Items.Clear();
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
            editOption();
        }

        private void listOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listOptions.SelectedItems.Count > 0)
            {
                btnDelete.Enabled = true;
                btnEdit.Enabled = true;
                btnLeft1.Enabled = true;
                btnRight2.Enabled = true;
            }
            else
            {
                btnDelete.Enabled = false;
                btnEdit.Enabled = false;
                btnLeft1.Enabled = false;
                btnRight2.Enabled = false;
            }
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
                    listBox1.Items.Clear();
                    listBox2.Items.Clear();
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
            StringBuilder options = new StringBuilder();
            foreach (var item in listOptions.Items)
            {
                options.AppendLine(item.ToString());
            }
        }

        private void listOptions_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                btnDelete.PerformClick();
        }
        private void seonOptionToListBox(ListBox lb)
        {
            if (listOptions.Items.Count == 0)
                return;
            if (listOptions.SelectedIndex < 0)
            {
                MessageBox.Show("Zaznacz opcję na liście.");
                return;
            }
            if (cbDoubles.Checked)
                lb.Items.Add(listOptions.Items[listOptions.SelectedIndex]);
            else
            {
                ListBox tempLb = new ListBox();
                tempLb.Items.AddRange(listBox1.Items);
                tempLb.Items.AddRange(listBox2.Items);
                foreach (var item in tempLb.Items)
                {
                    if (item == listOptions.Items[listOptions.SelectedIndex])
                    {
                        MessageBox.Show("Item istnieje na listach, zaznacz opcję umożliwiającą dublowanie");
                        return;
                    }
                }
                lb.Items.Add(listOptions.Items[listOptions.SelectedIndex]);
            }
        }
        private void btnLeft1_Click(object sender, EventArgs e)
        {
            seonOptionToListBox(listBox1);
        }

        private void btnRight2_Click(object sender, EventArgs e)
        {
            seonOptionToListBox(listBox2);
        }
        private void changePosition(ListBox lb, bool up)
        {
            if (lb.Items.Count == 0)
                return;
            if (lb.SelectedIndex < 0)
            {
                MessageBox.Show("Zaznacz opcję na liście.");
                return;
            }
            int currentIndex = lb.SelectedIndex;
            int prevIndex = lb.SelectedIndex - 1;
            if (up)
            {
                if (currentIndex == 0)
                    return;
                if (currentIndex > 0)
                {
                    object i = lb.Items[currentIndex];
                    object j = lb.Items[currentIndex - 1];
                    lb.Items[currentIndex - 1] = i;
                    lb.Items[currentIndex] = j;
                    lb.SetSelected(currentIndex - 1, true);
                }
            }
            if (!up)
            {
                if (currentIndex == lb.Items.Count - 1)
                    return;
                if (currentIndex + 1 < lb.Items.Count)
                {
                    object i = lb.Items[currentIndex];
                    object j = lb.Items[currentIndex + 1];
                    lb.Items[currentIndex + 1] = i;
                    lb.Items[currentIndex] = j;
                    lb.SetSelected(currentIndex + 1, true);
                }
            }
        }
        private void btnUp1_Click(object sender, EventArgs e)
        {
            changePosition(listBox1, true);
        }

        private void btnDown1_Click(object sender, EventArgs e)
        {
            changePosition(listBox1, false);
        }

        private void btnUp2_Click(object sender, EventArgs e)
        {
            changePosition(listBox2, true);
        }

        private void btnDown2_Click(object sender, EventArgs e)
        {
            changePosition(listBox2, false);
        }

        private void cbDoubles_CheckedChanged(object sender, EventArgs e)
        {
            if (!cbDoubles.Checked)
            {
                listBox1.Items.Clear();
                listBox2.Items.Clear();
            }
            allowDoubles = cbDoubles.Checked;
        }

        private void btnRight1_Click(object sender, EventArgs e)
        {
            removeFromListBox(listBox1);
        }

        private void removeFromListBox(ListBox lb)
        {
            if (lb.SelectedIndex < 0)
            {
                MessageBox.Show("Zaznacz opcję na liście.");
                return;
            }
            lb.Items.Remove(lb.SelectedItem);
        }

        private void btnLeft2_Click(object sender, EventArgs e)
        {
            removeFromListBox(listBox2);
        }
    }
}
