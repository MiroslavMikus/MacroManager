using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Macros_Manager.Model
{
    public class NodeData
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool CanBeDeleted { get; set; }
        public string RawDescription { get; set; }
        public virtual ICollection<NodeData> ChildNodes { get; set; } = new List<NodeData>();
    }

    public class MacroNodeData : NodeData
    {
        public ControllerData Controller { get; set; }
    }
}