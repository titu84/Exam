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
    public partial class Type5q
        : UserControl
    {
        public Type5q(bool nd = true)
        {
            allowDoubles = nd;
            InitializeComponent();
        }   
        public DbQuestion q;
        bool allowDoubles;
        public string a; // Opcje
        public string b; // Opcje
        public string h; // Opcje
        public List<object> items1 = new List<object>();
        public List<object> items2 = new List<object>();
        private void groupBox1_Leave(object sender, EventArgs e)
        {
            go(); //
        }
        private void go()
        {
            q = new DbQuestion();
            q.Type = allowDoubles == true ? (short)5 : (short)6;
            q.ID = -1;
            q.A = listBox1.Items == null ? "" : concateArray(listBox1.Items);
            q.B = listBox2.Items == null ? "" : concateArray(listBox2.Items);
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
        private void Type5q_Load(object sender, EventArgs e)
        {
            load();
            if (!allowDoubles)
            {
                btnDown1.Enabled = false;
                btnUp1.Enabled = false;
            }
        }

        private void load()
        {
            if (q != null)
            {
                items1 = splitArray(q.A);
                items2 = splitArray(q.B);
                listBox1.Items.Clear();
                foreach (var item in items1)
                {
                    listBox1.Items.Add(item.ToString().ReplaceApostropheToSymbol());
                }
                listBox2.Items.Clear();
                foreach (var item in items2)
                {
                    listBox2.Items.Add(item.ToString().ReplaceApostropheToSymbol());
                }
            }
            else
            {
                try
                {
                    listBox1.Items.Clear();
                    listBox2.Items.Clear();
                    if (!allowDoubles)
                        items1 = splitArray(h);
                    else
                    {                       
                        try
                        {
                            items1.AddRange(splitArray(a));
                        }
                        catch {
                        }
                        try
                        {
                            items1.AddRange(splitArray(b));
                        }
                        catch {
                        }                       
                        items1 = items1.Distinct().OrderBy(a => a).ToList();
                    }
                    foreach (var item in items1)
                    {
                        listBox1.Items.Add(item.ToString().ReplaceApostropheToSymbol());
                    }
                }
                catch
                {
                }
            }
        }


        private void setOptionToListBox(ListBox from, ListBox to, bool? remove = null, bool? add = null)
        {
            if (allowDoubles)
            {
                if (from.Items.Count == 0 || from.SelectedIndex < 0)
                    return;
                to.Items.Add(from.Items[from.SelectedIndex]);
                from.Items.Remove(from.Items[from.SelectedIndex]);
            }
            else
            {
                if (from.Items.Count == 0 || from.SelectedIndex < 0)
                    return;
                if (add == true)
                    to.Items.Add(from.Items[from.SelectedIndex]);
                if (remove == true)
                    from.Items.Remove(from.Items[from.SelectedIndex]);
            }
        }
        private void btnLeft_Click(object sender, EventArgs e)
        {
            if (allowDoubles)
                setOptionToListBox(listBox2, listBox1);
            else
                setOptionToListBox(listBox2, listBox1, remove: true, add: false);

            listBox2.SelectedIndex = -1;
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            if (allowDoubles)
                setOptionToListBox(listBox1, listBox2);
            else
                setOptionToListBox(listBox1, listBox2, remove: false, add: true);

            listBox1.SelectedIndex = -1;
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

        private void listBox1_MouseEnter(object sender, EventArgs e)
        {
            showTooltip(listBox1);
        }

        private void showTooltip(ListBox lb)
        {
            StringBuilder options = new StringBuilder();
            foreach (var item in lb.Items)
            {
                options.AppendLine(item.ToString().ReplaceApostropheToSymbol());
            }
            toolTip1.Show(options.ToString(), lb);
        }

        private void listBox2_MouseEnter(object sender, EventArgs e)
        {
            showTooltip(listBox2);
        }

        private void listBox1_MouseLeave(object sender, EventArgs e)
        {
            toolTip1.Hide(listBox1);
        }

        private void listBox2_MouseLeave(object sender, EventArgs e)
        {
            toolTip1.Hide(listBox2);
        }
    }
}
