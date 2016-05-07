using System;
using System.Windows.Forms;

namespace com.jcandksolutions.lol {
  public partial class MainMenuViewImpl : Form, MainMenuView {
    private readonly MainMenuPresenter mPresenter;

    public MainMenuViewImpl() {
      InitializeComponent();
      mPresenter = new MainMenuPresenter(this);
    }

    public void showErrorMessage(string message) {
      MessageBox.Show(message, "Error", MessageBoxButtons.OK);
    }

    public void showSuccessMessage(string message) {
      MessageBox.Show(message, "Success", MessageBoxButtons.OK);
    }

    public void showEditorWindow() {
      var editor = new EditorViewImpl();
      Hide();
      editor.ShowDialog();
      Show();
    }

    public void showBrowserWindow() {
      var browser = new BrowserViewImpl();
      Hide();
      browser.ShowDialog();
      Show();
    }

    public void showCalculatorWindow() {
      var calculator = new CalculatorViewImpl();
      Hide();
      calculator.ShowDialog();
      Show();
    }

    public void setUpdateDBEnabled(bool enabled) {
      UpdateDBButton.Enabled = enabled;
    }

    public void setBuildBrowserEnabled(bool enabled) {
      BuildBrowserButton.Enabled = enabled;
    }

    public void setBuildEditorEnabled(bool enabled) {
      BuildEditorButton.Enabled = enabled;
    }

    public void setCalculatorEnabled(bool enabled) {
      CalculatorButton.Enabled = enabled;
    }

    private void UpdateDBButton_Click(object sender, EventArgs e) {
      mPresenter.onUpdateDBButtonClicked();
    }

    private void BuildEditorButton_Click(object sender, EventArgs e) {
      mPresenter.onBuildEditorButtonClicked();
    }

    private void BuildBrowserButton_Click(object sender, EventArgs e) {
      mPresenter.onBuildBrowserButtonClicked();
    }

    private void CalculatorButton_Click(object sender, EventArgs e) {
      mPresenter.onCalculatorButtonClicked();
    }

    private void MainMenuView_Load(object sender, EventArgs e) {
      mPresenter.start();
    }

    private void settingsToolStripMenuItem_Click(object sender, EventArgs e) {
      var settingsDialog = new SettingsDialog();
      settingsDialog.setSettings(mPresenter.APIKey, mPresenter.Locale, mPresenter.Server);
      if (settingsDialog.ShowDialog() == DialogResult.OK) {
        mPresenter.saveSettings(settingsDialog.APIKey, settingsDialog.Locale, settingsDialog.Server);
      }
    }
  }
}
