using System;
using System.Globalization;
using System.Windows.Data;
using Macros_Manager.Node;

namespace Macros_Manager.UI.Converters
{
    public class IsLabelConverter : IValueConverter
    {
        public object Convert(object a_value, Type a_targetType, object a_parameter, CultureInfo a_culture)
        {
            return a_value is LabelNode;
        }

        public object ConvertBack(object a_value, Type a_targetType, object a_parameter, CultureInfo a_culture)
        {
            return null;
        }
    }
}
