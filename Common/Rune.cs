using System.Drawing;
using System.Collections.Generic;

namespace com.jcandksolutions.lol {
  public class Rune {
    public string ID { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public string ImageURL { private get; set; }
    public string Description { private get; set; }
    public List<Stat> Stats { private get; set; }
    public string Tooltip {
      get {
        return Name + "\n\r" + Description;
      }
    }
    public Bitmap Image {
      get {
        return string.IsNullOrWhiteSpace(ImageURL) ? null : new Bitmap("img/rune/" + ImageURL);
      }
    }

    public override string ToString() {
      return Name;
    }
  }
}
