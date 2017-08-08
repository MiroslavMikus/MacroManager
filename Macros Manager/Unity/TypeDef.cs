using System;
using System.Collections.Generic;
using System.Linq;
using Macros_Manager.Tools;

namespace Macros_Manager.Unity
{
    public class TypeDef
    {
        public TypeDef(string a_instanceName, MacroType a_possibleMacroType, bool a_hasSubtype = true)
        {
            Instance = a_instanceName;
            _macroType = a_possibleMacroType;
            HasSubtype = a_hasSubtype;
        }
        private readonly MacroType _macroType;
        public bool HasSubtype { get; set; }

        public List<string> PossibleTypes
        {
            get
            {
                return Enum.GetValues(typeof(MacroType))
                    .Cast<MacroType>()
                    .Select(CheckType)
                    .Where(a => a != null)
                    .ToList();
            }
        }

        private string CheckType(MacroType a_macroType)
        {
            return (_macroType & a_macroType) == a_macroType ? a_macroType.ToString() : null;
        }

        public string Instance { get; set; }
        public string View => Instance.Combine(DefaultView);
        public string Settings => Instance.Combine(DefaultSettings);
        public string MacroNode => Instance.Combine(MacroType.Macro);
        public string LoopNode => Instance.Combine(MacroType.LoopMacro);
        public string ToogleNode => Instance.Combine(MacroType.ToogleMacro);

        public static string DefaultView = "View";

        public static string DefaultSettings = "Settings";

    }
}