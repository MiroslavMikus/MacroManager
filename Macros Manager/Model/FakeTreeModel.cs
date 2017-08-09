using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Macros_Manager.Model.Interfaces;
using Macros_Manager.Model.UI;
using Macros_Manager.Tools;
using Macros_Manager.Unity;
using Microsoft.Practices.Unity;

namespace Macros_Manager.Model
{
    public static class FakeTreeModel
    {
        public static ICollection<INode> GetNodes()
        {
            var ps = MacroContainer.Container.Resolve<INode>(UnityDefs.Powershell.MacroNode);
            ps.Name = "Powershell";
            ObservableCollection<INode> result = new ObservableCollection<INode>
            {
                new LabelNode("Dashboards")
                {
                    CanBeDeleted = false,
                    ChildNodes = new ObservableCollection<INode>()
                    {
                        new LabelNode("Second MacroNode")
                        {
                            CanBeDeleted = true,
                            ChildNodes = new ObservableCollection<INode>() {new LabelNode("Third MacroNode") {CanBeDeleted = true} }
                        },
                        MacroContainer.Container.Resolve<INode>(UnityDefs.Label.Instance, new ParameterOverride("a_name","Fourth MacroNode")),
                    }
                },
                ps,
                MacroContainer.Container.Resolve<INode>(UnityDefs.Label.Instance, new ParameterOverride("a_name","AHK")),
                MacroContainer.Container.Resolve<INode>(UnityDefs.Label.Instance, new ParameterOverride("a_name","SQL")),
            };
            return result;
        }
    }
}
