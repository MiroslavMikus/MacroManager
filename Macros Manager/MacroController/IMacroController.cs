using System.ComponentModel;
using System.Windows.Input;
using Macros_Manager.Macro;
using Macros_Manager.Unity;
using Newtonsoft.Json;

namespace Macros_Manager.MacroController
{
    public interface IMacroController : INotifyPropertyChanged
    {
        IMacro Macro { get; set; }
        MacroType MType { get; }
        [JsonIgnore]
        ICommand Execute { get; }
        [JsonIgnore]
        ICommand Stop { get; }
        bool IsActive { get; set; }
    }
}
