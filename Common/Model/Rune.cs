using System.Collections.Generic;
using System.Drawing;
using Newtonsoft.Json;

namespace com.jcandksolutions.lol.Model {
  [JsonObject(MemberSerialization.OptIn)]
  public class Rune {
    [JsonProperty("id")]
    public string ID { get; set; }
    [JsonProperty("name")]
    public string Name { get; set; }
    [JsonProperty("type")]
    public string Type { get; set; }
    [JsonProperty("image")]
    public string ImageURL { get; set; }
    [JsonProperty("description")]
    public string Description { get; set; }
    [JsonProperty("stats")]
    public List<Stat> Stats { get; set; }
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
