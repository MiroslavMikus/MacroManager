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
        public MacroType MType => MacroType.Macro;
        public ICommand Execute
        {
            get
            {
                return new AsyncRelayCommand(async () =>
                {
                    IsRunning = true;
                    await Macro.Run(_tokenSource.Token);
                    IsRunning = false;
                });
            }
        }

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
        public bool IsRunning { get; set; }
        public bool IsActive { get; set; }

    }
}