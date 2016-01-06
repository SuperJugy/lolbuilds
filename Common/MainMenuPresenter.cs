﻿using System;
using System.Configuration;
using System.IO;

namespace com.jcandksolutions.lol {
  public class MainMenuPresenter {
    private MainMenuView mView;
    public string APIKey {
      get {
        return ConfigurationManager.AppSettings["apikey"];
      }
    }
    public string Locale {
      get {
        return ConfigurationManager.AppSettings["locale"];
      }
    }
    public string Server {
      get {
        return ConfigurationManager.AppSettings["server"];
      }
    }

    public MainMenuPresenter(MainMenuView view) {
      mView = view;
    }

    public void onUpdateDBButtonClicked() {
      try {
        var updater = CommonInjector.provideDBUpdater();
        updater.update();
        mView.showSuccessMessage("DB Updated correctly");
        verifyDBFile();
      } catch (Exception ex) {
        mView.showErrorMessage(ex.Message + "\n\r" + ex.StackTrace);
        mView.Close();
      }
    }

    public void onBuildEditorButtonClicked() {
      mView.showEditorWindow();
    }

    public void onBuildBrowserButtonClicked() {
      mView.showBrowserWindow();
    }

    public void onCalculatorButtonClicked() {
      mView.showCalculatorWindow();
    }

    public void start() {
      verifyAPIKey();
      verifyDBFile();
    }

    private void verifyDBFile() {
      bool enabled = File.Exists("./db.json");
      mView.setBuildBrowserEnabled(enabled);
      mView.setBuildEditorEnabled(enabled);
      mView.setCalculatorEnabled(enabled);
    }

    private void verifyAPIKey() {
      string apikey = APIKey;
      mView.setUpdateDBEnabled(!string.IsNullOrWhiteSpace(apikey));
    }

    public void saveSettings(string APIKey, string locale, string server) {
      Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
      config.AppSettings.Settings.Remove("apikey");
      config.AppSettings.Settings.Remove("locale");
      config.AppSettings.Settings.Remove("server");
      config.AppSettings.Settings.Add("apikey", APIKey);
      config.AppSettings.Settings.Add("locale", locale);
      config.AppSettings.Settings.Add("server", server);
      config.Save(ConfigurationSaveMode.Minimal);
      ConfigurationManager.RefreshSection("appSettings");
      verifyAPIKey();
    }
  }
}
