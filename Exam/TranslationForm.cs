using Exam.QuestionForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;
using SpeakNamespace;

namespace Exam
{
    public partial class TranslationForm : Form
    {
        public TranslationForm(string text, string description)
        {
            InitializeComponent();            
            labelQuestion.Text = description + " - PL";
            webBrowser1.DocumentText = translateText(text);
            BrowserLink = setLink(text);
        }
        public string BrowserLink { get; private set; }
        string translateText(string input)
        {
            input = replace(input);
            string url = String.Format("http://www.google.com/translate_t?hl=en&ie=UTF8&text={0}&langpair=en|pl", input);
            WebClient webClient = new WebClient();
            webClient.Encoding = System.Text.Encoding.GetEncoding("iso-8859-2");
            string result = webClient.DownloadString(url);
            result = result.Substring(result.IndexOf("<span id=result_box") + " <span id=result_box".Length);
            result = result.Substring(result.IndexOf(">") + 1);
            result = result.Substring(0, result.IndexOf("</span></div>"));
            result = " <div style='font-family: verdana;'>" + result + "</div> ";
            return result.Trim();
        }
        string setLink(string input)
        {
            input = replace(input);
            string url = String.Format("http://www.google.com/translate_t?hl=en&ie=UTF8&text={0}&langpair=en|pl", input);
            return url;
        }

        private static string replace(string input)
        {
            input = input.Replace("</br>", "%20");
            input = input.Replace(" ", "%20");
            input = input.Replace("\"[apostrof]", "'");        
            input = input.Replace(Environment.NewLine, "%20");           
            return input;
        }
    }
}
