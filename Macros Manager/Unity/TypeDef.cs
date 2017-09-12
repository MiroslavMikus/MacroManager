using System;
using System.Collections.Generic;
using System.Linq;
using Macros_Manager.Macro;
using Macros_Manager.Model;
using Macros_Manager.Tools;

namespace Macros_Manager.Unity
{
    public class TypeDef
    {
        public TypeDef(string a_instanceName, MacroControllerTypes a_possiblePossibleMacroControllersTypes, bool a_hasSubtype = true)
        {
            Instance = a_instanceName;
            PossibleMacroControllersTypes = a_possiblePossibleMacroControllersTypes;
            HasSubtype = a_hasSubtype;
        }

        public tTypeDescription GetTypeData()
        {
            return new tTypeDescription
            {
                Instance = this.Instance,
                PossibleMacroControllersTypes = PossibleMacroControllersTypes
            };
        }

        public Type CurrentType { get; set; }

        public MacroControllerTypes CurrentControllerType { get; set; }

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

        private string CheckType(MacroControllerTypes a_macroControllerTypes) // compares possible types with type in Argument
        {
            return (PossibleMacroControllersTypes & a_macroControllerTypes) == a_macroControllerTypes ? a_macroControllerTypes.ToString() : null;
        }

        public string Instance { get; set; }
    }

    public static class TypeDefExtensions
    {
        public static TypeDef Copy(this TypeDef a_def, MacroControllerTypes a_newControllerTypes)
        {
            return new TypeDef(a_def.Instance, a_def.PossibleMacroControllersTypes, a_def.HasSubtype)
            {
                CurrentControllerType = a_newControllerTypes
            };
        }
    }
}