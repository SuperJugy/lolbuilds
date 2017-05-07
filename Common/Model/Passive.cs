using System.Drawing;

using Newtonsoft.Json;

namespace com.jcandksolutions.lol.Model {
  [JsonObject(MemberSerialization.OptIn)]
  public class Passive {
    [JsonProperty("name")]
    public string Name { get; set; }
    [JsonProperty("description")]
    public string Description { get; set; }
    [JsonProperty("image")]
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
