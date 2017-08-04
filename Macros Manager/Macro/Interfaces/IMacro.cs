using System;
using Macros_Manager.Model.Interfaces;

namespace Macros_Manager.Macro.Interfaces
{
    public interface IMacro
    {
        String Name { get; set; }
        void Run();
        ISettings Settings { get; set; }
        string Description { get; set; }
        object LastResult { get; set; }
    }
}