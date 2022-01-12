using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Permissions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CanDbcAdmin {

  [SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.ControlAppDomain)]
  internal static class Program {
    public static readonly string RunPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
    public static readonly string StoragePath = $"{RunPath}/storage";

    public static void ShowErrorMessage(string message)
      => MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

    private static void UIThreadException(object sender, ThreadExceptionEventArgs args) {
      Exception e = (Exception)args.Exception;
      ShowErrorMessage(e.Message);
    }

    static void ExceptionHandler(object sender, UnhandledExceptionEventArgs args) {
      Exception e = (Exception)args.ExceptionObject;
      ShowErrorMessage(e.Message);
    }

    [STAThread]
    static void Main() {
      Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
      Application.ThreadException += new ThreadExceptionEventHandler(UIThreadException);
      AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(ExceptionHandler);

      Directory.CreateDirectory(StoragePath);

      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(new MainForm());
    }
  }
}
