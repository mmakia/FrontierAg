using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontierAg.Logic
{
    public static class GeneralUtilities
    {
        public static string[] LineToStrings(string SearchLine, string delimeter)
        {
            string[] delimiters = { delimeter };
            string[] pieces = SearchLine.Split(delimiters, StringSplitOptions.None);
            return pieces;
        }

        
    }
}