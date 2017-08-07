using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Threading;
using Macros_Manager.Model.Interfaces;
using Macros_Manager.Repository.LocalStorage;

namespace Macros_Manager.Model
{
    public class AppSettings
    {
        public ObservableCollection<INode> Nodes { get; set; }
        public double WindowHeight { get; set; }
        public double WindowWidth { get; set; }
        public WindowState WinState { get; set; }
        public GridLength TreeWidth { get; set; }
        public double WinTop { get; set; }
        public double WinLeft { get; set; }

        public void Store()
        {
            FileTool.EnsureExist(StorageDefs.Settings);
            FileTool.StoreFile(StorageDefs.AppSettings, JsonStorage.SerializeWithType(this));
        }

        private AppSettings()
        {
            Dispatcher.CurrentDispatcher.ShutdownStarted += (a_sender, a_args) =>
            {
                Store();
            };
        }

        public static AppSettings GetSettings()
        {
            AppSettings result;

            try
            {
                throw new Exception("use fake settings");
                string settings = FileTool.ReadFile(StorageDefs.AppSettings);
                result = JsonStorage.DeserializeWithType<AppSettings>(settings);
            }
            catch (Exception ex)
            {
                //throw;
                result = new AppSettings()
                {
                    WindowHeight = 400.0,
                    WindowWidth = 550.0,
                    WinState = WindowState.Normal,
                    TreeWidth = new GridLength(200.0),
                    Nodes = new ObservableCollection<INode>(FakeTreeModel.GetNodes())
                };
            }
            return result;
        }
    }
}
