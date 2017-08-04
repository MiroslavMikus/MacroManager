using Macros_Manager.Model.Interfaces;

namespace Macros_Manager.Macro.Interfaces
{
    interface ILoopMacro : IMacro
    {
        void Start();
        int Interval { get; set; }
        void Stop();
    }
}