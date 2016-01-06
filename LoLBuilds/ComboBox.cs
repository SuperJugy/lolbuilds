using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.jcandksolutions.lol {
  public class ComboBox : System.Windows.Forms.ComboBox {
    private object mLastItem;
    private int mLastIndex = -1;

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
