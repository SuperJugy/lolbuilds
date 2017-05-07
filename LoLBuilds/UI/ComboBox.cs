using System;

namespace com.jcandksolutions.lol.UI {
  public class ComboBox : System.Windows.Forms.ComboBox {
    private int mLastIndex = -1;
    private object mLastItem;

    protected override void OnSelectedItemChanged(EventArgs e) {
      if (mLastItem != SelectedItem) {
        base.OnSelectedItemChanged(e);
        mLastItem = SelectedItem;
      }
    }

    protected override void OnSelectedIndexChanged(EventArgs e) {
      if (mLastIndex != SelectedIndex) {
        base.OnSelectedIndexChanged(e);
        mLastIndex = SelectedIndex;
      }
    }
  }
}
