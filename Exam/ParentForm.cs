using Exam.QuestionForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Windows.Forms;
using System.IO;
using System.Threading.Tasks;

namespace Exam
{
    public partial class ParentForm : Form
    {
        string defaultFile = ConfigurationManager.AppSettings["dbFileName"];
        string currentDirectory = ConfigurationManager.AppSettings["dbPath"] == "" ? Environment.CurrentDirectory + @"\" : ConfigurationManager.AppSettings["dbPath"];
        internal List<DbQuestion> list = new List<DbQuestion>();
        List<DbQuestion> answers = new List<DbQuestion>();
        Timer t = new Timer();
        DateTime timeStart;
        int minutsForTest = Convert.ToInt32(ConfigurationManager.AppSettings["minutsForTest"]) - 1;
        int questionsForTest = Convert.ToInt32(ConfigurationManager.AppSettings["questionsForTest"]);
        internal List<int> markedQuestions = new List<int>();
        string activeQuestion;
        public ParentForm()
        {
            InitializeComponent();
            openFileDialog1.FileName = currentDirectory + defaultFile;
            toolStripComboBox1.Items.AddRange(new object[] {
            "Egzamin",
            "Szkolenie",
            "Egzamin (" + questionsForTest.ToString() + " pytań)"});
        }

        private void ParentForm_Load(object sender, EventArgs e)
        {
            treeView1.Visible = false;
            Text = Text + " wersja " + ConfigurationManager.AppSettings["version"];
            toolStripTextBoxDbFile.Text = openFileDialog1.FileName;
            toolStripComboBox1.SelectedIndex = 0;
        }

