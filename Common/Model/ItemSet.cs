using System.Drawing;
using com.jcandksolutions.lol.BusinessLogic;
using com.jcandksolutions.lol.DependencyInjection;
using Newtonsoft.Json;

namespace com.jcandksolutions.lol.Model {
  [JsonObject(MemberSerialization.OptIn)]
  public class ItemSet {
    [JsonProperty("name")]
    public string ItemSetName { get; set; }

    [JsonProperty("item1")]
    public string Item1ID
    {
      get
      {
        return Item1.ID;
      }
      set
      {
        Item1 = CommonInjector.provideBuildManager().getItemByID(value);
      }
    }
    [JsonProperty("item2")]
    public string Item2ID {
      get {
        return Item2.ID;
      }
      set {
        Item2 = CommonInjector.provideBuildManager().getItemByID(value);
      }
    }
    [JsonProperty("item3")]
    public string Item3ID {
      get {
        return Item3.ID;
      }
      set {
        Item3 = CommonInjector.provideBuildManager().getItemByID(value);
      }
    }
    [JsonProperty("item4")]
    public string Item4ID {
      get {
        return Item4.ID;
      }
      set {
        Item4 = CommonInjector.provideBuildManager().getItemByID(value);
      }
    }
    [JsonProperty("item5")]
    public string Item5ID {
      get {
        return Item5.ID;
      }
      set {
        Item5 = CommonInjector.provideBuildManager().getItemByID(value);
      }
    }
    [JsonProperty("item6")]
    public string Item6ID {
      get {
        return Item6.ID;
      }
      set {
        Item6 = CommonInjector.provideBuildManager().getItemByID(value);
      }
    }
    [JsonProperty("item7")]
    public string Item7ID {
      get {
        return Item7.ID;
      }
      set {
        Item7 = CommonInjector.provideBuildManager().getItemByID(value);
      }
    }
    [JsonProperty("item8")]
    public string Item8ID {
      get {
        return Item8.ID;
      }
      set {
        Item8 = CommonInjector.provideBuildManager().getItemByID(value);
      }
    }
    [JsonProperty("item9")]
    public string Item9ID {
      get {
        return Item9.ID;
      }
      set {
        Item9 = CommonInjector.provideBuildManager().getItemByID(value);
      }
    }
    [JsonProperty("item10")]
    public string Item10ID {
      get {
        return Item10.ID;
      }
      set {
        Item10 = CommonInjector.provideBuildManager().getItemByID(value);
      }
    }
    [JsonProperty("item11")]
    public string Item11ID {
      get {
        return Item11.ID;
      }
      set {
        Item11 = CommonInjector.provideBuildManager().getItemByID(value);
      }
    }
    [JsonProperty("item12")]
    public string Item12ID {
      get {
        return Item12.ID;
      }
      set {
        Item12 = CommonInjector.provideBuildManager().getItemByID(value);
      }
    }
    [JsonProperty("item13")]
    public string Item13ID {
      get {
        return Item13.ID;
      }
      set {
        Item13 = CommonInjector.provideBuildManager().getItemByID(value);
      }
    }
    [JsonProperty("item14")]
    public string Item14ID {
      get {
        return Item14.ID;
      }
      set {
        Item14 = CommonInjector.provideBuildManager().getItemByID(value);
      }
    }
    [JsonProperty("item15")]
    public string Item15ID {
      get {
        return Item15.ID;
      }
      set {
        Item15 = CommonInjector.provideBuildManager().getItemByID(value);
      }
    }
    [JsonProperty("item16")]
    public string Item16ID {
      get {
        return Item16.ID;
      }
      set {
        Item16 = CommonInjector.provideBuildManager().getItemByID(value);
      }
    }
    [JsonProperty("item17")]
    public string Item17ID {
      get {
        return Item17.ID;
      }
      set {
        Item17 = CommonInjector.provideBuildManager().getItemByID(value);
      }
    }
    [JsonProperty("item18")]
    public string Item18ID {
      get {
        return Item18.ID;
      }
      set {
        Item18 = CommonInjector.provideBuildManager().getItemByID(value);
      }
    }
    [JsonProperty("item19")]
    public string Item19ID {
      get {
        return Item19.ID;
      }
      set {
        Item19 = CommonInjector.provideBuildManager().getItemByID(value);
      }
    }
    [JsonProperty("item20")]
    public string Item20ID {
      get {
        return Item20.ID;
      }
      set {
        Item20 = CommonInjector.provideBuildManager().getItemByID(value);
      }
    }
    [JsonProperty("item21")]
    public string Item21ID {
      get {
        return Item21.ID;
      }
      set {
        Item21 = CommonInjector.provideBuildManager().getItemByID(value);
      }
    }
    [JsonProperty("item22")]
    public string Item22ID {
      get {
        return Item22.ID;
      }
      set {
        Item22 = CommonInjector.provideBuildManager().getItemByID(value);
      }
    }
    [JsonProperty("item23")]
    public string Item23ID {
      get {
        return Item23.ID;
      }
      set {
        Item23 = CommonInjector.provideBuildManager().getItemByID(value);
      }
    }
    [JsonProperty("item24")]
    public string Item24ID {
      get {
        return Item24.ID;
      }
      set {
        Item24 = CommonInjector.provideBuildManager().getItemByID(value);
      }
    }
    public Item Item1 { get; set; }
    public Item Item2 { get; set; }
    public Item Item3 { get; set; }
    public Item Item4 { get; set; }
    public Item Item5 { get; set; }
    public Item Item6 { get; set; }
    public Item Item7 { get; set; }
    public Item Item8 { get; set; }
    public Item Item9 { get; set; }
    public Item Item10 { get; set; }
    public Item Item11 { get; set; }
    public Item Item12 { get; set; }
    public Item Item13 { get; set; }
    public Item Item14 { get; set; }
    public Item Item15 { get; set; }
    public Item Item16 { get; set; }
    public Item Item17 { get; set; }
    public Item Item18 { get; set; }
    public Item Item19 { get; set; }
    public Item Item20 { get; set; }
    public Item Item21 { get; set; }
    public Item Item22 { get; set; }
    public Item Item23 { get; set; }
    public Item Item24 { get; set; }
    public Bitmap Item1Image {
      get {
        return Item1.Image;
      }
    }
    public Bitmap Item2Image {
      get {
        return Item2.Image;
      }
    }
    public Bitmap Item3Image {
      get {
        return Item3.Image;
      }
    }
    public Bitmap Item4Image {
      get {
        return Item4.Image;
      }
    }
    public Bitmap Item5Image {
      get {
        return Item5.Image;
      }
    }
    public Bitmap Item6Image {
      get {
        return Item6.Image;
      }
    }
    public Bitmap Item7Image {
      get {
        return Item7.Image;
      }
    }
    public Bitmap Item8Image {
      get {
        return Item8.Image;
      }
    }
    public Bitmap Item9Image {
      get {
        return Item9.Image;
      }
    }
    public Bitmap Item10Image {
      get {
        return Item10.Image;
      }
    }
    public Bitmap Item11Image {
      get {
        return Item11.Image;
      }
    }
    public Bitmap Item12Image {
      get {
        return Item12.Image;
      }
    }
    public Bitmap Item13Image {
      get {
        return Item13.Image;
      }
    }
    public Bitmap Item14Image {
      get {
        return Item14.Image;
      }
    }
    public Bitmap Item15Image {
      get {
        return Item15.Image;
      }
    }
    public Bitmap Item16Image {
      get {
        return Item16.Image;
      }
    }
    public Bitmap Item17Image {
      get {
        return Item17.Image;
      }
    }
    public Bitmap Item18Image {
      get {
        return Item18.Image;
      }
    }
    public Bitmap Item19Image {
      get {
        return Item19.Image;
      }
    }
    public Bitmap Item20Image {
      get {
        return Item20.Image;
      }
    }
    public Bitmap Item21Image {
      get {
        return Item21.Image;
      }
    }
    public Bitmap Item22Image {
      get {
        return Item22.Image;
      }
    }
    public Bitmap Item23Image {
      get {
        return Item23.Image;
      }
    }
    public Bitmap Item24Image {
      get {
        return Item24.Image;
      }
    }

