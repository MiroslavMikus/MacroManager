using Macros_Manager.Macro.Interfaces;

namespace Macros_Manager.Model.Interfaces
{
    public interface IMacroNode : INode
    {
        IMacro Macro { get; set; }
    }
}