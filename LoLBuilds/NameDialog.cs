using System.Windows.Forms;

namespace com.jcandksolutions.lol {
  public partial class NameDialog : Form {
    public NameDialog() {
      InitializeComponent();
    }

    public string ItemName {
      get {
        return NameTextBox.Text;
      }
      set {
        NameTextBox.Text = value;
      }
    }
  }
}
