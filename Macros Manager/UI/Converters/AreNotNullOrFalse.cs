using System;
using System.Globalization;
using System.Windows.Data;

namespace Macros_Manager.UI.Converters
{
    public class AreNotNullOrFalse : IMultiValueConverter
    {
        public object Convert(object[] a_values, Type a_targetType, object a_parameter, CultureInfo a_culture)
        {
            foreach (var val in a_values)
            {
                if (val == null) return false;

                if (val is bool)
                    if (!(bool)val) return false;
            }

            return true;
        }

        public object[] ConvertBack(object a_value, Type[] a_targetTypes, object a_parameter, CultureInfo a_culture)
        {
            return null;
        }
    }
}
