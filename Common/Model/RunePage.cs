using System.Drawing;
using com.jcandksolutions.lol.BusinessLogic;
using com.jcandksolutions.lol.DependencyInjection;
using Newtonsoft.Json;

namespace com.jcandksolutions.lol.Model {
  [JsonObject(MemberSerialization.OptIn)]
  public class RunePage {
    [JsonProperty("name")]
    public string RunePageName { get; set; }
    [JsonProperty("mark1")]
    public string Mark1ID {
      get
      {
        return Mark1.ID;
      }
      set {
        Mark1 = CommonInjector.provideBuildManager().getMarkByID(value);
      }
    }
    [JsonProperty("mark2")]
    public string Mark2ID {
      get {
        return Mark2.ID;
      }
      set {
        Mark2 = CommonInjector.provideBuildManager().getMarkByID(value);
      }
    }
    [JsonProperty("mark3")]
    public string Mark3ID {
      get {
        return Mark3.ID;
      }
      set {
        Mark3 = CommonInjector.provideBuildManager().getMarkByID(value);
      }
    }
    [JsonProperty("mark4")]
    public string Mark4ID {
      get {
        return Mark4.ID;
      }
      set {
        Mark4 = CommonInjector.provideBuildManager().getMarkByID(value);
      }
    }
    [JsonProperty("mark5")]
    public string Mark5ID {
      get {
        return Mark5.ID;
      }
      set {
        Mark5 = CommonInjector.provideBuildManager().getMarkByID(value);
      }
    }
    [JsonProperty("mark6")]
    public string Mark6ID {
      get {
        return Mark6.ID;
      }
      set {
        Mark6 = CommonInjector.provideBuildManager().getMarkByID(value);
      }
    }
    [JsonProperty("mark7")]
    public string Mark7ID {
      get {
        return Mark7.ID;
      }
      set {
        Mark7 = CommonInjector.provideBuildManager().getMarkByID(value);
      }
    }
    [JsonProperty("mark8")]
    public string Mark8ID {
      get {
        return Mark8.ID;
      }
      set {
        Mark8 = CommonInjector.provideBuildManager().getMarkByID(value);
      }
    }
    [JsonProperty("mark9")]
    public string Mark9ID {
      get {
        return Mark9.ID;
      }
      set {
        Mark9 = CommonInjector.provideBuildManager().getMarkByID(value);
      }
    }
    [JsonProperty("seal1")]
    public string Seal1ID {
      get {
        return Seal1.ID;
      }
      set {
        Seal1 = CommonInjector.provideBuildManager().getSealByID(value);
      }
    }
    [JsonProperty("seal2")]
    public string Seal2ID {
      get {
        return Seal2.ID;
      }
      set {
        Seal2 = CommonInjector.provideBuildManager().getSealByID(value);
      }
    }
    [JsonProperty("seal3")]
    public string Seal3ID {
      get {
        return Seal3.ID;
      }
      set {
        Seal3 = CommonInjector.provideBuildManager().getSealByID(value);
      }
    }
    [JsonProperty("seal4")]
    public string Seal4ID {
      get {
        return Seal4.ID;
      }
      set {
        Seal4 = CommonInjector.provideBuildManager().getSealByID(value);
      }
    }
    [JsonProperty("seal5")]
    public string Seal5ID {
      get {
        return Seal5.ID;
      }
      set {
        Seal5 = CommonInjector.provideBuildManager().getSealByID(value);
      }
    }
    [JsonProperty("seal6")]
    public string Seal6ID {
      get {
        return Seal6.ID;
      }
      set {
        Seal6 = CommonInjector.provideBuildManager().getSealByID(value);
      }
    }
    [JsonProperty("seal7")]
    public string Seal7ID {
      get {
        return Seal7.ID;
      }
      set {
        Seal7 = CommonInjector.provideBuildManager().getSealByID(value);
      }
    }
    [JsonProperty("seal8")]
    public string Seal8ID {
      get {
        return Seal8.ID;
      }
      set {
        Seal8 = CommonInjector.provideBuildManager().getSealByID(value);
      }
    }
    [JsonProperty("seal9")]
    public string Seal9ID {
      get {
        return Seal9.ID;
      }
      set {
        Seal9 = CommonInjector.provideBuildManager().getSealByID(value);
      }
    }
    [JsonProperty("glyph1")]
    public string Glyph1ID {
      get {
        return Glyph1.ID;
      }
      set {
        Glyph1 = CommonInjector.provideBuildManager().getGlyphByID(value);
      }
    }
    [JsonProperty("glyph2")]
    public string Glyph2ID {
      get {
        return Glyph2.ID;
      }
      set {
        Glyph2 = CommonInjector.provideBuildManager().getGlyphByID(value);
      }
    }
    [JsonProperty("glyph3")]
    public string Glyph3ID {
      get {
        return Glyph3.ID;
      }
      set {
        Glyph3 = CommonInjector.provideBuildManager().getGlyphByID(value);
      }
    }
    [JsonProperty("glyph4")]
    public string Glyph4ID {
      get {
        return Glyph4.ID;
      }
      set {
        Glyph4 = CommonInjector.provideBuildManager().getGlyphByID(value);
      }
    }
    [JsonProperty("glyph5")]
    public string Glyph5ID {
      get {
        return Glyph5.ID;
      }
      set {
        Glyph5 = CommonInjector.provideBuildManager().getGlyphByID(value);
      }
    }
    [JsonProperty("glyph6")]
    public string Glyph6ID {
      get {
        return Glyph6.ID;
      }
      set {
        Glyph6 = CommonInjector.provideBuildManager().getGlyphByID(value);
      }
    }
    [JsonProperty("glyph7")]
    public string Glyph7ID {
      get {
        return Glyph7.ID;
      }
      set {
        Glyph7 = CommonInjector.provideBuildManager().getGlyphByID(value);
      }
    }
    [JsonProperty("glyph8")]
    public string Glyph8ID {
      get {
        return Glyph8.ID;
      }
      set {
        Glyph8 = CommonInjector.provideBuildManager().getGlyphByID(value);
      }
    }
    [JsonProperty("glyph9")]
    public string Glyph9ID {
      get {
        return Glyph9.ID;
      }
      set {
        Glyph9 = CommonInjector.provideBuildManager().getGlyphByID(value);
      }
    }
    [JsonProperty("quint1")]
    public string Quint1ID {
      get {
        return Quint1.ID;
      }
      set {
        Quint1 = CommonInjector.provideBuildManager().getQuintByID(value);
      }
    }
    [JsonProperty("quint2")]
    public string Quint2ID {
      get {
        return Quint2.ID;
      }
      set {
        Quint2 = CommonInjector.provideBuildManager().getQuintByID(value);
      }
    }
    [JsonProperty("quint3")]
    public string Quint3ID {
      get {
        return Quint3.ID;
      }
      set {
        Quint3 = CommonInjector.provideBuildManager().getQuintByID(value);
      }
    }
    public Rune Mark1 { get; set; }
    public Rune Mark2 { get; set; }
    public Rune Mark3 { get; set; }
    public Rune Mark4 { get; set; }
    public Rune Mark5 { get; set; }
    public Rune Mark6 { get; set; }
    public Rune Mark7 { get; set; }
    public Rune Mark8 { get; set; }
    public Rune Mark9 { get; set; }
    public Rune Seal1 { get; set; }
    public Rune Seal2 { get; set; }
    public Rune Seal3 { get; set; }
    public Rune Seal4 { get; set; }
    public Rune Seal5 { get; set; }
    public Rune Seal6 { get; set; }
    public Rune Seal7 { get; set; }
    public Rune Seal8 { get; set; }
    public Rune Seal9 { get; set; }
    public Rune Glyph1 { get; set; }
    public Rune Glyph2 { get; set; }
    public Rune Glyph3 { get; set; }
    public Rune Glyph4 { get; set; }
    public Rune Glyph5 { get; set; }
    public Rune Glyph6 { get; set; }
    public Rune Glyph7 { get; set; }
    public Rune Glyph8 { get; set; }
    public Rune Glyph9 { get; set; }
    public Rune Quint1 { get; set; }
    public Rune Quint2 { get; set; }
    public Rune Quint3 { get; set; }
    public Bitmap Mark1Image {
      get {
        return Mark1.Image;
      }
    }
    public Bitmap Mark2Image {
      get {
        return Mark2.Image;
      }
    }
    public Bitmap Mark3Image {
      get {
        return Mark3.Image;
      }
    }
    public Bitmap Mark4Image {
      get {
        return Mark4.Image;
      }
    }
    public Bitmap Mark5Image {
      get {
        return Mark5.Image;
      }
    }
    public Bitmap Mark6Image {
      get {
        return Mark6.Image;
      }
    }
    public Bitmap Mark7Image {
      get {
        return Mark7.Image;
      }
    }
    public Bitmap Mark8Image {
      get {
        return Mark8.Image;
      }
    }
    public Bitmap Mark9Image {
      get {
        return Mark9.Image;
      }
    }
    public Bitmap Seal1Image {
      get {
        return Seal1.Image;
      }
    }
    public Bitmap Seal2Image {
      get {
        return Seal2.Image;
      }
    }
    public Bitmap Seal3Image {
      get {
        return Seal3.Image;
      }
    }
    public Bitmap Seal4Image {
      get {
        return Seal4.Image;
      }
    }
    public Bitmap Seal5Image {
      get {
        return Seal5.Image;
      }
    }
    public Bitmap Seal6Image {
      get {
        return Seal6.Image;
      }
    }
    public Bitmap Seal7Image {
      get {
        return Seal7.Image;
      }
    }
    public Bitmap Seal8Image {
      get {
        return Seal8.Image;
      }
    }
    public Bitmap Seal9Image {
      get {
        return Seal9.Image;
      }
    }
    public Bitmap Glyph1Image {
      get {
        return Glyph1.Image;
      }
    }
    public Bitmap Glyph2Image {
      get {
        return Glyph2.Image;
      }
    }
    public Bitmap Glyph3Image {
      get {
        return Glyph3.Image;
      }
    }
    public Bitmap Glyph4Image {
      get {
        return Glyph4.Image;
      }
    }
    public Bitmap Glyph5Image {
      get {
        return Glyph5.Image;
      }
    }
    public Bitmap Glyph6Image {
      get {
        return Glyph6.Image;
      }
    }
    public Bitmap Glyph7Image {
      get {
        return Glyph7.Image;
      }
    }
    public Bitmap Glyph8Image {
      get {
        return Glyph8.Image;
      }
    }
    public Bitmap Glyph9Image {
      get {
        return Glyph9.Image;
      }
    }
    public Bitmap Quint1Image {
      get {
        return Quint1.Image;
      }
    }
    public Bitmap Quint2Image {
      get {
        return Quint2.Image;
      }
    }
    public Bitmap Quint3Image {
      get {
        return Quint3.Image;
      }
    }

