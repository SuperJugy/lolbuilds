using System.Collections.Generic;
using Newtonsoft.Json;

namespace com.jcandksolutions.lol {
  public class DBData {
    [JsonProperty("items")]
    public List<Item> Items { get; set; }
    [JsonProperty("champions")]
    public List<Champion> Champions { get; set; }
    [JsonProperty("runes")]
    public List<Rune> Runes { get; set; }
    [JsonProperty("masteries")]
    public List<Branch> Masteries { get; set; }
  }
}
