using System;

namespace Macros_Manager.Unity.Enums
{
    public enum NodeType
    {
        Label,
        Macro,
        Sequence,
        Dashboard,
        Data
    }

    [Flags()]
    public enum MacroControllerType
    {
        Macro = 1,
        LoopMacro = 2,
        ToogleMacro = 4,
        None = 8
    }

    public enum MacroType
    {
        Powershell,
        AHK
    }
}