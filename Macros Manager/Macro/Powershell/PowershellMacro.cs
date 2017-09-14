using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Threading;
using System.Threading.Tasks;
using Macros_Manager.Model;
using Macros_Manager.Unity;

namespace Macros_Manager.Macro.Powershell
{
    public class PowershellMacro : IMacro
    {
        public PowershellMacro(tMacro a_definition)
        {
            _data = a_definition;
            ImportedSettings = new List<string>();
        }

        private tMacro _data;
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
                //LastResult = ps.Invoke();
            }
        }

        public ICollection<string> ImportedSettings { get; set; }
        public string Script
        {
            get { return _data.Script; }
            set { _data.Script = value; }
        }
        public object LastResult { get; set; }
    }
}
