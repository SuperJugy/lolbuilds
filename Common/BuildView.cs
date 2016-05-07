using System.Collections.Generic;

namespace com.jcandksolutions.lol {
  public interface BuildView : BaseView {
    void configureMasteryTrees(List<Branch> branches);
    string askForOpenFilePath();
  }
}
