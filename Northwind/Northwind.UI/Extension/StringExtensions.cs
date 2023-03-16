using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Northwind.UI.Extension
{
    public static class StringExtensions
    {
        public static bool ContainsOnlyLetters(this string str) => !string.IsNullOrEmpty(str) 
            && Regex.IsMatch(str, @"^[a-zA-Z]+$");
        public static bool IsValidPhoneNumber(this string phone) =>!string.IsNullOrEmpty(phone)
            && Regex.IsMatch(phone, @"^\(\d{3}\) \d{3}-\d{4}$");
    }
}
