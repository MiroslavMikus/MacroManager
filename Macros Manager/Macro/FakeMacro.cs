using System.Collections.Generic;

namespace Macros_Manager.Macro
{
    public class FakeMacro : IMacro
    {
        public FakeMacro()
        {
                ImportedSettings = new List<string>();
        }
        public string Name { get; set; } = "fake";

        public string ExternalMacro { get; set; }
        public void Run()
        {
        }

        public ICollection<string> ImportedSettings { get; set; }
        public string Script { get; set; }


        public string Description { get; set; }
        public object LastResult { get; set; }
    }
}
