using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Macros_Manager.Macro;
using Macros_Manager.Macro.Powershell;
using Macros_Manager.MacroController;
using Macros_Manager.MacroController.LoopController;
using Macros_Manager.Node;
using Macros_Manager.Node.Interfaces;
using Macros_Manager.Tools;
using Microsoft.Practices.Unity;

namespace Macros_Manager.Unity
{
    public static class MacroContainer
    {
        public static UnityContainer Container { get; set; }

        static MacroContainer()
        {
            Container = new UnityContainer();

            Container.RegisterType<IMacroController, SimpleMacroController>(MacroControllerTypes.Macro.ToString(), new TransientLifetimeManager());

            Container.RegisterType<IMacroController, LoopController>(MacroControllerTypes.LoopMacro.ToString(), new TransientLifetimeManager());

            Container.RegisterType<IMacroController, SimpleMacroController>(MacroControllerTypes.Macro.ToString(), new TransientLifetimeManager());

            Container.RegisterType<IMacroController, SimpleMacroController>(new TransientLifetimeManager());

            Container.RegisterType<IMacro, PowershellMacro>(new TransientLifetimeManager());

            Container.RegisterType<IMacroNode, MacroNode>(new TransientLifetimeManager());

            Container.RegisterType<INode, LabelNode>(UnityDefs.Label.Instance, new TransientLifetimeManager());
        }
    }
}
