using System;
using System.Collections.Generic;
using System.Linq;
using Macros_Manager.Tools;

namespace Macros_Manager.Unity
{
    public class TypeDef
    {
        public TypeDef(string a_instanceName, Types a_possibleTypes, bool a_hasSubtype = true)
        {
            Instance = a_instanceName;
            _types = a_possibleTypes;
            HasSubtype = a_hasSubtype;
        }
        private readonly Types _types;
        public bool HasSubtype { get; set; }

        public List<string> PossibleTypes
        {
            get
            {
                return Enum.GetValues(typeof (Types))
                    .Cast<Types>()
                    .Select(CheckType)
                    .Where(a => a != null)
                    .ToList();
            }
        }

        private string CheckType(Types a_type)
        {
            return (_types & a_type) == a_type ? a_type.ToString() : null;
        }

        public string Instance { get; set; }
        public string View => Instance.Combine(DefaultView);
        public string Settings => Instance.Combine(DefaultSettings);
        public string MacroNode => Instance.Combine(Types.Macro);
        public string LoopNode => Instance.Combine(Types.LoopMacro);
        public string ToogleNode => Instance.Combine(Types.ToogleMacro);

        public static string DefaultView = "View";

        public static string DefaultSettings = "Settings";

        [Flags()]
        public enum Types
        {
            Macro=1,
            LoopMacro=2,
            ToogleMacro=4,
            None=8
        }
    }
}