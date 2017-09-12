using System;
using System.Collections.Generic;
using System.Linq;

namespace Macros_Manager.Tools
{
    public static class EnumExtensions
    {
        public static T Next<T>(this T a_src) where T : struct
        {
            if (!typeof(T).IsEnum) throw new ArgumentException($"Argumnent {typeof(T).FullName} is not an Enum");

            T[] arr = (T[])Enum.GetValues(a_src.GetType());

            int j = Array.IndexOf<T>(arr, a_src) + 1;

            return (arr.Length == j) ? arr[0] : arr[j];
        }

        public static List<string> EnumToList(Type a_enum) 
        {
            if (!a_enum.IsEnum) throw new ArgumentException($"Argumnent {a_enum.FullName} is not an Enum");

            return Enum.GetNames(a_enum).ToList();
        }
    }
}