using System.Windows.Forms;

namespace com.jcandksolutions.lol {
  public class BuildBind {
    public enum Prop {
      Champion,
      ItemSet,
      RunePage,
      MasteryPage,
      StartAbilities,
      MaxOrder
    }
    private Prop mProp;

    public BuildBind(Prop prop) {
      mProp = prop;
    }

    public void updateProperty(Build build, object control) {
      switch (mProp) {
        case Prop.Champion:
          build.Champion = (string)((ComboBox)control).SelectedItem;
          break;
        case Prop.ItemSet:
          build.ItemSet = (string)((ComboBox)control).SelectedItem;
          break;
        case Prop.RunePage:
          build.RunePage = (string)((ComboBox)control).SelectedItem;
          break;
        case Prop.MasteryPage:
          build.MasteryPage = (string)((ComboBox)control).SelectedItem;
          break;
        case Prop.StartAbilities:
          build.StartAbilities = (string)((TextBox)control).Text;
          break;
        case Prop.MaxOrder:
          build.MaxOrder = (string)((TextBox)control).Text;
          break;
      }
    }
  }
}
