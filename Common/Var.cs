namespace com.jcandksolutions.lol {
  public class Var {
    public string Key { get; set; }
    public string Type { get; set; }
    public string Value { get; set; }
    public string Text {
      get {
        if (Type == "spelldamage") {
          return Value + " AP";
        } else if (Type == "@dynamic.attackdamage") {
          return Value + " AD";
        } else if (Type == "@dynamic.abilitypower") {
          return Value + " AP";
        } else if (Type == "attackdamage") {
          return Value + " AD";
        } else if (Type == "@stacks") {
          return Value + " per Stack";
        } else if (Type == "bonushealth") {
          return Value + " Bonus HP";
        } else if (Type == "bonusattackdamage") {
          return Value + " Bonus AD";
        } else if (Type == "health") {
          return Value + " HP";
        } else if (Type == "armor") {
          return Value + " Armor";
        } else if (Type == "@cooldownchampion") {
          return Value + " CDR";
        } else {
          return Value;
        }
      }
    }
  }
}