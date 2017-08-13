using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Forms;
using Macros_Manager.Macro;
using Macros_Manager.Macro.Powershell;
using Macros_Manager.MacroController;
using Macros_Manager.Model.Interfaces;
using Macros_Manager.Model.UI;
using Macros_Manager.Tools;
using Macros_Manager.Unity;
using Microsoft.Practices.Unity;

namespace Macros_Manager.UI.PagePart.NewNodeDialog
{
    public class NewNodeValueConverter : IMultiValueConverter
    {
        public object Convert(object[] a_values, Type a_targetType, object a_parameter, CultureInfo a_culture)
        {
            if (a_values[0] == null || a_values[1] == null) return null;

            var elementname = a_values[0] as string;

            var elementTypeDef = a_values[1] as TypeDef;

            if (!elementTypeDef.HasSubtype)
            {
                if (!MacroContainer.Container.IsRegistered<INode>(elementTypeDef.Instance)) return null; // todo add error message

                return MacroContainer.Container.Resolve<INode>(elementTypeDef.Instance, new ParameterOverride("a_name", elementname));
            }

            try
            {
                if (elementTypeDef.CurrentType == null) return null;

                var node = MacroContainer.Container.Resolve<INode>(elementTypeDef.MacroNode);

                node.Name = elementname;

                if (node is IMacroNode<PowershellMacro>)
                {
                    var test = node as IMacroNode<IMacro>;

                    test.MController.Macro.Definition = elementTypeDef;
                }

                return node;
            }
            catch (Exception ex)
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
