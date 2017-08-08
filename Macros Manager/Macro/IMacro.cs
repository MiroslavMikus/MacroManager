using System.Collections.Generic;

namespace Macros_Manager.Macro
{
    public interface IMacro
    {
        string Name { get; set; }
        void Run();
        ICollection<string> Script { get; set; }
        object LastResult { get; set; }
    }
}