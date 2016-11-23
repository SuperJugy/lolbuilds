using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Newtonsoft.Json;

namespace com.jcandksolutions.lol {
  [JsonObject(MemberSerialization.OptIn)]
  public class Mastery {
    private readonly HashSet<string> mPartners = new HashSet<string>();
    [JsonProperty("id")]
    public string ID { get; set; }
    [JsonProperty("name")]
    public string Name { get; set; }
    [JsonProperty("description")]
    public string Description { get; set; }
    [JsonProperty("image")]
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
