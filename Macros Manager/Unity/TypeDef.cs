using System;
using System.Collections.Generic;
using System.Linq;
using Macros_Manager.Macro;
using Macros_Manager.Tools;

namespace Macros_Manager.Unity
{
    public class TypeDef
    {
        public TypeDef(string a_instanceName, MacroType a_possiblePossibleMacroType, bool a_hasSubtype = true)
        {
            Instance = a_instanceName;
            _possibleMacroType = a_possiblePossibleMacroType;
            HasSubtype = a_hasSubtype;
        }

        public Type CurrentType { get; set; }

        private readonly MacroType _possibleMacroType;
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
            return (_possibleMacroType & a_macroType) == a_macroType ? a_macroType.ToString() : null;
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