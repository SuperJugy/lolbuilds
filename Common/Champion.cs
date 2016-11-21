using System.Drawing;
using System.Collections.Generic;

namespace com.jcandksolutions.lol {
  public class Champion {
    public string ID { get; set; }
    public string Name { get; set; }
    public string Resource { get; set; }
    public Stats Stats { get; set; }
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
    public List<Spell> Spells { private get; set; }
    public Spell Spell1 {
      get {
        return Spells[0];
      }
    }
    public Bitmap Spell1Image {
      get {
        return Spell1.Image;
      }
    }
    public Spell Spell2 {
      get {
        return Spells[1];
      }
    }
    public Bitmap Spell2Image {
      get {
        return Spell2.Image;
      }
    }
    public Spell Spell3 {
      get {
        return Spells[2];
      }
    }
    public Bitmap Spell3Image {
      get {
        return Spell3.Image;
      }
    }
    public Spell Spell4 {
      get {
        return Spells[3];
      }
    }
    public Bitmap Spell4Image {
      get {
        return Spell4.Image;
      }
    }
  }
}
