using Newtonsoft.Json;
namespace com.jcandksolutions.lol {
  public class Stats {
    [JsonProperty("armor")]
    public double Armor { get; set; }
    [JsonProperty("armorperlevel")]
    public double ArmorPerLevel { get; set; }
    [JsonProperty("attackdamage")]
    public double AD { get; set; }
    [JsonProperty("attackdamageperlevel")]
    public double ADPerLevel { get; set; }
    [JsonProperty("attackspeedoffset")]
    public double AS { get; set; }
    [JsonProperty("attackspeedperlevel")]
    public double ASPerLevel { get; set; }
    [JsonProperty("crit")]
    public double Crit { get; set; }
    [JsonProperty("critperlevel")]
    public double CritPerLevel { get; set; }
    [JsonProperty("hp")]
    public double HP { get; set; }
    [JsonProperty("hpperlevel")]
    public double HPPerLevel { get; set; }
    [JsonProperty("hpregen")]
    public double HPRegen { get; set; }
    [JsonProperty("hpregenperlevel")]
    public double HPRegenPerLevel { get; set; }
    [JsonProperty("mp")]
    public double MP { get; set; }
    [JsonProperty("mpperlevel")]
    public double MPPerLevel { get; set; }
    [JsonProperty("mpregen")]
    public double MPRegen { get; set; }
    [JsonProperty("mpregenperlevel")]
    public double MPRegenPerLevel { get; set; }
    [JsonProperty("spellblock")]
    public double MR { get; set; }
    [JsonProperty("spellblockperlevel")]
    public double MRPerLevel { get; set; }
    [JsonProperty("movespeed")]
    public double MoveSpeed { get; set; }
    [JsonProperty("attackrange")]
    public double Range { get; set; }
  }
}