    public ItemSet() {
      ItemSetName = "";
      BuildManager manager = CommonInjector.provideBuildManager();
      Item emptyItem = manager.EmptyItem;
      Item1 = emptyItem;
      Item2 = emptyItem;
      Item3 = emptyItem;
      Item4 = emptyItem;
      Item5 = emptyItem;
      Item6 = emptyItem;
      Item7 = emptyItem;
      Item8 = emptyItem;
      Item9 = emptyItem;
      Item10 = emptyItem;
      Item11 = emptyItem;
      Item12 = emptyItem;
      Item13 = emptyItem;
      Item14 = emptyItem;
      Item15 = emptyItem;
      Item16 = emptyItem;
      Item17 = emptyItem;
      Item18 = emptyItem;
      Item19 = emptyItem;
      Item20 = emptyItem;
      Item21 = emptyItem;
      Item22 = emptyItem;
      Item23 = emptyItem;
      Item24 = emptyItem;
    }

    public ItemSet(ItemSet itemSet) {
      ItemSetName = "";
      Item1 = itemSet.Item1;
      Item2 = itemSet.Item2;
      Item3 = itemSet.Item3;
      Item4 = itemSet.Item4;
      Item5 = itemSet.Item5;
      Item6 = itemSet.Item6;
      Item7 = itemSet.Item7;
      Item8 = itemSet.Item8;
      Item9 = itemSet.Item9;
      Item10 = itemSet.Item10;
      Item11 = itemSet.Item11;
      Item12 = itemSet.Item12;
      Item13 = itemSet.Item13;
      Item14 = itemSet.Item14;
      Item15 = itemSet.Item15;
      Item16 = itemSet.Item16;
      Item17 = itemSet.Item17;
      Item18 = itemSet.Item18;
      Item19 = itemSet.Item19;
      Item20 = itemSet.Item20;
      Item21 = itemSet.Item21;
      Item22 = itemSet.Item22;
      Item23 = itemSet.Item23;
      Item24 = itemSet.Item24;
    }
  }
}
