using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Macros_Manager.Macro.Interfaces;
using Macros_Manager.Model.Interfaces;

namespace Macros_Manager.Macro.Powershell
{
    public class PowershellMacro : IMacro
    {
        public PowershellMacro(ISettings a_settings)
        {
            Settings = a_settings;
        }
        public string Name { get; set; }

        private PowershellSettings _settings;

        public ISettings Settings
        {
            get
            {
                return _settings;
            }
            set
            {
                _settings = value as PowershellSettings;
            }
        }
        public string Description { get; set; }
        public object LastResult { get; set; }

        public void Run()
        {
            using (PowerShell ps = PowerShell.Create())
            {
                ps.AddScript(_settings.PowershellScript);

                LastResult = ps.Invoke();
            }
        }
    }

    public class PowershellSettings : ISettings
    {
        public string PowershellScript { get; set; }
        public ContentControl Content { get; }
        public bool IsValid() => true;
    }
}
