using System;
using System.Collections.Generic;
using System.Linq;
using Macros_Manager.Macro;
using Macros_Manager.Tools;
using Macros_Manager.UI.Tools;

namespace Macros_Manager.Unity
{
    public class TypeDef : BaseNotifyPropertyChanged
    {
        public TypeDef(string a_instanceName, MacroControllerTypes a_possiblePossibleMacroControllersTypes, bool a_hasSubtype = true)
        {
            Instance = a_instanceName;
            PossibleMacroControllersTypes = a_possiblePossibleMacroControllersTypes;
            HasSubtype = a_hasSubtype;
        }

        public Type CurrentType { get; set; }

        private MacroControllerTypes _currentControllerTypes;
        public MacroControllerTypes CurrentControllerTypes
        {
            get { return _currentControllerTypes; }
            set { this.MutateVerbose(ref _currentControllerTypes, value, RaisePropertyChanged()); }
        }

        public readonly MacroControllerTypes PossibleMacroControllersTypes;
        public bool HasSubtype { get; set; }

        public List<string> PossibleTypes
        {
            get
            {
                return Enum.GetValues(typeof(MacroControllerTypes))
                    .Cast<MacroControllerTypes>()
                    .Select(CheckType)
                    .Where(a => a != null)
                    .ToList();
            }
        }

        private string CheckType(MacroControllerTypes a_macroControllerTypes)
        {
            return (PossibleMacroControllersTypes & a_macroControllerTypes) == a_macroControllerTypes ? a_macroControllerTypes.ToString() : null;
        }

        public string Instance { get; set; }
        public string View => Instance.Combine(_defaultView);
        public string Settings => Instance.Combine(_defaultSettings);
        public string MacroNode => Instance.Combine(MacroControllerTypes.Macro);
        public string LoopNode => Instance.Combine(MacroControllerTypes.LoopMacro);
        public string ToogleNode => Instance.Combine(MacroControllerTypes.ToogleMacro);

        private static readonly string _defaultView = "View";

        private static readonly string _defaultSettings = "Settings";

    }

    public static class TypeDefExtensions
    {
        public static TypeDef Copy(this TypeDef a_def, MacroControllerTypes a_newControllerTypes)
        {
            return new TypeDef(a_def.Instance, a_def.PossibleMacroControllersTypes, a_def.HasSubtype)
            {
                CurrentControllerTypes = a_newControllerTypes
            };
        }
    }
}