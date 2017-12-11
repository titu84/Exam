using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
   public static class Ext
    {
        /// <summary>
        /// return value.Replace("\"[srednik]", ";");
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ReplaceSemicolonToSymbol(this string value)
        {
            return value.Replace("\"[srednik]", ";");
        }
        /// <summary>
        /// return value.Replace(";", "\"[srednik]");
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ReplaceSymbolToSemicolon(this string value)
        {
            return value.Replace(";", "\"[srednik]");
        }
        /// <summary>
        /// return value.Replace("\"[apostrof]", "'");
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ReplaceApostropheToSymbol(this string value)
        {
            return value.Replace("\"[apostrof]", "'");
        }
        /// <summary>
        /// return value.Replace("'", "\"[apostrof]");
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ReplaceSymbolToApostrophe(this string value)
        {
            return value.Replace("'", "\"[apostrof]");
        }
    }
}
