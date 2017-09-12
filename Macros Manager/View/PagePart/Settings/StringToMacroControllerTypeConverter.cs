using System;
using System.Globalization;
using System.Windows.Data;
using Macros_Manager.Unity;
using Macros_Manager.Unity.Enums;

namespace Macros_Manager.View.PagePart.Settings
{
    public class StringToMacroControllerTypeConverter : IValueConverter
    {
        public object Convert(object a_value, Type a_targetType, object a_parameter, CultureInfo a_culture)
        {
            return a_value?.ToString();
        }

        public object ConvertBack(object a_value, Type a_targetType, object a_parameter, CultureInfo a_culture)
        {
            MacroControllerType type;

            Enum.TryParse(a_value?.ToString(), out type);

            return type;
        }
    }
}
