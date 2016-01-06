namespace com.jcandksolutions.lol {
  public interface MainMenuView : BaseView {
    void showSuccessMessage(string message);
    void showEditorWindow();
    void showBrowserWindow();
    void showCalculatorWindow();
    void setUpdateDBEnabled(bool enabled);
    void setBuildBrowserEnabled(bool enabled);
    void setBuildEditorEnabled(bool enabled);
    void setCalculatorEnabled(bool enabled);
  }
}
