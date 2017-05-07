using System.Collections.Generic;
using Newtonsoft.Json;

namespace com.jcandksolutions.lol.Model {
  public class Branch {
    [JsonProperty("name")]
    public string Name { get; set; }
    [JsonProperty("tiers")]
    public List<Tier> Tiers { get; set; }
  }
}
