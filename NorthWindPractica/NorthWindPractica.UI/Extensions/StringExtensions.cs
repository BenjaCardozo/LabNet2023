using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace NorthWindPractica.UI.Extensions
{
    public static class StringExtensions
    {
        public static bool ContainsOnlyLetters(this string str) => Regex.IsMatch(str, @"^[a-zA-Z]+$");
    }
}
