using System.Drawing;

namespace com.jcandksolutions.lol {
  public class Rune {
    public string ID { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public string ImageURL { get; set; }
    public string Description { get; set; }
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
