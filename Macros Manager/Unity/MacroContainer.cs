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
using Macros_Manager.Unity.Enums;
using Microsoft.Practices.Unity;

namespace Macros_Manager.Unity
{
    public static class MacroContainer
    {
        public static UnityContainer Container { get; set; }

        static MacroContainer()
        {
            Container = new UnityContainer();

            SetupMacroController();

            SetupMacro();

            SetupNode();
        }

        private static void SetupNode()
        {
            Container.RegisterType<IMacroNode, MacroNode>(new TransientLifetimeManager());

            Container.RegisterType<INode, LabelNode>(NodeType.Label.ToString(), new TransientLifetimeManager());
        }

        public static void SetupMacroController()
        {
            Container.RegisterType<IMacroController, SimpleMacroController>(MacroControllerType.Macro.ToString(), new TransientLifetimeManager());

            Container.RegisterType<IMacroController, LoopController>(MacroControllerType.LoopMacro.ToString(), new TransientLifetimeManager());

            Container.RegisterType<IMacroController, SimpleMacroController>(MacroControllerType.Macro.ToString(), new TransientLifetimeManager());

            Container.RegisterType<IMacroController, SimpleMacroController>(new TransientLifetimeManager()); // remove
        }

        public static void SetupMacro()
        {
            Container.RegisterType<IMacro, PowershellMacro>(new TransientLifetimeManager()); // remove

            Container.RegisterType<IMacro, PowershellMacro>(MacroType.Powershell.ToString(), new TransientLifetimeManager());
        }
    }
}
