using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using Macros_Manager.Macro;
using Macros_Manager.Macro.Powershell;
using Macros_Manager.MacroController;
using Macros_Manager.Model.Interfaces;
using Macros_Manager.UI.Tools;
using Macros_Manager.Unity;
using Newtonsoft.Json;

namespace Macros_Manager.Model.UI
{
    public class PowerShellNode : BaseTreeNode, IMacroNode<PowershellMacro>
    {
        public PowerShellNode(IMacroController<PowershellMacro> a_macroController) : base()
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
            var result = VmcSingeltion.VmcContainer.Container.Resolve(typeof(ContentControl), UnityDefs.Powershell.View)
                as ContentControl;

            if (result != null) result.DataContext = this;

            return result;
        }
    }
}