    public RunePage() {
      RunePageName = "";
      BuildManager manager = CommonInjector.provideBuildManager();
      Rune emptyRune = manager.EmptyRune;
      Mark1 = emptyRune;
      Mark2 = emptyRune;
      Mark3 = emptyRune;
      Mark4 = emptyRune;
      Mark5 = emptyRune;
      Mark6 = emptyRune;
      Mark7 = emptyRune;
      Mark8 = emptyRune;
      Mark9 = emptyRune;
      Seal1 = emptyRune;
      Seal2 = emptyRune;
      Seal3 = emptyRune;
      Seal4 = emptyRune;
      Seal5 = emptyRune;
      Seal6 = emptyRune;
      Seal7 = emptyRune;
      Seal8 = emptyRune;
      Seal9 = emptyRune;
      Glyph1 = emptyRune;
      Glyph2 = emptyRune;
      Glyph3 = emptyRune;
      Glyph4 = emptyRune;
      Glyph5 = emptyRune;
      Glyph6 = emptyRune;
      Glyph7 = emptyRune;
      Glyph8 = emptyRune;
      Glyph9 = emptyRune;
      Quint1 = emptyRune;
      Quint2 = emptyRune;
      Quint3 = emptyRune;
    }

    public RunePage(RunePage runePage) {
      RunePageName = "";
      Mark1 = runePage.Mark1;
      Mark2 = runePage.Mark2;
      Mark3 = runePage.Mark3;
      Mark4 = runePage.Mark4;
      Mark5 = runePage.Mark5;
      Mark6 = runePage.Mark6;
      Mark7 = runePage.Mark7;
      Mark8 = runePage.Mark8;
      Mark9 = runePage.Mark9;
      Seal1 = runePage.Seal1;
      Seal2 = runePage.Seal2;
      Seal3 = runePage.Seal3;
      Seal4 = runePage.Seal4;
      Seal5 = runePage.Seal5;
      Seal6 = runePage.Seal6;
      Seal7 = runePage.Seal7;
      Seal8 = runePage.Seal8;
      Seal9 = runePage.Seal9;
      Glyph1 = runePage.Glyph1;
      Glyph2 = runePage.Glyph2;
      Glyph3 = runePage.Glyph3;
      Glyph4 = runePage.Glyph4;
      Glyph5 = runePage.Glyph5;
      Glyph6 = runePage.Glyph6;
      Glyph7 = runePage.Glyph7;
      Glyph8 = runePage.Glyph8;
      Glyph9 = runePage.Glyph9;
      Quint1 = runePage.Quint1;
      Quint2 = runePage.Quint2;
      Quint3 = runePage.Quint3;
    }
  }
}
