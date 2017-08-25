using System.Collections.Generic;

namespace Macros_Manager.Model
{
    public class NodeData
    {
        public string Name { get; set; }
        public bool CanBeDeleted { get; set; }
        public string RawDescription { get; set; }
        public ICollection<NodeData> ChildNodes { get; set; }
    }

    public class MacroNodeData : NodeData
    {
        public ControllerData Controller { get; set; }
    }
}