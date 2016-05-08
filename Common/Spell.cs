using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace com.jcandksolutions.lol {
  public class Spell {
    private string mResource;
    private string mTooltip;
    public string Name { private get; set; }
    public string Description { private get; set; }
    public string Cooldown { private get; set; }
    public string Range { private get; set; }
    public string Cost { private get; set; }
    public string ImageURL { private get; set; }
    public int MaxRank { get; set; }
    public List<string> Effect { private get; set; }
    public List<Var> Vars { private get; set; }
    public string Tooltip {
      get {
        return Name + "\n\rRange: " + Range + "\n\rCost: " + Resource + "\n\rCooldown: " + Cooldown + "\n\rDescription: " + Description + "\n\r" + formatString(mTooltip);
      }
      set {
        mTooltip = value;
      }
    }
    public string Resource {
      private get {
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
      for (int i = 1; i < 10; ++i) {
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
      if (result.IndexOf("{{ cost }}", StringComparison.Ordinal) != -1) {
        result = result.Replace("{{ cost }}", Cost);
      }
      return result;
    }
  }
}
