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
using Macros_Manager.Unity;
using static Macros_Manager.Unity.VmcSingeltion;

namespace Macros_Manager.Model.UI
{
    public class PowerShellNode : BaseTreeNode, IMacroNode<PowershellMacro>
    {
        public PowerShellNode(IMacroController<PowershellMacro> a_macroController)
        {
            MController = a_macroController;
        }

        public IMacroController<PowershellMacro> MController { get; set; }

        public sealed override string Name
        {
            get { return MController.Macro.Name; }
            set
            {
                MController.Macro.Name = value;
                RaisePropertyChanged().Invoke(new PropertyChangedEventArgs("Name"));
            }
        }

        protected override ContentControl ContentCreator()
        {
            List<TabItem> items = new List<TabItem>()
            {
                new TabItem
                {
                    Header = "Script",
                    Content = VmcContainer.Container.Resolve<ContentControl>(UnityDefs.Powershell.View)
                },
                new TabItem
                {
                    Header = UnityDefs.View.Description,
                    Content = VmcContainer.Container.Resolve<ContentControl>(UnityDefs.View.Description)
                }
            };

            var view = VmcContainer.Container.Resolve<ContentControl>(UnityDefs.View.Frame, new ParameterOverride("a_items", items));

            if (view != null) view.DataContext = this;

            return view;
        }
    }
}
