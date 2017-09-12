using System.Collections.Generic;
using System.Windows.Controls;
using Macros_Manager.MacroController;
using Macros_Manager.Node.Interfaces;
using Macros_Manager.Tools;
using Macros_Manager.Unity;
using Macros_Manager.Unity.Enums;
using Macros_Manager.View.PagePart.Settings;
using Microsoft.Practices.Unity;

namespace Macros_Manager.Node
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
                OnPropertyChanged();
            }
        }

        public MacroControllerType ControllerType
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
            if (_contentSingleton == null)
            {
                List<TabItem> items = new List<TabItem>
                {
                    new TabItem
                    {
                        Header = "Script",
                        Content = VmcSingleton.VmcContainer.Container.Resolve<ContentControl>(UnityDefs.View.ScriptView)
                    },
                    new TabItem
                    {
                        Header = UnityDefs.View.Description,
                        Content = VmcSingleton.VmcContainer.Container.Resolve<ContentControl>(UnityDefs.View.Description)
                    },
                    new TabItem
                    {
                        Header = "Settings",
                        Content = VmcSingleton.VmcContainer.Container.Resolve<SettingsView>()
                    }
                };
                _contentSingleton = CreateViewWrapper(items);
            }
            return _contentSingleton;
        }

        private ContentControl _contentSingleton;

    }
}
