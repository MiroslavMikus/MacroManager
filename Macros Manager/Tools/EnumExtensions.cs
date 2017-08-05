using System;

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
    }
}