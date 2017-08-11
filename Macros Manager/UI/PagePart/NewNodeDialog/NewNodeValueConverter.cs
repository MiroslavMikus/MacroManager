using System;
using System.Globalization;
using System.Windows.Data;
using Macros_Manager.Model.Interfaces;
using Macros_Manager.Tools;
using Macros_Manager.Unity;

namespace Macros_Manager.UI.PagePart.NewNodeDialog
{
    public class NewNodeValueConverter : IMultiValueConverter
    {
        public object Convert(object[] a_values, Type a_targetType, object a_parameter, CultureInfo a_culture)
        {
            var firstValue = a_values[0] as string;

            if (firstValue == null && a_values[2] == null) return null;

            var result = a_values[1] == null ? firstValue : firstValue.Combine(a_values[1] as string);

            try
            {
                INode node = MacroContainer.Container.Resolve<INode>(result);
                node.Name = a_values[2] as string;
                return node;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public object[] ConvertBack(object a_value, Type[] a_targetTypes, object a_parameter, CultureInfo a_culture)
        {
            return null;
        }
    }
}
