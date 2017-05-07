using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

using Newtonsoft.Json;

namespace com.jcandksolutions.lol.Model {
  public class SummonerSpell {
    [JsonProperty("tooltip")]
    public string mTooltip;
    [JsonProperty("name")]
    public string Name { get; set; }
    [JsonProperty("id")]
    public string ID { get; set; }
    [JsonProperty("description")]
    public string Description { get; set; }
    [JsonProperty("cooldown")]
    public string Cooldown { get; set; }
    [JsonProperty("effect")]
    public List<string> Effect { get; set; }
    [JsonProperty("range")]
    public string Range { get; set; }
    [JsonProperty("vars")]
    public List<Var> Vars { get; set; }
    [JsonProperty("image")]
    public string ImageURL { get; set; }
    public Bitmap Image {
      get {
        return string.IsNullOrWhiteSpace(ImageURL) ? null : new Bitmap("img/spell/" + ImageURL);
      }
    }
    public string Tooltip {
      get {
        return Name + "\n\rRange: " + Range + "\n\rCooldown: " + Cooldown + "\n\rDescription: " + Description + "\n\r" + formatString(mTooltip);
      }
      set {
        mTooltip = value;
      }
    }

    public override string ToString() {
      return Name;
    }

    private string formatString(string result) {
      for (var i = 1; i < 10; ++i) {
        if (result.IndexOf("{{ e" + i + " }}", StringComparison.Ordinal) != -1) {
          result = result.Replace("{{ e" + i + " }}", Effect != null ? Effect.Count > i ? Effect[i] : null : null);
        }
        if (result.IndexOf("{{ a" + i + " }}", StringComparison.Ordinal) != -1) {
          result = result.Replace("{{ a" + i + " }}", Vars.Where(x => x.Key == "a" + i).Select(x => x.Text).FirstOrDefault());
        }
        if (result.IndexOf("{{ f" + i + " }}", StringComparison.Ordinal) != -1) {
          result = result.Replace("{{ f" + i + " }}", Vars.Where(x => x.Key == "f" + i).Select(x => x.Text).FirstOrDefault());
        }
      }

      return result;
    }
  }
}
