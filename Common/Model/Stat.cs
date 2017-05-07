using Newtonsoft.Json;

namespace com.jcandksolutions.lol.Model {
  public class Stat {
    [JsonProperty("name")]
    public string Name { get; set; }
    [JsonProperty("value")]
    public double Value { get; set; }
  }
}
