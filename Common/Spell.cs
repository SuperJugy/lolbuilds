using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace com.jcandksolutions.lol {
  public class Spell {
    private string mTooltip;
    private string mResource;
    public string Name { get; set; }
    public string Description { get; set; }
    public string Cooldown { get; set; }
    public string Range { get; set; }
    public string Cost { get; set; }
    public string ImageURL { get; set; }
    public int MaxRank { get; set; }
    public List<string> Effect { get; set; }
    public List<Var> Vars { get; set; }
    public string Tooltip {
      get {
        return Name + "\n\rRange: " + Range + "\n\rCost: " + Resource + "\n\rCooldown: " + Cooldown + "\n\rDescription: " + Description + "\n\r" + formatString(mTooltip);
      }
      set {
        mTooltip = value;
      }
    }
    public string Resource {
      get {
        return formatString(mResource);
      }
      set {
        mResource = value;
      }
    }
    public Bitmap Image {
      get {
        return string.IsNullOrWhiteSpace(ImageURL) ? null : new Bitmap("img/spell/" + ImageURL);
      }
    }

    private string formatString(string result) {
      for (int i = 1; i < 7; ++i) {
        if (result.IndexOf("{{ e" + i + " }}") != -1) {
          result = result.Replace("{{ e" + i + " }}", Effect != null ? Effect.Count > i ? Effect[i] : null : null);
        }
        if (result.IndexOf("{{ a" + i + " }}") != -1) {
          result = result.Replace("{{ a" + i + " }}", Vars.Where(x => x.Key == "a" + i).Select(x => x.Text).FirstOrDefault());
        }
        if (result.IndexOf("{{ f" + i + " }}") != -1) {
          result = result.Replace("{{ f" + i + " }}", Vars.Where(x => x.Key == "f" + i).Select(x => x.Text).FirstOrDefault());
        }
      }
      if (result.IndexOf("{{ cost }}") != -1) {
        result = result.Replace("{{ cost }}", Cost);
      }
      return result;
    }
  }
}
