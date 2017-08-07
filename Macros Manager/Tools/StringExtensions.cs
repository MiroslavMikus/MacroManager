using System;

namespace Macros_Manager.Tools
{
    public static class StringExtensions
    {
        public static string Combine(this string a_string, string a_stringToCombine)
        {
            return a_string + "." + a_stringToCombine;
        }
        public static string Combine(this string a_string, Enum a_enum)
        {
            return a_string + "." + a_enum.ToString();
        }
    }
}