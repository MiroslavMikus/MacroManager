using System.ComponentModel;
using System.Windows.Input;
using Macros_Manager.Macro;
using Macros_Manager.Model;
using Macros_Manager.Unity;
using Macros_Manager.Unity.Enums;
using Microsoft.Practices.Unity;
using Newtonsoft.Json;

namespace Macros_Manager.MacroController
{
    public interface IMacroController : INotifyPropertyChanged
    {
        MacroControllerType MControllerType { get; }
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
