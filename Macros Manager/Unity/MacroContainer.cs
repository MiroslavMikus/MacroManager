using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Macros_Manager.Macro;
using Macros_Manager.Macro.Powershell;
using Macros_Manager.MacroController;
using Macros_Manager.Model.Interfaces;
using Macros_Manager.Model.UI;
using Macros_Manager.Tools;
using Macros_Manager.UI.Content;
using Microsoft.Practices.Unity;

namespace Macros_Manager.Unity
{
    public static class MacroContainer
    {
        public static UnityContainer Container { get; set; }

        static MacroContainer()
        {
            Container = new UnityContainer();

            Container.RegisterType<ContentControl, TestContent>(UnityDefs.Powershell.View);

            // Controllers
            Container.RegisterType<IMacroController, SimpleMacroController>(MacroType.Macro.ToString());


            // Powershell

            Container.RegisterType<IMacro, PowershellMacro>
                (UnityDefs.Powershell.Instance,
                new TransientLifetimeManager());


            Container.RegisterType<INode, PowerShellNode>
                (UnityDefs.Powershell.MacroNode,
                new TransientLifetimeManager(),
                new InjectionConstructor(
                    Container.Resolve<IMacroController>(MacroType.Macro.ToString(), new ParameterOverride("a_macro", 
                    Container.Resolve<IMacro>(UnityDefs.Powershell.Instance))), true));
            //

            // Label
            Container.RegisterType<INode, LabelNode>
                (UnityDefs.Label.Instance,
                new TransientLifetimeManager(),
                new InjectionConstructor("",true));
            //
        }
    }
}
