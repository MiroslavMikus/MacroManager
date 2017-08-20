using System;
using System.Globalization;

namespace Macros_Manager.UI.ValidationRules
{
    public static class CheckDateValidation
    {
        public static bool Check(object a_value, out DateTime a_dateTime)
        {
            return !DateTime.TryParse((a_value ?? "").ToString(),
                CultureInfo.CurrentCulture,
                DateTimeStyles.AssumeLocal | DateTimeStyles.AllowWhiteSpaces,
                out a_dateTime);
        }
    }
}