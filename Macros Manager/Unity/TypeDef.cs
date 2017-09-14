using System;
using System.Collections.Generic;
using System.Linq;
using Macros_Manager.Macro;
using Macros_Manager.Model;
using Macros_Manager.Tools;
using Macros_Manager.Unity.Enums;

namespace Macros_Manager.Unity
{
    /// <summary>
    /// Defines possible MacroController-Macros pairs
    /// </summary>
    public class TypeDef
    {
        public TypeDef(string a_instanceName, MacroControllerType a_possiblePossibleMacroControllersType, bool a_hasSubtype = true)
        {
            Instance = a_instanceName;
            PossibleMacroControllersType = a_possiblePossibleMacroControllersType;
            HasSubtype = a_hasSubtype;
        }

        public Type CurrentType { get; set; }

        public MacroControllerType CurrentControllerType { get; set; }

        public readonly MacroControllerType PossibleMacroControllersType;

        public bool HasSubtype { get; set; }

        public List<string> PossibleTypes
        {
            get
            {
                return Enum.GetValues(typeof(MacroControllerType))
                    .Cast<MacroControllerType>()
                    .Select(CheckType)
                    .Where(a => a != null)
                    .ToList();
            }
        }

        private string CheckType(MacroControllerType a_macroControllerType) // compares possible types with Type in Argument
        {
            return (PossibleMacroControllersType & a_macroControllerType) == a_macroControllerType ? a_macroControllerType.ToString() : null;
        }

        public string Instance { get; set; }
    }

    public static class TypeDefExtensions // ToDo Should be removed !!
    {
        public static TypeDef Copy(this TypeDef a_def, MacroControllerType a_newControllerType)
        {
            return new TypeDef(a_def.Instance, a_def.PossibleMacroControllersType, a_def.HasSubtype)
            {
                CurrentControllerType = a_newControllerType
            };
        }
    }
}