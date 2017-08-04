using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using Macros_Manager.Macro.Interfaces;
using Macros_Manager.Model.Interfaces;
using Macros_Manager.UI.Tools;
using Macros_Manager.Unity;
using Newtonsoft.Json;

namespace Macros_Manager.Model.UI
{
    public class PowerShellNode : BaseTreeNode, IMacroNode
    {
        public PowerShellNode(IMacro a_macro, bool a_canBeDeleted = true) : base(a_canBeDeleted)
        {
            Macro = a_macro;
        }

        public IMacro Macro { get; set; }

        public sealed override string Name
        {
            get { return Macro.Name; }
            set
            {
                Macro.Name = value;
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
        [JsonIgnore]
        public ICommand RunMacro => new RelayCommand<object>(a =>
        {
            Macro.Run();
        });
    }
}
