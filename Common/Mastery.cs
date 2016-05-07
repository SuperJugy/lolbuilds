using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace com.jcandksolutions.lol {
  public class Mastery {
    private readonly HashSet<string> mPartners = new HashSet<string>();
    public string ID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageURL { get; set; }
    public Bitmap Image {
      get {
        return string.IsNullOrWhiteSpace(ImageURL) ? null : new Bitmap("img/mastery/" + ImageURL);
      }
    }
    public List<string> Partners {
      get {
        return mPartners.ToList();
      }
    }

    public void addPartner(string p) {
      mPartners.Add(p);
    }
  }
}
