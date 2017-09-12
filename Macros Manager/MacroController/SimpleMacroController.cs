using System.Threading;
using System.Windows.Input;
using Macros_Manager.Macro;
using Macros_Manager.Unity;
using Macros_Manager.Unity.Enums;
using Macros_Manager.View.Tools;

namespace Macros_Manager.MacroController
{
    public class SimpleMacroController : BaseNotifyPropertyChanged, IMacroController
    {
        public SimpleMacroController(IMacro a_macro)
        {
            Macro = a_macro;
        }
        private readonly CancellationTokenSource _tokenSource = new CancellationTokenSource();

        private bool _executing;
        public bool Executing
        {
            get { return _executing; }
            set { this.MutateVerbose(ref _executing, value, RaisePropertyChanged()); }
        }
        public IMacro Macro { get; set; }

        public virtual MacroControllerType MControllerType => MacroControllerType.Macro;
        public virtual ICommand TestScript => new AsyncRelayCommand(async () =>
        {
            Executing = true;
            try
            {
                await Macro.Run(_tokenSource.Token);
            }
            finally
            {
                Executing = false;
            }

        });

        public virtual ICommand Activate => TestScript;

        public virtual ICommand Stop => new RelayCommand<object>(a =>
        {
            _tokenSource.Cancel();
            Executing = false;
        });

        private bool _isActive;
        public bool IsActive
        {
            get { return _isActive; }
            set { this.MutateVerbose(ref _isActive, value, RaisePropertyChanged()); }
        }
    }
}