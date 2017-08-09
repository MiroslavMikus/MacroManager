using System.ComponentModel;
using System.Windows.Input;
using Macros_Manager.Macro;
using Macros_Manager.Unity;
using Newtonsoft.Json;

namespace Macros_Manager.MacroController
{
    public interface IMacroController : INotifyPropertyChanged
    {
        MacroType MType { get; }
        [JsonIgnore]
        ICommand Execute { get; }
        [JsonIgnore]
        ICommand Stop { get; }
        bool IsActive { get; set; }
    }

    public interface IMacroController<T> : IMacroController where T : IMacro
    {
        T Macro { get; set; }
    }
}
