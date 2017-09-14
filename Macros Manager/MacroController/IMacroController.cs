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

    public static class MacroControllerExtensions
    {
        public static IMacroController ResolveController(this IMacroController a_controller, tController a_data)
        {
            var def = UnityDefs.GetDefByInstanceName(a_data.Macro.Type.Instance)
                .Copy(a_data.Macro.Type.PossibleMacroControllersType);

            var macro = MacroContainer.Container.Resolve<IMacro>(def.Instance);

            macro.Definition = def;

            var controller = MacroContainer.Container.Resolve<IMacroController>(a_data.Type.ToString());

            controller.Macro = macro;

            return controller;
        }
    }
}
