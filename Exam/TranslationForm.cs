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
            translateText(text);
            BrowserLink = setLink(text);
        }
        public string BrowserLink { get; private set; }
        void translateText(string input)
        {
            input = replace(input);
            System.Diagnostics.Process.Start(String.Format("https://translate.google.pl/#view=home&op=translate&sl=en&tl=pl&text={0}", input));        
        }
        string setLink(string input)
        {
            input = replace(input);
            string url = String.Format("https://translate.google.pl/#view=home&op=translate&sl=en&tl=pl&text={0}", input);
            return url;
        }

        private static string replace(string input)
        {
            input = input.Replace("</br>", "%20");
            input = input.Replace(" ", "%20");
            input = input.ReplaceApostropheToSymbol();       
            input = input.Replace(Environment.NewLine, "%20");           
            return input;
        }
    }
}
