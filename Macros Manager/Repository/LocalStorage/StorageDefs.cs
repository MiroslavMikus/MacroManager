using System;
using System.IO;

namespace Macros_Manager.Repository.LocalStorage
{
    public static class StorageDefs
    {
        private static readonly string _actualDirectory = AppDomain.CurrentDomain.BaseDirectory;
        public static string Settings = Path.Combine(_actualDirectory, "Settings");
        public static string AppSettings = Path.Combine(Settings, "AppSettings");
    }
}