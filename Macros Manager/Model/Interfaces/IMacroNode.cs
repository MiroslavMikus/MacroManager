using Macros_Manager.Macro;
using Macros_Manager.MacroController;

namespace Macros_Manager.Model.Interfaces
{
    public interface IMacroNode<T> : INode where T : IMacro
    {
        IMacroController<T> MController { get; set; }
    }
}