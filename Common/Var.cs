namespace com.jcandksolutions.lol {
  public class Var {
    public string Key { get; set; }
    public string Type { get; set; }
    public string Value { get; set; }
    public string Text {
      get {
        if (Type == "spelldamage") {
          return Value + " AP";
        }
        if (Type == "@dynamic.attackdamage") {
          return Value + " AD";
        }
        if (Type == "@dynamic.abilitypower") {
          return Value + " AP";
        }
        if (Type == "attackdamage") {
          return Value + " AD";
        }
        if (Type == "@stacks") {
          return Value + " per Stack";
        }
        if (Type == "bonushealth") {
          return Value + " Bonus HP";
        }
        if (Type == "bonusattackdamage") {
          return Value + " Bonus AD";
        }
        if (Type == "health") {
          return Value + " HP";
        }
        if (Type == "armor") {
          return Value + " Armor";
        }
        if (Type == "@cooldownchampion") {
          return Value + " CDR";
        }
        return Value;
      }
    }
  }
}
