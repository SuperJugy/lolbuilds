using System.Drawing;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace com.jcandksolutions.lol {
  [JsonObject(MemberSerialization.OptIn)]
  public class Champion {
    [JsonProperty("id")]
    public string ID { get; set; }
    [JsonProperty("name")]
    public string Name { get; set; }
    [JsonProperty("secondBarType")]
    public string Resource { get; set; }
    [JsonProperty("stats")]
    public Stats Stats { get; set; }
    [JsonProperty("image")]
    public string ImageURL { get; set; }
    public Bitmap Image {
      get {
        return string.IsNullOrWhiteSpace(ImageURL) ? null : new Bitmap("img/champion/" + ImageURL);
      }
    }
    [JsonProperty("passive")]
    public Passive Passive { get; set; }
    public Bitmap PassiveImage {
      get {
        return Passive.Image;
      }
    }
    [JsonProperty("spells")]
    public List<Spell> Spells { get; set; }
    public Spell Spell1 {
      get {
        return Spells[0];
      }
    }
    public Bitmap Spell1Image {
      get {
        return Spell1.Image;
      }
    }
    public Spell Spell2 {
      get {
        return Spells[1];
      }
    }
    public Bitmap Spell2Image {
      get {
        return Spell2.Image;
      }
    }
    public Spell Spell3 {
      get {
        return Spells[2];
      }
    }
    public Bitmap Spell3Image {
      get {
        return Spell3.Image;
      }
    }
    public Spell Spell4 {
      get {
        return Spells[3];
      }
    }
    public Bitmap Spell4Image {
      get {
        return Spell4.Image;
      }
    }
  }
}
