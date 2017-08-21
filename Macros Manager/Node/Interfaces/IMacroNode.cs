using Macros_Manager.MacroController;

namespace Macros_Manager.Node.Interfaces
{
    public interface IMacroNode : INode
    {
        IMacroController MController { get; set; }
    }
}