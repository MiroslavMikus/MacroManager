using System.Collections.Generic;
using Macros_Manager.UI.Tools;
using Macros_Manager.Unity;

namespace Macros_Manager.UI.Content
{
    public class NewNodeViewModel : BaseNotifyPropertyChanged
    {
        public NewNodeViewModel()
        {
            Types = new List<TypeDef>()
            {
                UnityDefs.Powershell,
                UnityDefs.AHK,
                UnityDefs.Label
            };
        }

        public List<TypeDef> Types { get; set; }
    }
}
