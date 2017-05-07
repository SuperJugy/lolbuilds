using System;
using System.Windows.Forms;
using com.jcandksolutions.lol.DependencyInjection;
using com.jcandksolutions.lol.UI;

namespace com.jcandksolutions.lol {
  internal static class Program {
    /// <summary>
    ///   The main entry point for the application.
    /// </summary>
    [STAThread]
    private static void Main() {
      CommonInjector.setProvider(new CommonProvider());
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(new MainMenuViewImpl());
    }
  }
}
