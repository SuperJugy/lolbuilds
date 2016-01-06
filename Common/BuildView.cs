using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.jcandksolutions.lol {
  public interface BuildView : BaseView {
    void configureMasteryTrees(List<Branch> branches);
    string askForOpenFilePath();
  }
}
