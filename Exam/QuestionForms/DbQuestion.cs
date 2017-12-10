using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.QuestionForms
{
    public class DbQuestion
    {
        public short ID { get; set; }
        public string question { get; set; }
        public short Type { get; set; }
        public string A { get; set; }
        public string B { get; set; }
        public string C { get; set; }
        public string D { get; set; }
        public string E { get; set; }
        public string F { get; set; }
        public string G { get; set; }
        public string H { get; set; }
        public string HH { get; set; }
        public string I { get; set; }
        public string J { get; set; }
        public string K { get; set; }
        public short QType { get; set; }
        public string ImageText { get; set; }
        public string ImageTextAlt { get; set; }
        public Image Image { get; set; }
        public Image ImageAlt { get; set; }

    }
}