        private void toolStripMenuItemSelectDb_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = currentDirectory;
            openFileDialog1.FileName = defaultFile;
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string[] parts = openFileDialog1.FileName.Split('\\');
            string file = parts[parts.Length - 1];
            string dir = openFileDialog1.FileName.Replace(file, "");
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
                config.AppSettings.Settings["dbFileName"].Value = file;
                config.AppSettings.Settings["dbPath"].Value = dir;
                config.Save(ConfigurationSaveMode.Minimal);
            }
            finally
            {
                toolStripTextBoxDbFile.Text = openFileDialog1.FileName;
            }

        }
        // Ładowanie danych z bazy
        private void toolStripMenuItemLoad_Click(object sender, EventArgs e)
        {
            loadQuestions();
        }
        internal void ClearObjects()
        {
            list.Clear();
            answers.Clear();
            treeView1.Nodes.Clear();
            activeQuestion = null;
            foreach (Form frm in this.MdiChildren)
            {
                if (frm != Parent)
                {
                    frm.Close();
                }
            }
        }
        internal void loadQuestions(string[] toFind = null)
        {
            ClearObjects();
            try
            {
                markedQuestions.Clear(); // Nie chemy pamietać zaznaczonych pytań z innej bazy.
                if (!File.Exists(toolStripTextBoxDbFile.Text))
                {
                    MessageBox.Show("Brak bazy, sprawdź wybraną scieżkę dostępu.", "Ups...");
                    return;
                }
                timerStop();
                Repository r = new Repository(toolStripTextBoxDbFile.Text);
                if (!r.CheckDB())
                    return; // Sprawdza czy baza jest aktualna, modyfikuje ją jeśli trzeba.                
                treeView1.Visible = true;
                treeView1.Nodes.Clear();
                list.Clear();
                switch (toolStripComboBox1.SelectedIndex)
                {
                    // Domyślnie egzamin
                    case 1: // Szkolenie
                        answers.Clear();
                        list = r.GetQuestions(false, toFind, false);
                        foreach (var item in list)
                        {
                            try
                            {
                                item.question = item.question + "<style>" + File.ReadAllText("HTML/dafaultStyle.css") + "</style>";
                                item.Image = item.ImageAlt;
                                item.ImageText = item.ImageTextAlt;
                            }
                            catch
                            {
                            }
                        }
                        answers.AddRange(list);
                        break;
                    case 2: // Egzamin losowe pytania
                        answers.Clear();
                        list = r.GetQuestions(true, toFind, true, questionsForTest);
                        timeStart = DateTime.Now;
                        t.Interval = 1000; // Sekunda.
                        t.Tick += new EventHandler(timer_Tick);
                        t.Start();
                        break;
                    default:
                        answers.Clear();
                        list = r.GetQuestions(false, toFind, true);
                        break;
                }
                if (list.Count == 0)
                {
                    if (!r.IsFinded)
                    {
                        treeView1.Visible = false;
                        closeAllChildren();
                        MessageBox.Show("Nie znaleziono pytań odpowiadających kryteriom wyszukiwania", "Brak wyników");
                        return;
                    }
                    DialogResult dialog = MessageBox.Show("Coś pusto w tej bazie... Czy chcesz teraz utworzyć pytania?", "Problemik", MessageBoxButtons.YesNo);
                    if (dialog == DialogResult.Yes)
                        toolStripMenuItemEditQuestions.PerformClick();
                    return;
                }
                foreach (var item in list)
                {
                    treeView1.Nodes.Add(item.ID.ToString(), "Pytanie " + item.ID.ToString());
                }
                openForm("Pytanie " + list[0].ID.ToString(), true);
            }
            catch (Exception ex)
            {
                closeAllChildren();
            }
        }

        void openForm(string idStr, bool treeViewFocus)
        {
            if (string.Compare(activeQuestion, idStr) == 0)
            {
                return;
            }
            try
            {
                QuestionForm f = new QuestionForm();
                string fontStart = " <div style='font-family: verdana;' class='tempSize'>";
                string idString = idStr.Remove(0, 8);
                int id = Convert.ToInt32(idString);
                if (list.Where(a => a.ID == id).Select(a => a.QType).FirstOrDefault() != 2)
                {
                    f.webBrowser1.Visible = true;
                    f.webBrowser1.DocumentText = fontStart + list.Where(a => a.ID == id).Select(a => a.question.ReplaceApostropheToSymbol()).FirstOrDefault() + "  </div> ";
                }
                else
                {
                    f.webBrowser1.Visible = true;
                    f.webBrowser1.DocumentText = fontStart + imageHtml(list.Where(a => a.ID == id).Select(a => a.ImageText).FirstOrDefault(), true) + "  </div> ";
                }
                f.MdiParent = this;
                f.labelQuestion.Text = idStr;
                f.questionType = list.Where(a => a.ID == id).Select(a => a.Type).FirstOrDefault();
                if (toolStripComboBox1.SelectedIndex != 1) // Nie szkolenie
                {
                    f.labelShow.Visible = true;
                    f.btnCheckAll.Visible = true;
                    f.exam = true;
                }
                f.Dock = DockStyle.Fill;
                f.Show();
                if (markedQuestions.Contains(id))
                {
                    f.cbMark.Checked = true;
                }
                closeAllChildren();
                activeQuestion = idStr;
            }
            catch (Exception eee)
            {
                activeQuestion = null;
            }
            finally
            {
                if (treeViewFocus)
                    treeView1.Focus();
            }
        }
        string imageHtml(string imgStr, bool percent100)
        {
            if (percent100)
                return "<img src='data:image/bmp;base64, " + imgStr + "' style='width:100 %;' > ";
            else
                return "<img src='data:image/bmp;base64, " + imgStr + "' > ";
        }
        private void closeAllChildren()
        {
            for (int i = 0; i < this.MdiChildren.Count(); i++)
                if (this.MdiChildren[i] != Parent && i < this.MdiChildren.Count() - 1)
                    this.MdiChildren[i].Close();
        }

        string nodeText;
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e != null)
                nodeText = e.Node.Text;
            openForm(nodeText, true);
        }
        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e != null)
                nodeText = e.Node.Text;
            treeView1_AfterSelect(sender, null);
        }
        public void NextNode(string key)
        {
            int input = Convert.ToInt32(key.Remove(0, 8));
            DbQuestion currentquestion = list.Where(a => a.ID == input).FirstOrDefault();
            if (currentquestion != null)
                openForm(key, false);
        }
        public void AddAnswer(DbQuestion q)
        {
            DbQuestion toRemove = answers.Where(a => a.ID == q.ID).FirstOrDefault();
            if (toRemove != null)
                answers.Remove(toRemove);
            answers.Add(q);
        }
        public List<DbQuestion> getAnswers()
        {
            return answers;
        }
        public DbQuestion GetAnswer(long id)
        {
            return answers.Where(a => a.ID == id).FirstOrDefault();
        }
        public void ChangeTreeViewItemColor(long id)
        {
            string key = id.ToString();
            treeView1.Nodes[key].BackColor = Color.Aqua;
        }
        //Podsumowanie odpowiedzi.
        public void showSubmitForm()
        {
            treeView1.Visible = false;
            treeView1.Nodes.Clear();
            SubmitForm f = new SubmitForm();
            List<DbQuestion> answers = new List<DbQuestion>();
            answers = getAnswers();
            List<CheckedQuestion> cq = new List<CheckedQuestion>();
            StringBuilder s = new StringBuilder();
            foreach (var q in list)
            {
                CheckedQuestion checkedQ = new CheckedQuestion();
                checkedQ.OK = true; // Startujemy od tego, że nie ma błednych odpowiedzi :)
                checkedQ.ID = q.ID;
                checkedQ.Question = q;
                checkedQ.Answer = answers.Where(b => b.ID == q.ID).FirstOrDefault();
                if (checkedQ.Answer != null)
                {
                    string[] tabQ;
                    string[] tabA;
                    switch (checkedQ.Question.Type)
                    {
                        case 5:
                            tabQ = new string[] { q.A == "" ? null : q.A, q.B == "" ? null : q.B };
                            tabA = new string[] {
                            checkedQ.Answer.A,
                            checkedQ.Answer.B };
                            break;
                        case 6:
                            tabQ = new string[] { q.B == "" ? null : q.B };
                            tabA = new string[] {
                            checkedQ.Answer.B };
                            break;
                        default:
                            tabQ = new string[] {
                                q.A == ""? null: q.A,
                                q.B == ""? null: q.B,
                                q.C == ""? null: q.C,
                                q.D == ""? null: q.D,
                                q.E == ""? null: q.E,
                                q.F == ""? null: q.F,
                                q.G == ""? null: q.G,
                                q.H == ""? null: q.H };
                            tabA = new string[] {
                                checkedQ.Answer.A,
                                checkedQ.Answer.B,
                                checkedQ.Answer.C,
                                checkedQ.Answer.D,
                                checkedQ.Answer.E,
                                checkedQ.Answer.F,
                                checkedQ.Answer.G,
                                checkedQ.Answer.H
                            };
                            break;
                    }

                    // Sprawdza czy odpowiedź OK.
                    for (int i = 0; i < tabQ.Length; i++)
                    {
                        if (tabQ[i] != tabA[i])
                        {
                            checkedQ.OK = false; // Jeśli któryś się nie zgadza to false i przerywa szukanie.
                            break;
                        }
                    }
                }
                else
                {
                    checkedQ.OK = null; // Nie udzielono odpowiedzi.
                }
                cq.Add(checkedQ);
            }
            // Tworzymy raport na podstawie listy przeanalizowanych pytań i odpowiedzi.
            for (int i = 0; i < cq.Count; i++)
            {
                s.AppendLine(cq[i].GetHtml());
            }
            decimal okCount = cq.Where(a => a.OK == true).Count();
            decimal notOkCount = cq.Where(a => a.OK == false).Count();
            decimal allCount = cq.Count();
            int okPercentOfAll = (int)Math.Floor(allCount != 0 ? (okCount / allCount) * 100 : 0);
            int okPercentOfAnwsered = (int)Math.Floor((okCount + notOkCount) != 0 ? (okCount / (okCount + notOkCount)) * 100 : 0);
            cq.Clear();
            list.Clear();
            answers.Clear();
            StringBuilder html = new StringBuilder();
            html.Append(" <div style = 'font-family: verdana;'> ")
                .Append(" <h3 style='color: black'><u>").Append("  ").Append(DateTime.Now.ToLongDateString())
                .Append(" ").Append(DateTime.Now.ToShortTimeString()).Append("</br>").Append("</br>")
                .Append("Odpowiedziano na : ").Append((okCount + notOkCount)).Append(" pytań").Append("</br>")
                .Append("Ilość prawidłowych odpowiedzi to: ").Append(okCount).Append(" na ").Append(allCount).Append(" możliwych").Append("</br>")
                .Append("Ilosć procentowa z całości to: ").Append(okPercentOfAll).Append(" %").Append("</br>")
                .Append("Ilosć procentowa z pytan na które odpowiedziano to: ").Append(okPercentOfAnwsered).Append(" %").Append("</br>")
                .Append("</u></h3>").Append(s.ToString())
                .Append(" </div>");
            s.Clear();
            f.webBrowser1.DocumentText = html.ToString();
            f.MdiParent = this;
            f.Dock = DockStyle.Fill;
            f.Show();
            closeAllChildren();
        }

        private void toolStripMenuItemEditQuestions_Click(object sender, EventArgs e)
        {
            if (!File.Exists(toolStripTextBoxDbFile.Text))
            {
                MessageBox.Show("Brak bazy, sprawdź wybraną scieżkę dostępu.", "Uwaga!!!");
                return;
            }
            Repository r = new Repository(toolStripTextBoxDbFile.Text);
            if (!r.CheckDB())
                return; // Sprawdza czy baza jest aktualna, modyfikuje ją jeśli trzeba.
            ClearObjects();
            EditQuestionsForm f = new EditQuestionsForm();
            f.connStr = toolStripTextBoxDbFile.Text;
            f.ShowDialog();
        }

        private void toolStripMenuItemCreateDB_Click(object sender, EventArgs e)
        {
            // nowa baza
            saveFileDialog1.InitialDirectory = currentDirectory;
            saveFileDialog1.FileName = toolStripTextBoxDbFile.Text;
            DialogResult dialog = saveFileDialog1.ShowDialog();
            if (dialog == DialogResult.OK)
            {
                try
                {
                    File.Delete(saveFileDialog1.FileName);
                }
                catch (Exception)
                {
                    MessageBox.Show("Nie udało się zastąpić istniejącej bazy. Jest aktualnie używana. \nSpróbuj ponownie uruchomić aplikację.", "Uwaga!!!");
                    return;
                }
                Repository r = new Repository(saveFileDialog1.FileName);
                if (r.CreateDB())
                {
                    toolStripTextBoxDbFile.Text = saveFileDialog1.FileName;
                    MessageBox.Show("Utworzono nową baze pytań, została ona aktualnie wybrana w aplikacji.", "OK");
                }
            }
        }
        void timer_Tick(object sender, EventArgs e)
        {
            TimeSpan ts = DateTime.Now - timeStart;
            double allSec = ts.TotalSeconds;
            int min = ((minutsForTest) - ((int)(allSec / 60)));
            int seconds = 60 - (((int)allSec) - (minutsForTest - min) * 60);
            timeLabel.Text = "Pozostało " + min.ToString() + ":" + seconds.ToString();
            if (min < 1)
                //if (min == 39 && seconds == 55)
                timeLabel.ForeColor = Color.Red;
            else
                timeLabel.ForeColor = Color.Blue;
            //if (min == 39 && seconds == 50)
            if (min == 0 && seconds == 1)
            {
                timerStop();
                MessageBox.Show("Czas się skończył! Przechodzimy do podsumwania.", "Egzamin zakończony!");
                showSubmitForm();
            }
        }
        public void timerStop()
        {
            t.Stop();
            timeLabel.Text = "";
        }
        private void toolStripMenuItemOK_Click(object sender, EventArgs e)
        {
            if (!File.Exists(toolStripTextBoxDbFile.Text))
            {
                MessageBox.Show("Brak bazy, sprawdź wybraną scieżkę dostępu.", "Ups...");
                return;
            }
            using (var form = new SearchForm())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    Repository r = new Repository(toolStripTextBoxDbFile.Text);
                    loadQuestions(form.resultStr.Split());
                }
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            AboutBox1 a = new AboutBox1();
            a.ShowDialog();

        }

        private void toolStripMenuItemAdd_Click(object sender, EventArgs e)
        {
            AddRangeForm f = new AddRangeForm();
            f.ShowDialog();
        }

        private void treeView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
                SendKeys.SendWait("{TAB}");
        }

        private void toolStripMenuItemExport_Click(object sender, EventArgs e)
        {
            //Export pytań do HTML
            ExportQuestionsToHtml("HTML/MainTemplate.html", "HTML/QuestionTemplate.html");
        }
        private void toolStripMenuItemExportCarousel_Click(object sender, EventArgs e)
        {
            ExportQuestionsToHtml("HTML/MainTemplateCarousel.html", "HTML/QuestionTemplateCarousel.html");
        }

        private void ExportQuestionsToHtml(string mainTemplatePath, string questionTemplatePath)
        {
            string style = "";
            string script = "";
            string mainTemplate = "";
            if (File.Exists("HTML/Style.css"))
                style = style + File.ReadAllText("HTML/Style.css");
            if (File.Exists("HTML/bootstrap.css"))
                style = style + File.ReadAllText("HTML/bootstrap.css");
            if (File.Exists("HTML/bootstrap-theme.css"))
                style = style + File.ReadAllText("HTML/bootstrap-theme.css");
            if (File.Exists("HTML/jquery.js"))
                script = script + File.ReadAllText("HTML/jquery.js");
            if (File.Exists("HTML/jquery.js"))
                script = script + File.ReadAllText("HTML/bootstrap.js");
            if (File.Exists("HTML/bootstrap.js"))
                script = script + File.ReadAllText("HTML/Script.js");
            if (treeView1.Nodes.Count == 0)
            {
                MessageBox.Show("Najpierw pobierz pytania które chcesz eksportować.", "Trochę tu pusto...");
                return;
            }
            DialogResult dialog = saveFileDialog2.ShowDialog();
            if (dialog == DialogResult.OK)
            {
                try
                {
                    File.Delete(saveFileDialog2.FileName);
                }
                catch (Exception)
                {
                    MessageBox.Show("Nie udało się eksportować do wskazanego pliku. Jest aktualnie używany przez inny proces. \nSpróbuj ponownie uruchomić aplikację.", "Uwaga!!!");
                    return;
                }
                try
                {
                    StringBuilder s = new StringBuilder();
                    if (File.Exists(mainTemplatePath))
                        mainTemplate = File.ReadAllText(mainTemplatePath);
                    mainTemplate = mainTemplate.Replace("+[style]+", " <style>\n" + style + "</style> ");
                    mainTemplate = mainTemplate.Replace("+[script]+", " <script>\n" + script + "</script> ");
                    mainTemplate = mainTemplate.Replace("+[date]+", DateTime.Now.ToShortDateString());
                    //s.AppendLine(mainTemplate);
                    foreach (var q in list)
                    {
                        string template = "";
                        if (File.Exists(questionTemplatePath))
                            template = File.ReadAllText(questionTemplatePath);
                        CheckedQuestion cq = new CheckedQuestion();
                        q.question = q.question.ReplaceApostropheToSymbol();
                        cq.Question = q;
                        if (template.Length > 0)
                        {
                            q.question = q.question.Replace("border=\"1\"", "class='table table-bordered'");
                            template = template.Replace("+[description]+", "Pytanie " + q.ID.ToString());
                            template = template.Replace("+[ID]+", q.ID.ToString());
                            template = template.Replace("+[question]+", q.QType != 2 ? q.question : imageHtml(q.ImageText, false));
                            template = template.Replace("+[options]+", q.Type == 4 ? "Opcje do wyboru</br> " + cq.GetOptionsToHtmlList() : "");
                            template = template.Replace("+[answer]+", cq.GetGoodAnswerHTML());
                        }
                        else
                        {
                            template = cq.GetHtmlWithStyle();
                        }
                        s.AppendLine(template);
                    }

                    mainTemplate = mainTemplate.Replace("+[body]+", s.ToString());

                    if (!String.IsNullOrEmpty(saveFileDialog2.FileName) && !String.IsNullOrEmpty(mainTemplate))
                    {
                        try
                        {
                            File.WriteAllText(saveFileDialog2.FileName, mainTemplate, Encoding.GetEncoding("iso-8859-2"));
                            MessageBox.Show("Zapisano");
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Nie udało się zapisać");
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Nie udało się zapisać");
                }
            }
        }

        private void toolStripMenuItemDeleteQuestions_Click(object sender, EventArgs e)
        {
            DeleteRangeForm f = new DeleteRangeForm(toolStripTextBoxDbFile.Text, markedQuestions);
            f.ShowDialog();
        }
        internal void addMarkedQuestion(int id)
        {
            deleteMarkedQuestion(id);
            markedQuestions.Add(id);
        }
        internal void deleteMarkedQuestion(int id)
        {
            bool c = markedQuestions.Contains(id);
            int breaker = 0;
            while (c && breaker < 10)
            {
                markedQuestions.Remove(id);
                c = markedQuestions.Contains(id);
                breaker++;
            }
        }
    }
}
