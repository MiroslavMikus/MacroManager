using Macros_Manager.Annotations;

namespace Macros_Manager.Unity
{
    public static class UnityDefs
    {
        public static class ViewModel
        {
            public const string Main = "MainViewModel";

            public const string LabelViewModel = "LabelViewModel";
        }

        public static TypeDef Powershell { get; } = new TypeDef("Powershell", TypeDef.Types.Macro | TypeDef.Types.LoopMacro);
        public static TypeDef AHK { get; } = new TypeDef("AHK", TypeDef.Types.Macro | TypeDef.Types.LoopMacro|TypeDef.Types.ToogleMacro);
        public static TypeDef Label { get; } = new TypeDef("Label", TypeDef.Types.None, false);
    }
}