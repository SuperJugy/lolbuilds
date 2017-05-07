using System.Windows.Forms;
using com.jcandksolutions.lol.Model;

namespace com.jcandksolutions.lol.UI {
  public class BuildBind {
    public enum Prop {
      Champion,
      ItemSet,
      RunePage,
      MasteryPage,
      StartAbilities,
      MaxOrder
    }

    private readonly Prop mProp;

    public BuildBind(Prop prop) {
      mProp = prop;
    }

    public void updateProperty(Build build, object control) {
      switch (mProp) {
        case Prop.Champion:
          build.ChampionName = (string)((ComboBox)control).SelectedItem;
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
          build.StartAbilities = ((TextBox)control).Text;
          break;
        case Prop.MaxOrder:
          build.MaxOrder = ((TextBox)control).Text;
          break;
      }
    }
  }
}
