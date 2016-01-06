namespace com.jcandksolutions.lol {
  public class RunePageBind {
    public enum Prop {
      Mark1,
      Mark2,
      Mark3,
      Mark4,
      Mark5,
      Mark6,
      Mark7,
      Mark8,
      Mark9,
      Seal1,
      Seal2,
      Seal3,
      Seal4,
      Seal5,
      Seal6,
      Seal7,
      Seal8,
      Seal9,
      Glyph1,
      Glyph2,
      Glyph3,
      Glyph4,
      Glyph5,
      Glyph6,
      Glyph7,
      Glyph8,
      Glyph9,
      Quint1,
      Quint2,
      Quint3
    }
    private Prop mProp;

    public RunePageBind(Prop prop) {
      mProp = prop;
    }

    public void updateProperty(RunePage runePage, object control) {
      switch (mProp) {
        case Prop.Mark1:
          runePage.Mark1 = (Rune)((ComboBox)control).SelectedItem;
          break;
        case Prop.Mark2:
          runePage.Mark2 = (Rune)((ComboBox)control).SelectedItem;
          break;
        case Prop.Mark3:
          runePage.Mark3 = (Rune)((ComboBox)control).SelectedItem;
          break;
        case Prop.Mark4:
          runePage.Mark4 = (Rune)((ComboBox)control).SelectedItem;
          break;
        case Prop.Mark5:
          runePage.Mark5 = (Rune)((ComboBox)control).SelectedItem;
          break;
        case Prop.Mark6:
          runePage.Mark6 = (Rune)((ComboBox)control).SelectedItem;
          break;
        case Prop.Mark7:
          runePage.Mark7 = (Rune)((ComboBox)control).SelectedItem;
          break;
        case Prop.Mark8:
          runePage.Mark8 = (Rune)((ComboBox)control).SelectedItem;
          break;
        case Prop.Mark9:
          runePage.Mark9 = (Rune)((ComboBox)control).SelectedItem;
          break;
        case Prop.Seal1:
          runePage.Seal1 = (Rune)((ComboBox)control).SelectedItem;
          break;
        case Prop.Seal2:
          runePage.Seal2 = (Rune)((ComboBox)control).SelectedItem;
          break;
        case Prop.Seal3:
          runePage.Seal3 = (Rune)((ComboBox)control).SelectedItem;
          break;
        case Prop.Seal4:
          runePage.Seal4 = (Rune)((ComboBox)control).SelectedItem;
          break;
        case Prop.Seal5:
          runePage.Seal5 = (Rune)((ComboBox)control).SelectedItem;
          break;
        case Prop.Seal6:
          runePage.Seal6 = (Rune)((ComboBox)control).SelectedItem;
          break;
        case Prop.Seal7:
          runePage.Seal7 = (Rune)((ComboBox)control).SelectedItem;
          break;
        case Prop.Seal8:
          runePage.Seal8 = (Rune)((ComboBox)control).SelectedItem;
          break;
        case Prop.Seal9:
          runePage.Seal9 = (Rune)((ComboBox)control).SelectedItem;
          break;
        case Prop.Glyph1:
          runePage.Glyph1 = (Rune)((ComboBox)control).SelectedItem;
          break;
        case Prop.Glyph2:
          runePage.Glyph2 = (Rune)((ComboBox)control).SelectedItem;
          break;
        case Prop.Glyph3:
          runePage.Glyph3 = (Rune)((ComboBox)control).SelectedItem;
          break;
        case Prop.Glyph4:
          runePage.Glyph4 = (Rune)((ComboBox)control).SelectedItem;
          break;
        case Prop.Glyph5:
          runePage.Glyph5 = (Rune)((ComboBox)control).SelectedItem;
          break;
        case Prop.Glyph6:
          runePage.Glyph6 = (Rune)((ComboBox)control).SelectedItem;
          break;
        case Prop.Glyph7:
          runePage.Glyph7 = (Rune)((ComboBox)control).SelectedItem;
          break;
        case Prop.Glyph8:
          runePage.Glyph8 = (Rune)((ComboBox)control).SelectedItem;
          break;
        case Prop.Glyph9:
          runePage.Glyph9 = (Rune)((ComboBox)control).SelectedItem;
          break;
        case Prop.Quint1:
          runePage.Quint1 = (Rune)((ComboBox)control).SelectedItem;
          break;
        case Prop.Quint2:
          runePage.Quint2 = (Rune)((ComboBox)control).SelectedItem;
          break;
        case Prop.Quint3:
          runePage.Quint3 = (Rune)((ComboBox)control).SelectedItem;
          break;
      }
    }
  }
}
