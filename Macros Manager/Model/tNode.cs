using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Windows.Markup;
using Macros_Manager.Node.Interfaces;
using Macros_Manager.Unity;
using Macros_Manager.Tools;
using Macros_Manager.Unity.Enums;
using Microsoft.Practices.Unity;

namespace Macros_Manager.Model
{
    public interface INodeModel
    {
        int Id { get; set; }
        string Name { get; set; }
        bool CanBeDeleted { get; set; }
        string RawDescription { get; set; }
        NodeType Type { get; set; }
        ICollection<tNode> ChildNodes { get; set; }
    }

    public class tNode : INodeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool CanBeDeleted { get; set; }
        public string RawDescription { get; set; }
        public NodeType Type { get; set; }
        public virtual ICollection<tNode> ChildNodes { get; set; } = new List<tNode>();

        public virtual INode Instance()
        {
            var node = MacroContainer.Container.Resolve<INode>(Type.ToString(), new ParameterOverride("a_definition", this));

            foreach (var childNode in ChildNodes)
                node.ChildNodes.Add(childNode.Instance());

            return node;
        }
    }

    public class tMarcoNode : tNode
    {
        public tController Controller { get; set; }

        public new IMacroNode Instance()
        {
            var controller = Controller.Instance();

            return MacroContainer.Container.Resolve<IMacroNode>(new ParameterOverride("a_definition",this),
                new ParameterOverride("a_macroController", controller));
        }
    }
}