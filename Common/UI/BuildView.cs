using System.Collections.Generic;
using com.jcandksolutions.lol.Model;

namespace com.jcandksolutions.lol.UI {
  public interface BuildView : BaseView {
    void configureMasteryTrees(List<Branch> branches);
    string askForOpenFilePath();
  }
}
