using Exam.QuestionForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    public class CheckedQuestion
    {
        public short ID { get; set; }
        public DbQuestion Question { get; set; }
        public DbQuestion Answer { get; set; }
        string description { get; set; }
        public bool? OK { get; set; }
        public string GetHtml()
        {
            string result;
            StringBuilder w = new StringBuilder();
            if (Question.Type == 1) // True/False
            {
                w.Append(String.IsNullOrEmpty(Question.A) ? "" : Question.A == "1" ? "True;" : " \n")
                .Append(String.IsNullOrEmpty(Question.B) ? "" : Question.B == "1" ? "False;" : " \n");
            }
            else
            {
                if (Question.Type == 6)
                    w.Append(String.IsNullOrEmpty(Question.B) ? "" : Question.B.ReplaceApostropheToSymbol());
                else
                    w.Append(String.IsNullOrEmpty(Question.A) ? "" : Question.A == "1" ? "A;" : "A: " + Question.A.ReplaceApostropheToSymbol() + "\n")
                     .Append(String.IsNullOrEmpty(Question.B) ? "" : Question.B == "1" ? "B;" : "B: " + Question.B.ReplaceApostropheToSymbol() + "\n");
            }
            if (Question.Type != 5 && Question.Type != 6)
            {
                w.Append(String.IsNullOrEmpty(Question.C) ? "" : Question.C == "1" ? "C;" : "C: " + Question.C.ReplaceApostropheToSymbol() + " ")
            .Append(String.IsNullOrEmpty(Question.D) ? "" : Question.D == "1" ? "D;" : "D: " + Question.D.ReplaceApostropheToSymbol() + " ")
            .Append(String.IsNullOrEmpty(Question.E) ? "" : Question.E == "1" ? "E;" : "E: " + Question.E.ReplaceApostropheToSymbol() + " ")
            .Append(String.IsNullOrEmpty(Question.F) ? "" : Question.F == "1" ? "F;" : "F: " + Question.F.ReplaceApostropheToSymbol() + " ")
            .Append(String.IsNullOrEmpty(Question.G) ? "" : Question.G == "1" ? "G;" : "G: " + Question.G.ReplaceApostropheToSymbol() + " ")          
            .Append(String.IsNullOrEmpty(Question.HH) ? "" : Question.HH == "1" ? "H;" : "H: " + Question.HH.ReplaceApostropheToSymbol() + " ")
            .Append(String.IsNullOrEmpty(Question.I) ? "" : Question.I == "1" ? "I;" : "I: " + Question.I.ReplaceApostropheToSymbol() + " ")
            .Append(String.IsNullOrEmpty(Question.J) ? "" : Question.J == "1" ? "J;" : "J: " + Question.J.ReplaceApostropheToSymbol() + " ")
            .Append(String.IsNullOrEmpty(Question.K) ? "" : Question.K == "1" ? "K;" : "K: " + Question.K.ReplaceApostropheToSymbol() + " ");
                if (Question.Type != 4)
                    w.Append(String.IsNullOrEmpty(Question.H) ? "" : Question.H == "1" ? "H" : Question.H.ReplaceApostropheToSymbol());
            }
            StringBuilder a = new StringBuilder();
            if (OK != null) // Jeśli udzielono odpowiedzi
            {
                if (Question.Type == 1) // True/False
                {
                    a.Append(String.IsNullOrEmpty(Answer.A) ? "" : Answer.A == "1" ? "True;" : "  ")
                    .Append(String.IsNullOrEmpty(Answer.B) ? "" : Answer.B == "1" ? "False;" : "  ");
                }
                else
                {
                    if (Question.Type == 6)
                        a.Append(String.IsNullOrEmpty(Answer.B) ? "" : Answer.B.ReplaceApostropheToSymbol());
                    else
                        a.Append(String.IsNullOrEmpty(Answer.A) ? "" : Answer.A == "1" ? "A;" : "A: " + Answer.A.ReplaceApostropheToSymbol() + "\n")
                         .Append(String.IsNullOrEmpty(Answer.B) ? "" : Answer.B == "1" ? "B;" : "B: " + Answer.B.ReplaceApostropheToSymbol() + "\n");
                }
                if (Question.Type != 5 && Question.Type != 6)
                {                   
                    a.Append(String.IsNullOrEmpty(Answer.C) ? "" : Answer.C == "1" ? "C;" : "C: " + Answer.C.ReplaceApostropheToSymbol() + " ")
                    .Append(String.IsNullOrEmpty(Answer.D) ? "" : Answer.D == "1" ? "D;" : "D: " + Answer.D.ReplaceApostropheToSymbol() + " ")
                    .Append(String.IsNullOrEmpty(Answer.E) ? "" : Answer.E == "1" ? "E;" : "E: " + Answer.E.ReplaceApostropheToSymbol() + " ")
                    .Append(String.IsNullOrEmpty(Answer.F) ? "" : Answer.F == "1" ? "F;" : "F: " + Answer.F.ReplaceApostropheToSymbol() + " ")
                    .Append(String.IsNullOrEmpty(Answer.G) ? "" : Answer.G == "1" ? "G;" : "G: " + Answer.G.ReplaceApostropheToSymbol() + " ")
                    .Append(String.IsNullOrEmpty(Answer.HH) ? "" : Answer.HH == "1" ? "H;" : "H: " + Answer.HH.ReplaceApostropheToSymbol() + " ")
                    .Append(String.IsNullOrEmpty(Answer.I) ? "" : Answer.I == "1" ? "I;" : "I: " + Answer.I.ReplaceApostropheToSymbol() + " ")
                    .Append(String.IsNullOrEmpty(Answer.J) ? "" : Answer.J == "1" ? "J;" : "J: " + Answer.J.ReplaceApostropheToSymbol() + " ")
                    .Append(String.IsNullOrEmpty(Answer.K) ? "" : Answer.K == "1" ? "K;" : "K: " + Answer.K.ReplaceApostropheToSymbol() + " ");
                    if (Question.Type != 4)
                        a.Append(String.IsNullOrEmpty(Answer.H) ? "" : Answer.H == "1" ? "H" : Answer.H.ReplaceApostropheToSymbol());
                }
            }
            else
                a.Append(" ..?..");
            StringBuilder s = new StringBuilder();
            s.Append("<div>");
            switch (OK)
            {
                case true:
                    description = "<label id=label" + ID.ToString() + ">" + ID.ToString() + " - Dobrze :) </label> <style> #label" + ID.ToString() + " {color: green;} #div" + ID.ToString() + " { background: #E6FAEF;}</style>";
                    break;
                case false:
                    description = "<label id=label" + ID.ToString() + ">" + ID.ToString() + " - Źle </label> <style> #label" + ID.ToString() + " {color: red;} #div" + ID.ToString() + " { background: #FAE3DF;}</style> ";
                    break;
                case null:
                    description = "<label id=label" + ID.ToString() + ">" + ID.ToString() + " - ... </label> <style> #label" + ID.ToString() + " {color: grey;} #div" + ID.ToString() + " { background: #F6F6F6;}</style>";
                    break;
                default:
                    break;
            }

            s.Append(description);
            s.Append("Prawidłowo ").Append(w.ToString()).Append("&nbsp;&nbsp;&nbsp;<b style='color: blue;'>Twoja odpowiedź: </b>").Append(a.ToString());

            s.Append("</div>");
            result = s.ToString();
            return result;
        }
   
        public string GetGoodAnwser()
        {
            StringBuilder w = new StringBuilder();
            if (Question.Type == 1) // True/False
            {
                w.Append(String.IsNullOrEmpty(Question.A) ? "" : Question.A == "1" ? "True;" : " \n")
                    .Append(String.IsNullOrEmpty(Question.B) ? "" : Question.B == "1" ? "False;" : " \n");
            }
            else
            {
                if (Question.Type == 6)
                    w.Append(String.IsNullOrEmpty(Question.B) ? "" : Question.B.ReplaceApostropheToSymbol());
                else
                w.Append(String.IsNullOrEmpty(Question.A) ? "" : Question.A == "1" ? "A;" : "A: " + Question.A.ReplaceApostropheToSymbol() + "\n")
                 .Append(String.IsNullOrEmpty(Question.B) ? "" : Question.B == "1" ? "B;" : "B: " + Question.B.ReplaceApostropheToSymbol() + "\n");
            }
            if (Question.Type != 5 && Question.Type != 6)
            {
                w.Append(String.IsNullOrEmpty(Question.C) ? "" : Question.C == "1" ? "C;" : "C: " + Question.C.ReplaceApostropheToSymbol() + "\n")
            .Append(String.IsNullOrEmpty(Question.D) ? "" : Question.D == "1" ? "D;" : "D: " + Question.D.ReplaceApostropheToSymbol() + "\n")
            .Append(String.IsNullOrEmpty(Question.E) ? "" : Question.E == "1" ? "E;" : "E: " + Question.E.ReplaceApostropheToSymbol() + "\n")
            .Append(String.IsNullOrEmpty(Question.F) ? "" : Question.F == "1" ? "F;" : "F: " + Question.F.ReplaceApostropheToSymbol() + "\n")
            .Append(String.IsNullOrEmpty(Question.G) ? "" : Question.G == "1" ? "G;" : "G: " + Question.G.ReplaceApostropheToSymbol() + "\n")
            .Append(String.IsNullOrEmpty(Question.HH) ? "" : Question.HH == "1" ? "H;" : "H: " + Question.HH.ReplaceApostropheToSymbol() + "\n")
            .Append(String.IsNullOrEmpty(Question.I) ? "" : Question.I == "1" ? "I;" : "I: " + Question.I.ReplaceApostropheToSymbol() + "\n")
            .Append(String.IsNullOrEmpty(Question.J) ? "" : Question.J == "1" ? "J;" : "J: " + Question.J.ReplaceApostropheToSymbol() + "\n")
            .Append(String.IsNullOrEmpty(Question.K) ? "" : Question.K == "1" ? "K;" : "K: " + Question.K.ReplaceApostropheToSymbol() + "\n");
                if (Question.Type != 4)
                    w.Append(String.IsNullOrEmpty(Question.H) ? "" : Question.H == "1" ? "H" : "H: " + Question.H.ReplaceApostropheToSymbol() + "\n");
            }
            return w.ToString();

        }
        public string GetGoodAnswerHTML()
        {
            StringBuilder w = new StringBuilder();
            if (Question.Type == 1) // True/False
            {
                w.Append(String.IsNullOrEmpty(Question.A) ? "" : Question.A == "1" ? "True;" : " </br>")
                .Append(String.IsNullOrEmpty(Question.B) ? "" : Question.B == "1" ? "False;" : " </br>");
            }
            else
            {
                if (Question.Type == 6)
                    w.Append(String.IsNullOrEmpty(Question.B) ? "" : Question.B.ReplaceApostropheToSymbol());
                else
                    w.Append(String.IsNullOrEmpty(Question.A) ? "" : Question.A == "1" ? "A;" : "A: " + Question.A.ReplaceApostropheToSymbol() + "\n")
                     .Append(String.IsNullOrEmpty(Question.B) ? "" : Question.B == "1" ? "B;" : "B: " + Question.B.ReplaceApostropheToSymbol() + "\n");
            }
            if (Question.Type != 5 && Question.Type != 6)
            {
                w.Append(String.IsNullOrEmpty(Question.C) ? "" : Question.C == "1" ? "C;" : "C: " + Question.C.ReplaceApostropheToSymbol() + "\n")
            .Append(String.IsNullOrEmpty(Question.D) ? "" : Question.D == "1" ? "D;" : "D: " + Question.D.ReplaceApostropheToSymbol() + "\n")
            .Append(String.IsNullOrEmpty(Question.E) ? "" : Question.E == "1" ? "E;" : "E: " + Question.E.ReplaceApostropheToSymbol() + "\n")
            .Append(String.IsNullOrEmpty(Question.F) ? "" : Question.F == "1" ? "F;" : "F: " + Question.F.ReplaceApostropheToSymbol() + "\n")
            .Append(String.IsNullOrEmpty(Question.G) ? "" : Question.G == "1" ? "G;" : "G: " + Question.G.ReplaceApostropheToSymbol() + "\n")
            .Append(String.IsNullOrEmpty(Question.HH) ? "" : Question.HH == "1" ? "H;" : "H: " + Question.HH.ReplaceApostropheToSymbol() + "\n")
            .Append(String.IsNullOrEmpty(Question.I) ? "" : Question.I == "1" ? "I;" : "I: " + Question.I.ReplaceApostropheToSymbol() + "\n")
            .Append(String.IsNullOrEmpty(Question.J) ? "" : Question.J == "1" ? "J;" : "J: " + Question.J.ReplaceApostropheToSymbol() + "\n")
            .Append(String.IsNullOrEmpty(Question.K) ? "" : Question.K == "1" ? "K;" : "K: " + Question.K.ReplaceApostropheToSymbol() + "\n");
                if (Question.Type != 4)
                    w.Append(String.IsNullOrEmpty(Question.H) ? "" : Question.H == "1" ? "H" : Question.H.ReplaceApostropheToSymbol());
            }
            return w.ToString();
        }
        string imageHtml(string imgStr, bool percent100)
        {
            if (percent100)
                return "<img src='data:image/bmp;base64, " + imgStr + "' style='width:100 %;' > ";
            else
                return "<img src='data:image/bmp;base64, " + imgStr + "' > ";
        }
        public string GetHtmlWithStyle()
        {
            StringBuilder w = new StringBuilder();
            if (Question.Type == 1) // True/False
            {
                w.Append(String.IsNullOrEmpty(Question.A) ? "" : Question.A == "1" ? "True;" : " \n")
                .Append(String.IsNullOrEmpty(Question.B) ? "" : Question.B == "1" ? "False;" : " \n");
            }
            else
            {
                if (Question.Type == 6)
                    w.Append(String.IsNullOrEmpty(Question.B) ? "" : Question.B.ReplaceApostropheToSymbol());
                else
                    w.Append(String.IsNullOrEmpty(Question.A) ? "" : Question.A == "1" ? "A;" : "A: " + Question.A.ReplaceApostropheToSymbol() + "\n")
                     .Append(String.IsNullOrEmpty(Question.B) ? "" : Question.B == "1" ? "B;" : "B: " + Question.B.ReplaceApostropheToSymbol() + "\n");
            }
            if (Question.Type != 5 && Question.Type != 6)
            {
                w.Append(String.IsNullOrEmpty(Question.C) ? "" : Question.C == "1" ? "C;" : "C: " + Question.C.ReplaceApostropheToSymbol() + "\n")
            .Append(String.IsNullOrEmpty(Question.D) ? "" : Question.D == "1" ? "D;" : "D: " + Question.D.ReplaceApostropheToSymbol() + "\n")
            .Append(String.IsNullOrEmpty(Question.E) ? "" : Question.E == "1" ? "E;" : "E: " + Question.E.ReplaceApostropheToSymbol() + "\n")
            .Append(String.IsNullOrEmpty(Question.F) ? "" : Question.F == "1" ? "F;" : "F: " + Question.F.ReplaceApostropheToSymbol() + "\n")
            .Append(String.IsNullOrEmpty(Question.G) ? "" : Question.G == "1" ? "G;" : "G: " + Question.G.ReplaceApostropheToSymbol() + "\n")
            .Append(String.IsNullOrEmpty(Question.HH) ? "" : Question.HH == "1" ? "H;" : "H: " + Question.HH.ReplaceApostropheToSymbol() + "\n")
            .Append(String.IsNullOrEmpty(Question.I) ? "" : Question.I == "1" ? "I;" : "I: " + Question.I.ReplaceApostropheToSymbol() + "\n")
            .Append(String.IsNullOrEmpty(Question.J) ? "" : Question.J == "1" ? "J;" : "J: " + Question.J.ReplaceApostropheToSymbol() + "\n")
            .Append(String.IsNullOrEmpty(Question.K) ? "" : Question.K == "1" ? "K;" : "K: " + Question.K.ReplaceApostropheToSymbol() + "\n");
                if (Question.Type != 4)
                    w.Append(String.IsNullOrEmpty(Question.H) ? "" : Question.H == "1" ? "H" : Question.H.ReplaceApostropheToSymbol());
            }
            string result = "";
            StringBuilder s = new StringBuilder();
            s.Append("<div class='description'> ");
            s.Append("Pytanie ").Append(Question.ID.ToString());
            s.Append("</div> ");
            if (Question.QType == 2)
                s.Append("<div class='question' id='question" + ID.ToString() + "'> " + imageHtml(Question.ImageText, false));
            else
                s.Append("<div class='question' id='question" + ID.ToString() + "'> " + Question.question);
            s.Append(" </div>");
            s.Append("</br>");
            if (Question.Type == 4)
            {
                s.Append(" <div class='options'>");
                s.Append("Opcje do wyboru:</br> ").Append(GetOptionsToHtmlList());
                s.Append(" </div></br>");
            }
            s.Append(" <div class='answer' id='answer" + ID.ToString() + "'>");
            s.Append("Prawidłowo: ").Append(w.ToString());
            s.Append(" </div>");
            s.Append("</br>");
            result = s.ToString();
            return result;
        }
        public string GetOptionsToHtmlList()
        {
            string result = "";
            if (Question != null && Question.H != null)
            {
                string[] temp = Question.H.Split(';');
                foreach (var item in temp)
                {
                    result = result + "<li>" + item + "</li>";
                }
            }
            return result;
        }
    }
}
