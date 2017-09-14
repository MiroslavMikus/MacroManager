using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Windows.Markup;
using Macros_Manager.Node.Interfaces;
using Macros_Manager.Unity.Enums;

namespace Macros_Manager.Model
{
    public class tNode
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool CanBeDeleted { get; set; }
        public string RawDescription { get; set; }
        public NodeType Type { get; set; }
        public virtual ICollection<tNode> ChildNodes { get; set; } = new List<tNode>();

        public virtual INode Instance()
        {
            return null;
        }
    }

    public class tMarcoNode : tNode
    {
        public tController Controller { get; set; }
    }
}