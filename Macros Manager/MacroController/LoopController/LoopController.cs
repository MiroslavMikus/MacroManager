using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Input;
using Macros_Manager.Annotations;
using Macros_Manager.Macro;
using Macros_Manager.Tools;
using Macros_Manager.Unity;
using Macros_Manager.Unity.Enums;
using Macros_Manager.View.Tools;
using Timer = System.Timers.Timer;

namespace Macros_Manager.MacroController.LoopController
{
    public class LoopController : SimpleMacroController // Todo Clean this somehow
    {
        public LoopController(IMacro a_macro) : base(a_macro)
        {
            _repeatUntil = DateTime.Now;

            Infinite = true;
        }

        private Timer _excutionTimer;

        private LoopControllerStates _state;

        public override MacroControllerType MControllerType => MacroControllerType.LoopMacro;

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

        public int LoopCounter { get; set; }

        public override ICommand Activate
        {
            get
            {
                switch (_state)
                {
                    case LoopControllerStates.Infinite:
                        return _infinite;
                    case LoopControllerStates.LoopCount:
                        return _loopCount;
                    case LoopControllerStates.LoopUntil:
                        return _loopUntil;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        private ICommand _infinite => new AsyncRelayCommand(() =>
        {
            CommandWrapper(() =>
            {
                _excutionTimer.Elapsed += (a_sender, a_args) => { base.TestScript.Execute(null); };
            });
        });

        public bool Infinite
        {
            get { return _state == LoopControllerStates.Infinite; }
            set
            {
                if (value)
                {
                    _state = LoopControllerStates.Infinite;
                    OnPropertyChanged("Activate");
                }
            }
        }

        private int _tempLoopCount;
        private ICommand _loopCount => new AsyncRelayCommand(() =>
        {
            CommandWrapper(() =>
            {
                _tempLoopCount = 0;

                Interlocked.Exchange(ref _tempLoopCount, LoopCounter + 1);

                _excutionTimer.Elapsed += (a_sender, a_args) =>
                {
                    if (Interlocked.Decrement(ref _tempLoopCount) <= 0)
                    {
                        this.Stop.Execute(null);
                    }
                    else
                    {
                        base.TestScript.Execute(null);
                    }
                };
            });
        });

        public bool LoopCount
        {
            get { return _state == LoopControllerStates.LoopCount; }
            set
            {
                if (value)
                {
                    _state = LoopControllerStates.LoopCount;
                    OnPropertyChanged("Activate");
                }
            }
        }

        private ICommand _loopUntil => new AsyncRelayCommand(() =>
        {
            CommandWrapper(() =>
            {
                _excutionTimer.Elapsed += (a_sender, a_args) =>
                {
                    if (_repeatUntil <= DateTime.Now)
                    {
                        this.Stop.Execute(null);
                    }
                    else
                    {
                        base.TestScript.Execute(null);
                    }
                };
            });
        });

        public bool LoopUntil
        {
            get { return _state == LoopControllerStates.LoopUntil; }
            set
            {
                if (value)
                {
                    _state = LoopControllerStates.LoopUntil;
                    OnPropertyChanged("Activate");
                }
            }
        }

        private void CommandWrapper(Action a_actionToWrap)
        {
            IsActive = true;

            if (_timerInterval == 0) return;

            _excutionTimer = new Timer();

            a_actionToWrap();

            _excutionTimer.Interval = _timerInterval;

            _excutionTimer.Start();
        }
    }
}