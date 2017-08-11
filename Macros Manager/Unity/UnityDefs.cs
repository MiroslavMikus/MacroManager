using Macros_Manager.Annotations;

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
        }

        public static TypeDef Powershell { get; } = new TypeDef("Powershell", MacroType.Macro | MacroType.LoopMacro);
        public static TypeDef AHK { get; } = new TypeDef("AHK", MacroType.Macro | MacroType.LoopMacro| MacroType.ToogleMacro);
        public static TypeDef Label { get; } = new TypeDef("Label", MacroType.None, false);
    }
}