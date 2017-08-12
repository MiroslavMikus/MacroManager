using System;
using System.Globalization;
using System.Windows.Data;

namespace Macros_Manager.UI.PagePart.NewNodeDialog
{
    public class OkButtonIsEnabledConverter : IMultiValueConverter
    {
        public object Convert(object[] a_values, Type a_targetType, object a_parameter, CultureInfo a_culture)
        {
            var typeSelectedItem = a_values[0] != null;

            var typeIsEnabled = (bool) a_values[1];

            var macroControllerSelectedItem = a_values[2] != null;

            var macrocontrollerIsEnabled = (bool)a_values[3];

            if (typeSelectedItem && typeIsEnabled && !macrocontrollerIsEnabled) return true;

            return typeSelectedItem && typeIsEnabled && macrocontrollerIsEnabled && macroControllerSelectedItem;
        }

        public object[] ConvertBack(object a_value, Type[] a_targetTypes, object a_parameter, CultureInfo a_culture)
        {
            return null;
        }
    }
}