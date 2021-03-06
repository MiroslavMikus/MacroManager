﻿using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Forms;
using Macros_Manager.Macro;
using Macros_Manager.Macro.Powershell;
using Macros_Manager.MacroController;
using Macros_Manager.Node.Interfaces;
using Macros_Manager.Tools;
using Macros_Manager.Unity;
using Microsoft.Practices.Unity;
using static Macros_Manager.Unity.MacroContainer;

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
                if (!Container.IsRegistered<INode>(elementTypeDef.Instance)) return null; // todo add error message

                return Container.Resolve<INode>(elementTypeDef.Instance, new ParameterOverride("a_name", elementname));
            }

            try
            {
                var controllerName = a_values[2] as string;

                if (elementTypeDef.CurrentType == null || controllerName == null) return null;

                var macro = Container.Resolve(elementTypeDef.CurrentType) as IMacro;

                macro.Name = elementname;

                MacroControllerTypes controllerTypesType;

                if (!Enum.TryParse(controllerName, out controllerTypesType)) return null;

                macro.Definition = elementTypeDef.Copy(controllerTypesType);

                macro.Definition.CurrentType = macro.GetType();

                var controller = Container.Resolve<IMacroController>(controllerName, new ParameterOverride("a_macro", macro));

                return Container.Resolve<IMacroNode>(new ParameterOverride("a_macroController", controller));
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
