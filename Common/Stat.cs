using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace com.jcandksolutions.lol {
  public class Stat {
    [JsonProperty("name")]
    public string Name { get; set; }
    [JsonProperty("value")]
    public double Value { get; set; }
  }
}
