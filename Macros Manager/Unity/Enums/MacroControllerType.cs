using System;

namespace Macros_Manager.Unity.Enums
{
    public enum NodeType
    {
        Label,
        Macro,
        Sequence, // Missing
        Dashboard, // Missing
        Data // Missing
    }

    [Flags()]
    public enum MacroControllerType
    {
        None = 1,
        Macro = 2,
        LoopMacro = 4,
        ToogleMacro = 8, // Missing
        ScheduledMacro = 16 // Missing
    }

    public enum MacroType
    {
        Powershell,
        AHK // Missing
    }
}