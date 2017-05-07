using System.Collections.Generic;
using Newtonsoft.Json;

namespace com.jcandksolutions.lol.Model {
  public class BuildData {
    [JsonProperty("builds")]
    public List<Build> Builds { get; set; }
    [JsonProperty("runes")]
    public List<RunePage> Runes { get; set; }
    [JsonProperty("masteries")]
    public MasteryPageList Masteries { get; set; }
    [JsonProperty("itemsets")]
    public List<ItemSet> ItemSets { get; set; }
  }
}
