using System.Drawing;

namespace com.jcandksolutions.lol {
  public class Passive {
    public string Name { private get; set; }
    public string Description { private get; set; }
    public string ImageURL { private get; set; }
    public Bitmap Image {
      get {
        return string.IsNullOrWhiteSpace(ImageURL) ? null : new Bitmap("img/passive/" + ImageURL);
      }
    }
    public string Tooltip {
      get {
        return Name + "\n\r" + Description;
      }
    }
  }
}
