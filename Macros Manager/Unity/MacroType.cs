using System;

namespace Macros_Manager.Unity
{
    [Flags()]
    public enum MacroType
    {
        Macro = 1,
        LoopMacro = 2,
        ToogleMacro = 4,
        None = 8
    }
}