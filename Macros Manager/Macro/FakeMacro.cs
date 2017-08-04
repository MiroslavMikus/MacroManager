using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Macros_Manager.Macro.Interfaces;
using Macros_Manager.Model.Interfaces;

namespace Macros_Manager.Macro
{
    public class FakeMacro : IMacro
    {
        public string Name { get; set; } = "fake";

        public string ExternalMacro { get; set; }
        public void Run()
        {
        }

        public ISettings Settings { get; set; }
        public string Description { get; set; }
        public object LastResult { get; set; }
    }
}
