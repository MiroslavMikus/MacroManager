using System.Threading;
using System.Windows.Input;
using Macros_Manager.Macro;
using Macros_Manager.UI.Tools;
using Macros_Manager.Unity;

namespace Macros_Manager.MacroController
{
    public class SimpleMacroController : BaseNotifyPropertyChanged, IMacroController
    {
        public SimpleMacroController(IMacro a_macro)
        {
            Macro = a_macro;
        }
        private readonly CancellationTokenSource _tokenSource = new CancellationTokenSource();
        public IMacro Macro { get; set; }
        public virtual MacroType MType => MacroType.Macro;
        public virtual ICommand Execute => new AsyncRelayCommand(async () =>
        {
            await Macro.Run(_tokenSource.Token);
        });

        public ICommand Stop
        {
            get
            {
                return new RelayCommand<object>(a =>
                {
                    _tokenSource.Cancel();
                });
            }
        }

        private bool _isRunning;
        public bool IsRunning
        {
            get { return _isRunning; }
            set { this.MutateVerbose(ref _isRunning, value, RaisePropertyChanged()); }
        }
        private bool _isActive;
        public bool IsActive
        {
            get { return _isActive; }
            set { this.MutateVerbose(ref _isActive, value, RaisePropertyChanged()); }
        }
    }
}