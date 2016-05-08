using System.Drawing;

namespace com.jcandksolutions.lol {
  public class Champion {
    public string ID { get; set; }
    public string Name { get; set; }
    public string ImageURL { private get; set; }
    public Bitmap Image {
      get {
        return string.IsNullOrWhiteSpace(ImageURL) ? null : new Bitmap("img/champion/" + ImageURL);
      }
    }
    public Passive Passive { get; set; }
    public Bitmap PassiveImage {
      get {
        return Passive.Image;
      }
    }
    public Spell Spell1 { get; set; }
    public Bitmap Spell1Image {
      get {
        return Spell1.Image;
      }
    }
    public Spell Spell2 { get; set; }
    public Bitmap Spell2Image {
      get {
        return Spell2.Image;
      }
    }
    public Spell Spell3 { get; set; }
    public Bitmap Spell3Image {
      get {
        return Spell3.Image;
      }
    }
    public Spell Spell4 { get; set; }
    public Bitmap Spell4Image {
      get {
        return Spell4.Image;
      }
    }
  }
}
