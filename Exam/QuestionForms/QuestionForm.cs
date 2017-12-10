using Exam.QuestionForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using mshtml;
using SpeakNamespace;

namespace Exam
{
    public partial class QuestionForm : Form
    {
        public QuestionForm()
        {
            InitializeComponent();          
        }
        ParentForm parent;
        public long questionType;
        public bool exam;
        Type1 type1 = new Type1();
        Type2 type2 = new Type2();
        Type3 type3 = new Type3();
        Type4q type4q = new Type4q();
        Type5q type5q = new Type5q();
        Type5q type6 = new Type5q(false);
        string goodAnwser = "";       
        int percent = 0;
        private void buttonNext_Click(object sender, EventArgs e)
        {
            int qn = getQuestionNumber();
            checkButtons(getId(qn) + 1);
            changeQuestion(getId(qn) + 1);
        }
        private void buttonPrevious_Click(object sender, EventArgs e)
        {
            int qn = getQuestionNumber();
            checkButtons(getId(qn) - 1);
            changeQuestion(getId(qn) - 1);
        }
        private void enableBtns(bool enabled)
        {
            btnTranslate.Enabled = enabled;
            btnSpeak.Enabled = enabled;
        }
        private void QuestionForm_Load(object sender, EventArgs e)
        {
            int qn = getQuestionNumber();
            checkButtons(getId(qn));
            DbQuestion answer = parent.GetAnswer(qn);
            panel1.Size = new System.Drawing.Size(this.Size.Width - 130, this.Size.Height - 170);
            switch (questionType)
            {
                case 1:
                    if (answer != null)
                        type1.q = answer;
                    Controls.Add(type1);
                    type1.Location = new Point(105, panel1.Size.Height + 35);
                    type1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;                   
                    if (exam)
                        type1.Leave += new System.EventHandler(this.type1_Leave);
                    break;
                case 2:
                    if (answer != null)
                        type2.q = answer;
                    Controls.Add(type2);
                    type2.Location = new Point(105, panel1.Size.Height + 35);
                    type2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
                    type2.TabIndex = 1;
                    if (exam)
                        type2.Leave += new System.EventHandler(this.type2_Leave);
                    break;
                case 3:
                    if (answer != null)
                        type3.q = answer;
                    Controls.Add(type3);
                    type3.Location = new Point(105, panel1.Size.Height + 35);
                    type3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
                    //type3.TabIndex = 1;
                    if (exam)
                        type3.Leave += new System.EventHandler(this.type3_Leave);
                    break;
                case 4:
                    panel1.Size = new System.Drawing.Size(this.Size.Width - 130, this.Size.Height - 200);
                    type4q.Location = new Point(105, panel1.Size.Height + 35);
                    if (answer != null)
                    {
                        type4q.q = answer;
                        type4q.h = parent.list.Where(a => a.ID == qn).Select(a => a.H).FirstOrDefault();
                    }
                    else
                        type4q.h = parent.list.Where(a => a.ID == qn).Select(a => a.H).FirstOrDefault();
                    type4q.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
                    if (exam)
                        type4q.Leave += new System.EventHandler(this.type4q_Leave);
                    Controls.Add(type4q);
                    break;
                case 5:
                    panel1.Size = new System.Drawing.Size(this.Size.Width - 130, this.Size.Height - 200);
                    type5q.Location = new Point(105, panel1.Size.Height + 35);
                    if (answer != null)
                    {
                        type5q.q = answer;
                        type5q.h = parent.list.Where(a => a.ID == qn).Select(a => a.H).FirstOrDefault();
                        type5q.a = parent.list.Where(a => a.ID == qn).Select(a => a.A).FirstOrDefault();
                        type5q.b = parent.list.Where(a => a.ID == qn).Select(a => a.B).FirstOrDefault();
                    }
                    else {
                        type5q.h = parent.list.Where(a => a.ID == qn).Select(a => a.H).FirstOrDefault();
                        type5q.a = parent.list.Where(a => a.ID == qn).Select(a => a.A).FirstOrDefault();
                        type5q.b = parent.list.Where(a => a.ID == qn).Select(a => a.B).FirstOrDefault();
                    }
                    type5q.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
                    if (exam)
                        type5q.Leave += new System.EventHandler(this.type5q_Leave);
                    Controls.Add(type5q);
                    break;
                case 6:
                    panel1.Size = new System.Drawing.Size(this.Size.Width - 130, this.Size.Height - 200);
                    type6.Location = new Point(105, panel1.Size.Height + 35);
                    if (answer != null)
                    {
                        type6.q = answer;
                        type6.h = parent.list.Where(a => a.ID == qn).Select(a => a.H).FirstOrDefault();
                        type6.a = parent.list.Where(a => a.ID == qn).Select(a => a.A).FirstOrDefault();
                        type6.b = parent.list.Where(a => a.ID == qn).Select(a => a.B).FirstOrDefault();
                    }
                    else
                    {
                        type6.h = parent.list.Where(a => a.ID == qn).Select(a => a.H).FirstOrDefault();
                        type6.a = parent.list.Where(a => a.ID == qn).Select(a => a.A).FirstOrDefault();
                        type6.b = parent.list.Where(a => a.ID == qn).Select(a => a.B).FirstOrDefault();
                    }
                    type6.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
                    if (exam)
                        type6.Leave += new System.EventHandler(this.type6_Leave);
                    Controls.Add(type6);
                    break;
                default:
                    break;                    
            }
            CheckedQuestion c = new CheckedQuestion();
            c.Question = parent.list.Where(a => a.ID == qn).FirstOrDefault();
            if(parent.list.Where(a=>a.ID==qn).Select(a=>a.QType).FirstOrDefault()==2)
                enableBtns(false);
            else
                enableBtns(true);            
            goodAnwser = c.GetGoodAnwser();            
        }
        private void checkButtons(int? idOfQuestion)
        {
            if (idOfQuestion == null)
            {
                buttonPrevious.Enabled = false;
                buttonNext.Enabled = false;
            }
            if (idOfQuestion - 1 < 0)
                buttonPrevious.Enabled = false;
            else
                buttonPrevious.Enabled = true;
            if (idOfQuestion + 1 >= parent.list.Count)
            {
                buttonNext.Enabled = false;
                if (buttonPrevious.Enabled==true)
                {
                    buttonPrevious.TabIndex = 0; /*BugFix ostatnie pytanie. W przypadku braku przycisku
                                               ustawia Tab na innym przycisku a nie na Type..*/

                }
                else
                {
                    btnCheckAll.TabIndex = 0;
                }
            }
            else
                buttonNext.Enabled = true;
        }

