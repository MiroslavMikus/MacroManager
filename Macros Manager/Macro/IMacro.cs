using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Macros_Manager.Unity;

namespace Macros_Manager.Macro
{
    public interface IMacro
    {
        Task Run(CancellationToken a_token);
        ICollection<string> ImportedSettings { get; set; }
        string Script { get; set; }
        object LastResult { get; set; }
    }
}