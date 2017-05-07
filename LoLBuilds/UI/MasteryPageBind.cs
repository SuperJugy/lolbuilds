using System.Windows.Forms;
using com.jcandksolutions.lol.Model;

namespace com.jcandksolutions.lol.UI {
  public class MasteryPageBind {
    public Mastery mProp { get; private set; }

    public MasteryPageBind(Mastery prop) {
      mProp = prop;
    }

    public void updateProperty(MasteryPage masteryPage, object control) {
      masteryPage[mProp.ID] = ((Button)control).Text;
    }
  }
}
