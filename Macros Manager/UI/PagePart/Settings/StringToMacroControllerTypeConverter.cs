using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using Macros_Manager.Unity;

namespace Macros_Manager.UI.PagePart.Settings
{
    public class StringToMacroControllerTypeConverter : IValueConverter
    {
        public object Convert(object a_value, Type a_targetType, object a_parameter, CultureInfo a_culture)
        {
            return a_value?.ToString();
        }

        public object ConvertBack(object a_value, Type a_targetType, object a_parameter, CultureInfo a_culture)
        {
            MacroControllerTypes type;

            Enum.TryParse(a_value?.ToString(), out type);

            return type;
        }
    }
}
