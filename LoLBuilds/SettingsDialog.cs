﻿using System.Windows.Forms;

namespace com.jcandksolutions.lol {
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

    public void setSettings(string APIKey, string locale, string server) {
      APIKeyTextBox.Text = APIKey;
      LocaleTextBox.Text = locale;
      ServerTextBox.Text = server;
    }
  }
}
