using System.Windows.Forms;

namespace com.jcandksolutions.lol.UI {
  public partial class SettingsDialog : Form {
    public string APIKey {
      get {
        return APIKeyTextBox.Text;
      }
    }
    public string Locale {
      get {
        return LocaleTextBox.Text;
      }
    }
    public string Server {
      get {
        return ServerTextBox.Text;
      }
    }

    public SettingsDialog() {
      InitializeComponent();
    }

    public void setSettings(string apiKey, string locale, string server) {
      APIKeyTextBox.Text = apiKey;
      LocaleTextBox.Text = locale;
      ServerTextBox.Text = server;
    }
  }
}
