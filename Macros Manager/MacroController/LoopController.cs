using System;
using Macros_Manager.Macro;
using Macros_Manager.Unity;
using System.Timers;
using System.Windows.Input;
using Macros_Manager.Tools;
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
            _repeatUntil = DateTime.Now;
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

        private DateTime _repeatUntil;
        public DateTime RepeatUntilDate
        {
            get { return _repeatUntil; }
            set
            {
                if (_repeatUntil != value)
                    _repeatUntil = value.CreateDateFromDate(_repeatUntil.Hour, _repeatUntil.Minute);

                OnPropertyChanged();
                OnPropertyChanged("RepeatUntilTime");
            }
        }

        public DateTime RepeatUntilTime
        {
            get { return _repeatUntil; }
            set
            {
                if (_repeatUntil != value)
                    _repeatUntil = value.CreateDateFromTime(_repeatUntil.Year, _repeatUntil.Month, _repeatUntil.Day);
            }
        }

        private readonly Timer _excutionTimer;
    }
}