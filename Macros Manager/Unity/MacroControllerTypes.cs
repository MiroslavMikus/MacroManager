using System;

namespace Macros_Manager.Unity
{
    [Flags()]
    public enum MacroControllerTypes
    {
        Macro = 1,
        LoopMacro = 2,
        ToogleMacro = 4,
        None = 8
    }
}