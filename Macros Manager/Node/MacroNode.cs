using System.Collections.Generic;
using System.Windows.Controls;
using Macros_Manager.MacroController;
using Macros_Manager.Model;
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
        public MacroNode(tMarcoNode a_definition, IMacroController a_macroController) : base(a_definition)
        {
            MController = a_macroController;
        }

        private new tMarcoNode _nodeData;

        public IMacroController MController { get; set; }

        public MacroControllerType ControllerType
        {
            get { return _nodeData.Controller.Type; }
            set
            {
                if (_nodeData.Controller.Type == value) return;

                MController = MacroContainer.Container.Resolve<IMacroController>(value.ToString(), new ParameterOverride("a_macro", MController.Macro));

                _nodeData.Controller.Type = value;

                OnPropertyChanged();
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
