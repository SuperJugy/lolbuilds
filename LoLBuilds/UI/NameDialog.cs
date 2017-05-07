using System.Windows.Forms;

namespace com.jcandksolutions.lol.UI {
  public partial class NameDialog : Form {
    public string ItemName {
      get {
        return NameTextBox.Text;
      }
      set {
        NameTextBox.Text = value;
      }
    }

    public NameDialog() {
      InitializeComponent();
    }
  }
}
