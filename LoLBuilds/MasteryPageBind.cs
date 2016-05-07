using System.Windows.Forms;

namespace com.jcandksolutions.lol {
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
