using Macros_Manager.Macro;
using Macros_Manager.Unity;
using System.Timers;
using System.Windows.Input;
using Macros_Manager.UI.Tools;

namespace Macros_Manager.MacroController
{
    public class LoopController : SimpleMacroController
    {
        public LoopController(IMacro a_macro) : base(a_macro)
        {
            _excutionTimer = new Timer {Interval = 100.0};
            _excutionTimer.Elapsed += (a_sender, a_args) =>
            {
                base.Execute.Execute(null);
            };
        }

        public override MacroType MType => MacroType.LoopMacro;
        public override ICommand Execute => new AsyncRelayCommand(() =>
        {
            if (IsRunning)
            {
                IsRunning = false;
                _excutionTimer.Stop();
                return;
            }
            IsRunning = true;
            base.Execute.Execute(null);
            _excutionTimer.Start();
        });

        private readonly Timer _excutionTimer;
    }
}