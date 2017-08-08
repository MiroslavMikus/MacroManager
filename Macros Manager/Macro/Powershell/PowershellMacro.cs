using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Threading;
using System.Threading.Tasks;

namespace Macros_Manager.Macro.Powershell
{
    public class PowershellMacro : IMacro
    {
        public PowershellMacro()
        {
            ImportedSettings = new List<string>();
        }

        public string Name { get; set; }
        public async Task Run(CancellationToken a_token)
        {
            if (Script == null) return;

            using (PowerShell ps = PowerShell.Create())
            {
                foreach (var script in ImportedSettings)
                {
                    ps.AddScript(script);
                }

                ps.AddScript(Script);

                LastResult = await Task.Factory.FromAsync((a, b) => ps.BeginInvoke(), ps.EndInvoke,null);
            }
        }

        public ICollection<string> ImportedSettings { get; set; }
        public string Script { get; set; }
        public object LastResult { get; set; }
    }
}
