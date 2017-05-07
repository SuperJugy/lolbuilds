using System.Collections.Generic;
using System.Drawing;

using Newtonsoft.Json;

namespace com.jcandksolutions.lol.Model {
  [JsonObject(MemberSerialization.OptIn)]
  public class Item {
    [JsonProperty("id")]
    public string ID { get; set; }
    [JsonProperty("name")]
    public string Name { get; set; }
    [JsonProperty("description")]
    public string Description { get; set; }
    [JsonProperty("gold")]
    public int Gold { get; set; }
    [JsonProperty("stats")]
    public List<Stat> Stats { get; set; }
    [JsonProperty("image")]
    public string ImageURL { get; set; }
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
