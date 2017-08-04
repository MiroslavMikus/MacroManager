using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Macros_Manager.Annotations;
using Macros_Manager.UI.Content;

namespace Macros_Manager.Repository.LocalStorage
{
    public static class FileTool
    {
        public static string ReadFile(string a_path) => File.Exists(a_path) ? File.ReadAllText(a_path) : null;

        public static void StoreFile(string a_path, string a_content)
        {
            File.WriteAllText(a_path, a_content);
        }

        public static void EnsureExist(string a_path)
        {
            if (!Directory.Exists(a_path))
                Directory.CreateDirectory(a_path);
        }
    }

    public static class StorageDefs
    {
        private static readonly string _actualDirectory = System.AppDomain.CurrentDomain.BaseDirectory;
        public static string Settings = Path.Combine(_actualDirectory, "Settings");
        public static string AppSettings = Path.Combine(Settings, "AppSettings");
    }
}
