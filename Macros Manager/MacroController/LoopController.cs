using System;
using Macros_Manager.Macro;
using Macros_Manager.Unity;
using System.Timers;
using System.Windows.Input;
using Macros_Manager.UI.Tools;
using Newtonsoft.Json;

namespace Macros_Manager.MacroController
{
    public class LoopController : SimpleMacroController
    {
        public LoopController(IMacro a_macro) : base(a_macro)
        {
            _excutionTimer = new Timer();
            _excutionTimer.Elapsed += (a_sender, a_args) =>
            {
                base.TestScript.Execute(null);
            };
        }

        public override MacroControllerTypes MControllerTypes => MacroControllerTypes.LoopMacro;
        public override ICommand Activate => new AsyncRelayCommand(() =>
        {
            IsActive = true;

            if (_excutionTimer?.Interval == null) return;

            base.TestScript.Execute(null);

            _excutionTimer.Interval = _timerInterval;

            _excutionTimer.Start();
        });

        public override ICommand Stop => new RelayCommand<object>((a) =>
        {
            if (!IsActive) return;

            IsActive = false;

            _excutionTimer.Stop();

            base.Stop.Execute(null);
        });

        private double _timerInterval;
        public double TimerInterval
        {
            get { return _timerInterval / 1000; }
            set { this.MutateVerbose(ref _timerInterval, value * 1000, RaisePropertyChanged()); }
        }

        private readonly Timer _excutionTimer;
    }
}