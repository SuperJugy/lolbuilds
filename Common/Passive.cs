using System.Drawing;

namespace com.jcandksolutions.lol {
  public class Passive {
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageURL { get; set; }
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
