using System.Windows.Controls;
using Macros_Manager.Macro.Interfaces;

namespace Macros_Manager.Macro.Powershell
{
    public class PowershellSettings : ISettings
    {
        public string PowershellScript { get; set; }
        public ContentControl Content { get; }
        public bool IsValid() => true;
    }
}