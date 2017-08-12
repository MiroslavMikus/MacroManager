using System;
using System.Globalization;
using System.Windows.Data;

namespace Macros_Manager.UI.Converters
{
    public class IsNullConverter : IValueConverter
    {
        public object Convert(object a_value, Type a_targetType, object a_parameter, CultureInfo a_culture)
        {
            return (a_value == null);
        }

        public object ConvertBack(object a_value, Type a_targetType, object a_parameter, CultureInfo a_culture)
        {
            return null;
        }
    }
}
