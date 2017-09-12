using System.Collections.Generic;
using System.Linq;
using Macros_Manager.Annotations;
using Macros_Manager.Macro.Powershell;

namespace Macros_Manager.Unity
{
    public static class UnityDefs
    {
        public static class ViewModel
        {
            public const string Main = "MainViewModel";

            public const string Label = "Label";

        }

        public static class View
        {
            public const string Frame = "Frame";

            public const string Description = "Description";

            public const string ScriptView = "ScriptView";
        }

        public static class NodeTypes
        {
            public const string Label = "Label";
            public const string Macro = "Macro";
        }

        public static TypeDef GetDefByInstanceName(string a_name)
        {
            return _definitions.FirstOrDefault(a => a.Instance == a_name);
        }

        private static readonly List<TypeDef> _definitions = new List<TypeDef> { Powershell, AHK, Label };

        public static TypeDef Powershell { get; } = new TypeDef("Powershell", MacroControllerTypes.Macro | MacroControllerTypes.LoopMacro) { CurrentType = typeof(PowershellMacro) };
        public static TypeDef AHK { get; } = new TypeDef("AHK", MacroControllerTypes.Macro | MacroControllerTypes.LoopMacro | MacroControllerTypes.ToogleMacro);
        public static TypeDef Label { get; } = new TypeDef("Label", MacroControllerTypes.None, false);
    }
}