using System.Windows.Forms;

namespace com.jcandksolutions.lol {
  public partial class DBEditorViewImpl : Form, DBEditorView {
    private readonly DBEditorPresenter mPresenter;

    public DBEditorViewImpl() {
      InitializeComponent();
      mPresenter = new DBEditorPresenter(this);
    }

    private void DBEditorViewImpl_Load(object sender, System.EventArgs e) {
      mPresenter.onStart();
    }
  }
}
