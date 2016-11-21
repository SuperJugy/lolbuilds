using System.Drawing;
using System.Collections.Generic;

namespace com.jcandksolutions.lol {
  public class Item {
    public string ID { get; set; }
    public string Name { get; set; }
    public string Description { private get; set; }
    public int Gold { private get; set; }
    public List<Stat> Stats { private get; set; }
    public string ImageURL { private get; set; }
    public Bitmap Image {
      get {
        return string.IsNullOrWhiteSpace(ImageURL) ? null : new Bitmap("img/item/" + ImageURL);
      }
    }
    public string Tooltip {
      get {
        return Name + "\n\rCost: " + Gold + "\n\r" + Description;
      }
    }

    public override string ToString() {
      return Name;
    }
  }
}