        private int? getId(int id)
        {
            return parent.list.IndexOf(parent.list.Where(a => a.ID == id).FirstOrDefault());
        }
        private short getQuestionNumber()
        {
            parent = (ParentForm)this.ParentForm;
            string input = labelQuestion.Text.Remove(0, 8);
            short i = Convert.ToInt16(input);
            return i;
        }
        void changeQuestion(int? listId)
        {
            parent = (ParentForm)this.ParentForm;
            long id = parent.list[(int)listId].ID;
            string key = labelQuestion.Text.Substring(0, 8) + (id).ToString();
            parent.NextNode(key);
        }
        //Typ1 - True/False
        private void type1_Leave(object sender, EventArgs e)
        {
            try
            {
                int? qId = getId(getQuestionNumber());
                type1.q.ID = getQuestionNumber();
                parent.AddAnswer(type1.q);
                parent.ChangeTreeViewItemColor(type1.q.ID);
            }
            catch { }

        }
        //Typ2 - jednokrotny wybór
        private void type2_Leave(object sender, EventArgs e)
        {
            try
            {
                int? qId = getId(getQuestionNumber());
                type2.q.ID = getQuestionNumber();
                parent.AddAnswer(type2.q);
                parent.ChangeTreeViewItemColor(type2.q.ID);
            }
            catch { }

        }
        //Typ3 - wielokrotny wybór
        private void type3_Leave(object sender, EventArgs e)
        {
            try
            {
                int? qId = getId(getQuestionNumber());
                type3.q.ID = getQuestionNumber();
                parent.AddAnswer(type3.q);
                parent.ChangeTreeViewItemColor(type3.q.ID);
            }
            catch { }
        }
        //Typ4 - dopasowanie
        private void type4q_Leave(object sender, EventArgs e)
        {
            try
            {
                int? qId = getId(getQuestionNumber());
                type4q.q.ID = getQuestionNumber();
                type4q.q.H = type4q.h;
                parent.AddAnswer(type4q.q);
                parent.ChangeTreeViewItemColor(type4q.q.ID);
            }
            catch { }
        }
        //Typ5 - przenoszenie
        private void type5q_Leave(object sender, EventArgs e)
        {
            try
            {
                int? qId = getId(getQuestionNumber());
                type5q.q.ID = getQuestionNumber();
                parent.AddAnswer(type5q.q);
                parent.ChangeTreeViewItemColor(type5q.q.ID);
            }
            catch { }
        }
        private void type6_Leave(object sender, EventArgs e)
        {
            try
            {
                int? qId = getId(getQuestionNumber());
                type6.q.ID = getQuestionNumber();
                parent.AddAnswer(type6.q);
                parent.ChangeTreeViewItemColor(type6.q.ID);
            }
            catch { }
        }
        private void btnCheckAll_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Czy chcesz teraz zakończyc i sprawdzić jak Ci poszło?", "Zobacz wyniki", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                parent.timerStop();                
                parent.showSubmitForm();                
            }
        }

        private void btnTranslate_Click(object sender, EventArgs e)
        {
            string textToTranslate = "";
            IHTMLDocument2 htmlDocument = webBrowser1.Document.DomDocument as IHTMLDocument2;
            IHTMLSelectionObject currentSelection = htmlDocument.selection;
            if (currentSelection != null)
            {
                IHTMLTxtRange range = currentSelection.createRange() as IHTMLTxtRange;
                if (range != null)
                    textToTranslate = range.text;
            }
            try
            {
                if (String.IsNullOrEmpty(textToTranslate))
                    textToTranslate = parent.list.Where(a => a.ID == (long)getQuestionNumber()).Select(a => a.question).FirstOrDefault();
                TranslationForm f = new TranslationForm(textToTranslate, labelQuestion.Text);
                f.ShowDialog();
            }
            catch (WebException exc)
            {
                MessageBox.Show("Brak połączenia z internetem lub antywirus blokuje połączenie, próba w otwarcia przeglądarce. \n" + exc.Message, "Błąd!");
                try
                {
                    if (String.IsNullOrEmpty(textToTranslate))
                        textToTranslate = parent.list.Where(a => a.ID == (long)getQuestionNumber()).Select(a => a.question).FirstOrDefault();
                    TranslationForm f = new TranslationForm(textToTranslate, labelQuestion.Text);
                    System.Diagnostics.Process.Start(f.BrowserLink);
                }
                catch (WebException)
                {
                    MessageBox.Show("Brak połączenia z internetem? Brak połączenia z ...www.google.com/translate...", "Błąd!");
                    return;
                }
                return;
            }
            catch (Exception exc)
            {
                MessageBox.Show("Problem z tłumaczeniem.", "Nieznany błąd!");
                return;
            }
        }
        private void btnTranslate_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Zaznacz część pytania którą chcesz tłumaczyć,\n pozostaw niezaznaczone jeśli chcesz tłumaczyć całe pytanie.", btnTranslate);
        }

        private void labelShow_MouseHover(object sender, EventArgs e)
        {
            //toolTip1.Show(goodAnwser, labelShow);
            labelShow.ForeColor = Color.Black;
            labelShow.BorderStyle = BorderStyle.FixedSingle;           
            labelShow.Text = "Prawidłowa odpowiedź: " + Environment.NewLine + goodAnwser;
        }
        private void labelShow_MouseLeave(object sender, EventArgs e)
        {
            //toolTip1.Hide(labelShow);
            labelShow.ForeColor = Color.Orange;
            labelShow.BorderStyle = BorderStyle.None;           
            labelShow.Text = "Prawidłowa odpowiedź";
        }

        private void btnSpeak_Click(object sender, EventArgs e)
        {
            string input = "";
            IHTMLDocument2 htmlDocument = webBrowser1.Document.DomDocument as IHTMLDocument2;
            IHTMLSelectionObject currentSelection = htmlDocument.selection;
            if (currentSelection != null)
            {
                IHTMLTxtRange range = currentSelection.createRange() as IHTMLTxtRange;
                if (range != null)
                    input = range.text;
            }
            try
            {
                if (String.IsNullOrEmpty(input))
                    input = parent.list.Where(a => a.ID == (long)getQuestionNumber()).Select(a => a.question).FirstOrDefault();
                input = input.Replace("</br>", " ");
                input = input.Replace("<td>", " ");
                input = input.Replace("</td>", " ");
                input = input.Replace("</tr>", " ");
                input = input.Replace("<tr>", " ");
                input = input.Replace("<th>", " ");
                input = input.Replace("</th>", " ");
                input = input.Replace("<u>", " ");
                input = input.Replace("</u>", " ");
                Talk talk = new Talk(input);
            }
            catch { }
        }

        private void btnSpeak_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Zaznacz część pytania którą chcesz słuchać,\n pozostaw niezaznaczone jeśli chcesz słuchać całe pytanie.", btnTranslate);
        }

        private void btnSpeak_MouseLeave(object sender, EventArgs e)
        {
            toolTip1.Hide(btnSpeak);
        }

        private void btnTranslate_MouseLeave(object sender, EventArgs e)
        {
            toolTip1.Hide(btnTranslate);
        }

       

        private void cbMark_CheckedChanged(object sender, EventArgs e)
        {
            if (cbMark.CheckState == CheckState.Checked)
            {
                parent.addMarkedQuestion(getQuestionNumber());
            }
            else
            {
                parent.deleteMarkedQuestion(getQuestionNumber());
            }
        }

        private void btnDecrease_Click(object sender, EventArgs e)
        {
            setPadding(percent + 5);
        }

        private void btnIncrease_Click(object sender, EventArgs e)
        {
            setPadding(percent - 5);
        }
        string htmlText = "";
        private void setPadding(int percent)
        {      
            if (htmlText == "")
            {
                htmlText = webBrowser1.DocumentText;
            }      
            if (percent <= 0)
                percent = 0;
            else if (percent >= 50)
                percent = 50;
            string style = " <style> .tempSize { padding-left: " + percent + "%; padding-right: " + percent + "%; } </style> ";           
            webBrowser1.DocumentText = style + htmlText;
            this.percent = percent;
        }
    }
}
