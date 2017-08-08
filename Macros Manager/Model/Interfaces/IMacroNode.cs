using Macros_Manager.Macro;

namespace Macros_Manager.Model.Interfaces
{
    public interface IMacroNode : INode
    {
        IMacro Macro { get; set; }
    }
}