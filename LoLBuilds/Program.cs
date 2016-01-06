using System;
using System.Windows.Forms;

namespace com.jcandksolutions.lol {
  static class Program {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main() {
      CommonInjector.setProvider(new CommonProvider());
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(new MainMenuViewImpl());
    }
  }
}
