using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;
using Macros_Manager.Model.Interfaces;

namespace Macros_Manager.Macro.Powershell
{
    public class PowershellMacro : IMacro
    {
        public PowershellMacro()
        {
            ImportedSettings = new List<string>();
        }

        public string Name { get; set; }
        public ICollection<string> ImportedSettings { get; set; }
        public string Script { get; set; }
        public string Description { get; set; }
        public object LastResult { get; set; }

        public void Run()
        {
            using (PowerShell ps = PowerShell.Create())
            {
                foreach (var script in ImportedSettings)
                {
                    ps.AddScript(script);
                }
                ps.AddScript(Script);
                LastResult = ps.Invoke();
            }
        }
    }
}
