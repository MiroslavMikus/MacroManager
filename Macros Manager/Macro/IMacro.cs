using System.Collections.Generic;

namespace Macros_Manager.Macro
{
    public interface IMacro
    {
        string Name { get; set; }
        void Run();
        ICollection<string> ImportedSettings { get; set; }
        string Script { get; set; }
        object LastResult { get; set; }
    }
}