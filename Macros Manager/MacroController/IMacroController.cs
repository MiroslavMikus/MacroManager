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
        ICommand TestScript { get; }
        [JsonIgnore]
        ICommand Activate { get; }
        [JsonIgnore]
        ICommand Stop { get; }
        bool IsActive { get; set; }
        bool Executing { get; set; }
        IMacro Macro { get; set; }
    }
}
