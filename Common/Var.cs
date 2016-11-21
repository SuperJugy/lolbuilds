using System.Collections.Generic;
using System.Linq;

namespace com.jcandksolutions.lol {
  public class Var {
    private string mValue;
    private string Value {
      get {
        if (mValue == null) {
          mValue = string.Join("/", Coeffs);
        }
        return mValue;
      }
    }
    public string Key { get; set; }
    public string Type { private get; set; }
    public List<double> Coeffs { private get; set; }
    public string RanksWith { private get; set; }
    public string Text {
      get {
        switch (Type) {
          case "spelldamage":
            return Value + " AP";
          case "@dynamic.attackdamage":
            return "+" + Value + " AD";
          case "@dynamic.abilitypower":
            return "+" + Value + " AP";
          case "attackdamage":
            return Value + " AD";
          case "@stacks":
            return Value + " per Stack";
          case "bonushealth":
            return Value + " Bonus HP";
          case "bonusattackdamage":
            return Value + " Bonus AD";
          case "health":
            return Value + " HP";
          case "armor":
            return Value + " Armor";
          case "@cooldownchampion":
            return Value + " CDR";
          case "@text":
            return string.IsNullOrEmpty(RanksWith) ? Value : Value + " (Ranks With " + RanksWith + ")";
          default:
            return Value;
        }
      }
    }
  }
}
