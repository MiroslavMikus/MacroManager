using System.Collections.Generic;
using System.Security.AccessControl;
using Macros_Manager.Model.Interfaces;
using Macros_Manager.Model.UI;
using Macros_Manager.UI.Tools;
using Macros_Manager.Unity;

namespace Macros_Manager.UI.PagePart.NewNodeDialog
{
    public class NewNodeViewModel : BaseNotifyPropertyChanged
    {
        public NewNodeViewModel(INode a_parentNode)
        {
            if (a_parentNode is LabelNode)
            {
                Types = new List<TypeDef>()
                {
                    UnityDefs.Powershell,
                    UnityDefs.AHK,
                    UnityDefs.Label
                };
            }
            else
            {
                Types = new List<TypeDef>()
                {
                    UnityDefs.Label
                };
            }
        }

        public List<TypeDef> Types { get; set; }
    }
}
