using System.ComponentModel;
using System.Windows.Input;
using Macros_Manager.Macro;
using Macros_Manager.Unity;
using Newtonsoft.Json;

namespace Macros_Manager.MacroController
{
    public interface IMacroController : INotifyPropertyChanged
    {
        MacroControllerTypes MControllerTypes { get; }
        [JsonIgnore]
        ICommand Execute { get; }
        [JsonIgnore]
        ICommand Stop { get; }
        bool IsActive { get; set; }
        IMacro Macro { get; set; }
    }
}
