using Exam.QuestionForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exam
{
    public partial class EditQuestionsForm : Form
    {
        public EditQuestionsForm()
        {
            InitializeComponent();
        }
        Type1 type1 = new Type1();
        Type2 type2 = new Type2();
        Type3 type3 = new Type3();
        Type4 type4 = new Type4();
        Type5 type5 = new Type5();       
        Type6 type6 = new Type6();
        DbQuestion q = new DbQuestion();
        public string connStr;
        int lower = 50;
        string replace1 = "\n";
        string replace2 = "</br>";          
        Image image;
        int rtbW = 1073;
        int rtbH = 0;
        int pbW = 1047;
        int pbH = 0;
        private void cbQuestionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            setRtbLocation();
            richTextBox1.Text = richTextBox1.Text.ReplaceApostropheToSymbol();           
            switch (cbQuestionType.SelectedIndex)
            {
                case 0:
                    richTextBox1.Text = richTextBox1.Text.Replace(replace2, replace1);
                    goto default;
                //case 1:
                //    richTextBox1.Text = richTextBox1.Text.Replace(replace1, replace2);
                //    goto default;
                case 1:
                    labelDescription.Text = "Tekst dla wyszukiwarki";
                    btnBold.Visible = false;
                    btnGreen.Visible = false;
                    btnUnderlined.Visible = false;
                    btnLt.Visible = false;
                    btnGt.Visible = false;
                    btnReplaceLtGt.Visible = false;
                    btnItalic.Visible = false;
                    btnNbsp.Visible = false;
                    q.QType = 2; // obrazek   
                    using (Repository r = new Repository(connStr))
                    {
                        q.Image = r.loadImages(q.ID)[0];
                        q.ImageAlt = r.loadImages(q.ID)[1];
                    }
                    break;
                default:
                    labelDescription.Text = "Treść pytania";
                    btnBold.Visible = true;
                    btnGreen.Visible = true;
                    btnUnderlined.Visible = true;
                    btnLt.Visible = true;
                    btnGt.Visible = true;
                    btnReplaceLtGt.Visible = true;
                    btnItalic.Visible = true;
                    btnNbsp.Visible = true;
                    q.QType = 1; //tekstowe
                    break;
            }
        }

        private void setRtbLocation()
        {
            try
            {
                rtbW = this.Size.Width;
                rtbH = this.Size.Height - 20;
                if (cbQuestionType.SelectedIndex == 1) // obrazek
                {
                    richTextBox1.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
                    pictureBox1.Size = new Size(richTextBox1.Size.Width / 2, rtbH - 183);
                    pictureBox2.Size = new Size(richTextBox1.Size.Width / 2, rtbH - 183);
                    if (cbAnswerType.SelectedIndex == 3 || cbAnswerType.SelectedIndex == 4) // Jeśli Dopasowanie to jeszcze mniejszy.
                    {
                        pictureBox1.Size = new Size(pictureBox1.Size.Width, pictureBox1.Size.Height - 85);
                        pictureBox2.Size = new Size(pictureBox2.Size.Width, pictureBox2.Size.Height - 85);
                    }
                    rtbH = 180;
                    btnImageAdd.Visible = true;
                    btnImageAltAdd.Visible = true;
                    pictureBox1.Visible = true;
                    pictureBox2.Visible = true;
                    lower = 53;
                }
                else
                {
                    richTextBox1.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;
                    pictureBox1.Size = new Size(richTextBox1.Size.Width / 2, 0);
                    pictureBox2.Size = new Size(richTextBox1.Size.Width / 2, 0);
                    if (cbAnswerType.SelectedIndex == 3 || cbAnswerType.SelectedIndex == 4) // Jeśli Dopasowanie to jeszcze mniejszy.
                        rtbH = rtbH - 85;
                    btnImageAdd.Visible = false;
                    btnImageAltAdd.Visible = false;
                    pictureBox1.Visible = false;
                    pictureBox2.Visible = false;
                    lower = 50;
                }
                richTextBox1.Size = new System.Drawing.Size(rtbW - 32, rtbH - 125);
            }
            catch { }
        }

        private void cbAnswerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                type1.Dispose();
                type2.Dispose();
                type3.Dispose();
                type4.Dispose();
                type5.Dispose();
                type6.Dispose();
                Point point = new Point(250, richTextBox1.Size.Height + lower);
                AnchorStyles anchor = AnchorStyles.Bottom | AnchorStyles.Left;
                setRtbLocation();
                switch (cbAnswerType.SelectedIndex)
                {
                    case 0:
                        type1 = new Type1();
                        Controls.Add(type1);
                        type1.Location = new Point(250, richTextBox1.Size.Height + pictureBox1.Size.Height + lower);
                        type1.Anchor = anchor;
                        break;
                    case 1:
                        type2 = new Type2();
                        Controls.Add(type2);
                        type2.Location = new Point(250, richTextBox1.Size.Height + pictureBox1.Size.Height + lower);
                        type2.Anchor = anchor;
                        break;
                    case 2:
                        type3 = new Type3();
                        Controls.Add(type3);
                        type3.Location = new Point(250, richTextBox1.Size.Height + pictureBox1.Size.Height + lower);
                        type3.Anchor = anchor;
                        break;
                    case 3:
                        type4 = new Type4();
                        Controls.Add(type4);
                        type4.Location = new Point(250, richTextBox1.Size.Height + pictureBox1.Size.Height + lower);
                        type4.Anchor = anchor;
                        break;
                    case 4:
                        type5 = new Type5();
                        Controls.Add(type5);
                        type5.Location = new Point(250, richTextBox1.Size.Height + pictureBox1.Size.Height + lower);
                        type5.Anchor = anchor;
                        break;
                    case 5:
                        type6 = new Type6();
                        Controls.Add(type6);
                        type6.Location = new Point(250, richTextBox1.Size.Height + pictureBox1.Size.Height + lower);
                        type6.Anchor = anchor;
                        break;
                    default:
                        break;
                }
            }
            catch
            {
                // Druga próba rekursywnie.
                cbAnswerType_SelectedIndexChanged(sender, e);
            }
        }

        private void EditQuestionsForm_Load(object sender, EventArgs e)
        {
            richTextBox1.Size = new Size(rtbW, rtbH);
            pictureBox1.Size = new Size(pbW / 2, pbH);
            pictureBox2.Size = new Size(pbW / 2, pbH);
            cbQuestionType.SelectedIndex = 0;
            LoadFromDB(0);
            cbAnswerType.SelectedIndex = 1;
        }

        private void LoadFromDB(int questonListIndex)
        {
            try
            {
                cbQuestionList.Items.Clear();
                cbQuestionList.Items.Add("Nowy wpis");
                Repository r = new Repository(connStr);
                foreach (var item in r.GetQuestions(false))
                {
                    cbQuestionList.Items.Add(item.ID);
                }
                cbQuestionList.SelectedIndex = questonListIndex;
            }
            catch { }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                switch (cbAnswerType.SelectedIndex)
                {
                    case 0:
                        if (type1.q == null)
                            goto default;
                        q = type1.q;
                        q.Type = 1;
                        break;
                    case 1:
                        if (type2.q == null)
                            goto default;
                        q = type2.q;
                        q.Type = 2;
                        break;
                    case 2:
                        if (type3.q == null)
                            goto default;
                        q = type3.q;
                        q.Type = 3;
                        break;
                    case 3:
                        if (type4.q == null)
                            goto default;
                        q = type4.q;
                        q.Type = 4;
                        break;
                    case 4:
                        if (type5.q == null)
                            goto default;
                        if (type5.q.C == "0" && (type5.q.A == "" || type5.q.B == ""))
                        {
                            MessageBox.Show("Wypełnij obie listy jeśli nie ma być dubli!");                            
                            return;
                        }
                        q = type5.q;                       
                        q.Type = type5.q.Type;
                        break;
                    case 5:
                        if (type6.q == null)
                            goto default;
                        q = type6.q;
                        q.Type = 7;
                        break;
                    default:
                        MessageBox.Show("Zaznacz odpowiedzi", "Nie dodano!!!");
                        return;
                }
                if (cbQuestionType.SelectedIndex == 1)
                {
                    //using (Repository r = new Repository(connStr))
                    //{
                    //    q.Image = r.loadImages(q.ID)[0];
                    //    q.ImageAlt = r.loadImages(q.ID)[1];
                    //}
                    q.QType = 2;
                    q.Image = pictureBox1.Image;
                    q.ImageAlt = pictureBox2.Image;
                }
                else
                {
                    q.QType = 1;
                    q.Image = null;
                    q.ImageText = null;
                    q.ImageAlt = null;
                    q.ImageTextAlt = null;
                }

                if (cbQuestionList.SelectedIndex > 0)
                    q.ID = Convert.ToInt16(cbQuestionList.SelectedItem);
                q.question = richTextBox1.Text.Replace(replace1, replace2);
                q.question = q.question.ReplaceSymbolToApostrophe();            
                //Poprawianie Tabeli.
                q.question = q.question.Replace("<table border='1'></br>", "<table border='1'>");
                q.question = q.question.Replace("</table></br>", "</table>");
                q.question = q.question.Replace("</td></br>", "</td>");
                q.question = q.question.Replace("</tr></br>", "</tr>");
                q.question = q.question.Replace("</th></br>", "</th>");
                q.question = q.question.Replace("<td></br>", "<td>");
                q.question = q.question.Replace("<tr></br>", "<tr>");
                q.question = q.question.Replace("<th></br>", "<th>");
                q.question = q.question.Replace("</br><table border='1'>", "<table border='1'>");
                q.question = q.question.Replace("</br></table>", "</table>");
                q.question = q.question.Replace("</br></td>", "</td>");
                q.question = q.question.Replace("</br></tr>", "</tr>");
                q.question = q.question.Replace("</br></th>", "</th>");
                q.question = q.question.Replace("</br><td>", "<td>");
                q.question = q.question.Replace("</br><tr>", "<tr>");
                q.question = q.question.Replace("</br><th>", "<th>");
                using (Repository r = new Repository(connStr))
                {
                    bool ok = false;
                    if (cbQuestionList.SelectedIndex == 0)
                    {
                        ok = r.Add(q);
                        cbAnswerType_SelectedIndexChanged(sender, null);
                    }
                    else
                        ok = r.Update(q);
                    if (ok)
                        MessageBox.Show("OK");
                    LoadFromDB(cbQuestionList.SelectedIndex);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Coś nie zadziałało, spróbuj ponownie.\n" + exc.Message);
            }
        }
        int reCounter = 0;
        private void cbQuestionList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbQuestionList.SelectedIndex > 0)
                {
                    btnSubmit.Text = "Zapisz";
                    btnDelete.Enabled = true;
                    short id = Convert.ToInt16(cbQuestionList.SelectedItem);
                    Repository r = new Repository(connStr);
                    DbQuestion q = r.GetQuestion(id);
                    if (q.QType == 2)
                    {
                        cbQuestionType.SelectedIndex = 1;                        
                        pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                        pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
                         // ciągniemy obrazki z bazy                       
                        Image[] images = r.loadImages(q.ID);
                        q.Image = images[0];
                        q.ImageAlt = images[1];                       
                        pictureBox1.Image = q.Image;
                        pictureBox2.Image = q.ImageAlt;
                    }
                    else
                    {
                        cbQuestionType.SelectedIndex = 0;
                    }
                    cbAnswerType.SelectedIndex = (int)q.Type >= 6? (int)q.Type - 2: (int)q.Type - 1;
                    richTextBox1.Text = q.question.Replace(replace2, replace1);
                    richTextBox1.Text = richTextBox1.Text.ReplaceApostropheToSymbol();                   
                    type1.Dispose();
                    type2.Dispose();
                    type3.Dispose();
                    type4.Dispose();
                    type5.Dispose();
                    type6.Dispose();
                    Point point = new Point(250, richTextBox1.Size.Height + pictureBox1.Size.Height + lower);
                    AnchorStyles anchor = AnchorStyles.Bottom | AnchorStyles.Left;
                    switch (cbAnswerType.SelectedIndex)
                    {
                        case 0:
                            type1 = new Type1();
                            type1.q = q;
                            Controls.Add(type1);
                            type1.Location = point;
                            type1.Anchor = anchor;
                            break;
                        case 1:
                            type2 = new Type2();
                            type2.q = q;
                            Controls.Add(type2);
                            type2.Location = point;
                            type2.Anchor = anchor;
                            break;
                        case 2:
                            type3 = new Type3();
                            type3.q = q;
                            Controls.Add(type3);
                            type3.Location = point;
                            type3.Anchor = anchor;
                            break;
                        case 3:
                            type4 = new Type4();
                            type4.q = q;
                            Controls.Add(type4);
                            type4.Location = point;
                            type4.Anchor = anchor;
                            break;
                        case 4:
                            type5 = new Type5();
                            type5.q = q;
                            Controls.Add(type5);
                            type5.Location = point;
                            type5.Anchor = anchor;
                            break;
                        case 5:
                            type6 = new Type6();
                            type6.q = q;
                            Controls.Add(type6);
                            type6.Location = point;
                            type6.Anchor = anchor;
                            break;
                        default:                          
                            break;
                    }
                }
                else
                {
                    cbQuestionType.SelectedIndex = 0;
                    pictureBox1.Image = null;
                    pictureBox2.Image = null;
                    cbAnswerType_SelectedIndexChanged(sender, null);
                    btnSubmit.Text = "Dodaj";
                    btnDelete.Enabled = false;
                    richTextBox1.Text = "";
                    cbAnswerType.SelectedIndex = 1; //Domyslny typ2 przy wprowadzaniu nowego. (Jednego)
                }
            }
            catch (Exception ex)
            {
                reCounter++;
                if (reCounter == 5)
                {
                    throw;
                }
                //Ponowna próba rekursywnie.
                cbQuestionList_SelectedIndexChanged(sender, e);               
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Czy na pewno usunąć aktualne pytanie?", "Uwaga!!!", MessageBoxButtons.YesNo);
            Repository r = new Repository(connStr);
            switch (result)
            {
                case DialogResult.Yes:
                    if (r.Delete(Convert.ToInt64(cbQuestionList.SelectedItem)))
                        MessageBox.Show("Usunięte");
                    break;
                case DialogResult.No:
                    goto default;
                default:
                    MessageBox.Show("Nieusunięte");
                    break;
            }
            LoadFromDB(0);
        }
        private void btnImageAdd_Click(object sender, EventArgs e)
        {
            getImageFromFile(pictureBox1);
        }
        private void btnImageAltAdd_Click(object sender, EventArgs e)
        {
            getImageFromFile(pictureBox2);
        }

        private void getImageFromFile(PictureBox pb)
        {
            DialogResult d = openFileDialog1.ShowDialog();
            if (d == DialogResult.OK)
            {
                image = Image.FromFile(openFileDialog1.FileName);
                if (image != null)
                {
                    pb.SizeMode = PictureBoxSizeMode.Zoom;
                    pb.Image = image;
                }
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(MousePosition);
            }
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip2.Show(MousePosition);
            }
        }

        private void wklejToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addImage(pictureBox1);
        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            addImage(pictureBox2);
        }
        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            addImage(pictureBox1);
        }
        private void pictureBox2_DoubleClick(object sender, EventArgs e)
        {
            addImage(pictureBox2);
        }
        private void addImage(PictureBox pb)
        {
            pb.SizeMode = PictureBoxSizeMode.Zoom;
            if (Clipboard.ContainsImage())
            {
                pb.Image = Clipboard.GetImage();
            }
            else if (Clipboard.ContainsFileDropList())
            {
                try
                {
                    pb.Image = Image.FromFile(Clipboard.GetFileDropList()[0]);
                }
                catch { }
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (pictureBox1.Image == null)
                using (Font myFont = new Font("Arial", 12))
                {
                    e.Graphics.DrawString("Miejsce na obraz - treść pytania\n\nMożesz tu wkleić obrazek ze schowka\nklikając prawym klawiszem myszy,wybierając 'Wklej' \nlub klikając dwukrotnie lewym klawiszem.", myFont, Brushes.Black, new Point(20, 20));
                }
        }

        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            if (pictureBox2.Image == null)
                using (Font myFont = new Font("Arial", 12))
                {
                    e.Graphics.DrawString("Miejsce na obraz - prawidłowa odpowiedź.", myFont, Brushes.Black, new Point(20, 20));
                }
        }

        private void btnGreen_Click(object sender, EventArgs e)
        {
            replaceSelected("<span class='itsGreen'>", "</span>");
        }

        private void btnBold_Click(object sender, EventArgs e)
        {
            replaceSelected("<b>", "</b>");
        }
        private void btnUnderlined_Click(object sender, EventArgs e)
        {
            replaceSelected("<u>", "</u>");
        }

        private void replaceSelected(string first, string second, bool? onlyReplace = null)
        {
            if (richTextBox1.SelectionLength > 0)
            {
                int start = richTextBox1.SelectionStart;
                string selected = richTextBox1.SelectedText;
                richTextBox1.SelectedText = "";
                if (onlyReplace == true)
                {
                    selected = selected.Replace(first, second);
                    richTextBox1.Text = richTextBox1.Text.Insert(start, selected);
                }
                else
                richTextBox1.Text = richTextBox1.Text.Insert(start, first + selected + second);
            }
        }
        private void insertText(string text)
        {            
            int start = richTextBox1.SelectionStart;           
            richTextBox1.Text = richTextBox1.Text.Insert(start, text);
            richTextBox1.Focus();
            richTextBox1.SelectionStart = start + text.Length;            
        }

        private void richTextBox1_SelectionChanged(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionLength == 0)
            {
                btnGreen.Enabled = false;
                btnBold.Enabled = false;
                btnItalic.Enabled = false;
                btnUnderlined.Enabled = false;
                btnReplaceNewLine.Enabled = false;
            }
            else
            {
                btnGreen.Enabled = true;
                btnBold.Enabled = true;
                btnItalic.Enabled = true;
                btnUnderlined.Enabled = true;
                btnReplaceNewLine.Enabled = true;
            }
        }

        private void btnLt_Click(object sender, EventArgs e)
        {
            insertText("&lt;");
        }

        private void btnGt_Click(object sender, EventArgs e)
        {
            insertText("&gt;");
        }

        private void btnReplaceLtGt_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = richTextBox1.Text.Replace("<", "&lt;");
            richTextBox1.Text = richTextBox1.Text.Replace(">", "&gt;");
        }

        private void btnNbsp_Click(object sender, EventArgs e)
        {
            insertText("&nbsp;");
        }

        private void btnItalic_Click(object sender, EventArgs e)
        {
            replaceSelected("<i>", "</i>");
        }

        private void btnReplaceNewLine_Click(object sender, EventArgs e)
        {
            replaceSelected("\n", " ", true);
        }
    }
}
