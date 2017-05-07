using com.jcandksolutions.lol.Model;

namespace com.jcandksolutions.lol.UI {
  public class ItemSetBind {
    public enum Prop {
      Item1,
      Item2,
      Item3,
      Item4,
      Item5,
      Item6,
      Item7,
      Item8,
      Item9,
      Item10,
      Item11,
      Item12,
      Item13,
      Item14,
      Item15,
      Item16,
      Item17,
      Item18,
      Item19,
      Item20,
      Item21,
      Item22,
      Item23,
      Item24
    }

    private readonly Prop mProp;

    public ItemSetBind(Prop prop) {
      mProp = prop;
    }

    public void updateProperty(ItemSet itemSet, object control) {
      switch (mProp) {
        case Prop.Item1:
          itemSet.Item1 = (Item)((ComboBox)control).SelectedItem;
          break;
        case Prop.Item2:
          itemSet.Item2 = (Item)((ComboBox)control).SelectedItem;
          break;
        case Prop.Item3:
          itemSet.Item3 = (Item)((ComboBox)control).SelectedItem;
          break;
        case Prop.Item4:
          itemSet.Item4 = (Item)((ComboBox)control).SelectedItem;
          break;
        case Prop.Item5:
          itemSet.Item5 = (Item)((ComboBox)control).SelectedItem;
          break;
        case Prop.Item6:
          itemSet.Item6 = (Item)((ComboBox)control).SelectedItem;
          break;
        case Prop.Item7:
          itemSet.Item7 = (Item)((ComboBox)control).SelectedItem;
          break;
        case Prop.Item8:
          itemSet.Item8 = (Item)((ComboBox)control).SelectedItem;
          break;
        case Prop.Item9:
          itemSet.Item9 = (Item)((ComboBox)control).SelectedItem;
          break;
        case Prop.Item10:
          itemSet.Item10 = (Item)((ComboBox)control).SelectedItem;
          break;
        case Prop.Item11:
          itemSet.Item11 = (Item)((ComboBox)control).SelectedItem;
          break;
        case Prop.Item12:
          itemSet.Item12 = (Item)((ComboBox)control).SelectedItem;
          break;
        case Prop.Item13:
          itemSet.Item13 = (Item)((ComboBox)control).SelectedItem;
          break;
        case Prop.Item14:
          itemSet.Item14 = (Item)((ComboBox)control).SelectedItem;
          break;
        case Prop.Item15:
          itemSet.Item15 = (Item)((ComboBox)control).SelectedItem;
          break;
        case Prop.Item16:
          itemSet.Item16 = (Item)((ComboBox)control).SelectedItem;
          break;
        case Prop.Item17:
          itemSet.Item17 = (Item)((ComboBox)control).SelectedItem;
          break;
        case Prop.Item18:
          itemSet.Item18 = (Item)((ComboBox)control).SelectedItem;
          break;
        case Prop.Item19:
          itemSet.Item19 = (Item)((ComboBox)control).SelectedItem;
          break;
        case Prop.Item20:
          itemSet.Item20 = (Item)((ComboBox)control).SelectedItem;
          break;
        case Prop.Item21:
          itemSet.Item21 = (Item)((ComboBox)control).SelectedItem;
          break;
        case Prop.Item22:
          itemSet.Item22 = (Item)((ComboBox)control).SelectedItem;
          break;
        case Prop.Item23:
          itemSet.Item23 = (Item)((ComboBox)control).SelectedItem;
          break;
        case Prop.Item24:
          itemSet.Item24 = (Item)((ComboBox)control).SelectedItem;
          break;
      }
    }
  }
}
