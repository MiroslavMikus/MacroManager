using System.Collections.Generic;
using Macros_Manager.Node;
using Macros_Manager.Node.Interfaces;
using Macros_Manager.Unity;
using Macros_Manager.Unity.Enums;
using Macros_Manager.View.Tools;

namespace Macros_Manager.View.PagePart.NewNodeDialog
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
                    UnityDefs.AHK
                    //UnityDefs.Label
                };
            }
            else
            {
                Types = new List<TypeDef>()
                {
                    //UnityDefs.Label
                };
            }
        }

        public List<TypeDef> Types { get; set; }
    }
}
