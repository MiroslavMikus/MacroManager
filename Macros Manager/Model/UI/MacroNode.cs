using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

using Microsoft.Practices.Unity;

using Macros_Manager.Macro;
using Macros_Manager.Macro.Powershell;
using Macros_Manager.MacroController;
using Macros_Manager.Model.Interfaces;
using Macros_Manager.Tools;
using Macros_Manager.UI.PagePart.Settings;
using Macros_Manager.Unity;
using static Macros_Manager.Unity.VmcSingleton;

namespace Macros_Manager.Model.UI
{
    public class MacroNode : BaseTreeNode, IMacroNode
    {
        public MacroNode(IMacroController a_macroController)
        {
            MController = a_macroController;
        }

        public IMacroController MController { get; set; }

        public sealed override string Name
        {
            get { return MController.Macro.Name; }
            set
            {
                MController.Macro.Name = value;
                RaisePropertyChanged().Invoke(new PropertyChangedEventArgs("Name"));
            }
        }

        public MacroControllerTypes ControllerType
        {
            get { return MController.Macro.Definition.CurrentControllerType; }
            set
            {
                if (MController.Macro.Definition.CurrentControllerType == value) return;

                MController = MacroContainer.Container.Resolve<IMacroController>(value.ToString(), new ParameterOverride("a_macro", MController.Macro));

                MController.Macro.Definition.CurrentControllerType = value;

                OnPropertyChanged("MController");
            }
        }
        
        protected override ContentControl ContentCreator()
        {
            List<TabItem> items = new List<TabItem>()
            {
                new TabItem
                {
                    Header = "Script",
                    Content = VmcContainer.Container.Resolve<ContentControl>(UnityDefs.View.ScriptView)
                },
                new TabItem
                {
                    Header = UnityDefs.View.Description,
                    Content = VmcContainer.Container.Resolve<ContentControl>(UnityDefs.View.Description)
                },
                new TabItem
                {
                    Header = "Settings",
                    Content = VmcContainer.Container.Resolve<SettingsView>()
                }
            };
            return CreateViewWrapper(items);
        }


    }
}
