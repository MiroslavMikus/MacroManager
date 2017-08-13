using Macros_Manager.Macro;
using Macros_Manager.MacroController;

namespace Macros_Manager.Model.Interfaces
{
    public interface IMacroNode : INode
    {
        IMacroController MController { get; set; }
    }
}