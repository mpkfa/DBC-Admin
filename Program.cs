using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CanDbcAdmin
{
    internal static class Program
    {
        public static readonly string RunPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
        public static readonly string StoragePath = $"{RunPath}/storage";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Directory.CreateDirectory(StoragePath);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
