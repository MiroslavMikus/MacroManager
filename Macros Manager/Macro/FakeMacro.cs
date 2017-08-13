using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Macros_Manager.Unity;

namespace Macros_Manager.Macro
{
    public class FakeMacro : IMacro
    {
        public FakeMacro()
        {
                ImportedSettings = new List<string>();
        }
        public string Name { get; set; } = "fake";
        public TypeDef Definition { get; set; }

        public string ExternalMacro { get; set; }

        public Task Run(CancellationToken a_token)
        {
            throw new System.NotImplementedException();
        }

        public ICollection<string> ImportedSettings { get; set; }
        public string Script { get; set; }

        public object LastResult { get; set; }
    }
}
