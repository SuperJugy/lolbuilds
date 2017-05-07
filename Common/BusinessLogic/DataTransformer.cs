using System.Collections.Generic;
using System.Linq;
using com.jcandksolutions.lol.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace com.jcandksolutions.lol.BusinessLogic {
  public class DataTransformer {
    public APICaller Caller { private get; set; }

    public string extractDB() {
      var root = new DBData {
        Items = extractItems(Caller.queryItems()),
        Champions = extractChampions(Caller.queryChampions()),
        Runes = extractRunes(Caller.queryRunes()),
        Masteries = extractMasteries(Caller.queryMasteries())
      };
      return JsonConvert.SerializeObject(root, Formatting.Indented);
    }

    private List<Item> extractItems(JObject data) {
      var itemData = (JObject)data["data"];
      List<string> enchantments = extractEnchantmentsIDs(itemData);
      List<dynamic> enchantables = extractEnchantablesList(itemData, enchantments);
      Dictionary<string, string> enchantmentMap = buildEnchantmentMap(enchantments, enchantables);
      List<Item> items = itemData.Properties().Select(prop => extractItem(enchantmentMap, (JObject)prop.Value)).ToList();
      return items;
    }

    private List<Champion> extractChampions(JObject data) {
      var championData = (JObject)data["data"];
      List<Champion> champions = championData.Properties().Select(prop => extractChampion((JObject)prop.Value)).ToList();
      return champions;
    }

    private List<Rune> extractRunes(JObject data) {
      var runeData = (JObject)data["data"];
      List<Rune> runes = runeData.Properties().Where(prop => prop.Value["rune"]["tier"].ToString().Equals("3")).Select(prop => extractRune((JObject)prop.Value)).ToList();
      return runes;
    }

    private List<Branch> extractMasteries(JObject data) {
      var tree = (JObject)data["tree"];
      var masteryData = (JObject)data["data"];
      return tree.Properties().Select(branch => extractBranch(branch, masteryData)).ToList();
    }

    private Item extractItem(Dictionary<string, string> enchantmentMap, JObject prop) {
      string key = prop["id"].ToString();
      string image = prop["image"]["full"].ToString();
      Caller.downloadItemImage(image);
      return new Item {
        ID = key,
        Description = extractString(prop["sanitizedDescription"]),
        Gold= int.Parse(extractString(prop["gold"]["total"])),
        Name= enchantmentMap.ContainsKey(key) && enchantmentMap[key] != "" ? enchantmentMap[key] + " - " + extractString(prop["name"]) : extractString(prop["name"]),
        Stats= extractStatList((JObject)prop["stats"]),
        ImageURL = image
      };
    }

    private Champion extractChampion(JObject prop) {
      string image = prop["image"]["full"].ToString();
      Caller.downloadChampionImage(image);
      return new Champion {
        ID = prop["id"].ToString(),
        Name = prop["name"].ToString(),
        Resource = extractString(prop["partype"]),
        Stats = extractStats(prop["stats"]),
        ImageURL = image,
        Passive = extractPassive((JObject)prop["passive"]),
        Spells = extractSpells((JArray)prop["spells"])
      };
    }

    private ChampionStats extractStats(JToken prop) {
      return new ChampionStats {
        AD = double.Parse(extractString(prop["attackdamage"])),
        ADPerLevel = double.Parse(extractString(prop["attackdamageperlevel"])),
        Armor = double.Parse(extractString(prop["armor"])),
        ArmorPerLevel = double.Parse(extractString(prop["armorperlevel"])),
        AS = double.Parse(extractString(prop["attackspeedoffset"])),
        ASPerLevel = double.Parse(extractString(prop["attackspeedperlevel"])),
        Crit = double.Parse(extractString(prop["crit"])),
        CritPerLevel = double.Parse(extractString(prop["critperlevel"])),
        HP = double.Parse(extractString(prop["hp"])),
        HPPerLevel = double.Parse(extractString(prop["hpperlevel"])),
        HPRegen = double.Parse(extractString(prop["hpregen"])),
        HPRegenPerLevel = double.Parse(extractString(prop["hpregenperlevel"])),
        MoveSpeed = double.Parse(extractString(prop["movespeed"])),
        MP = double.Parse(extractString(prop["mp"])),
        MPPerLevel = double.Parse(extractString(prop["mpperlevel"])),
        MPRegen = double.Parse(extractString(prop["mpregen"])),
        MPRegenPerLevel = double.Parse(extractString(prop["mpregenperlevel"])),
        MR = double.Parse(extractString(prop["spellblock"])),
        MRPerLevel = double.Parse(extractString(prop["spellblockperlevel"])),
        Range = double.Parse(extractString(prop["attackrange"])),
      };
    }

    private List<Spell> extractSpells(JArray array) {
      return array.Select(obj => extractSpell((JObject)obj)).ToList();
    }

    private Spell extractSpell(JObject prop) {
      string image = prop["image"]["full"].ToString();
      Caller.downloadSpellImage(image);
      return new Spell {
        Name = prop["name"].ToString(),
        Description = extractString(prop["sanitizedDescription"]),
        Tooltip = extractString(prop["sanitizedTooltip"]),
        Resource = extractString(prop["resource"]),
        MaxRank = int.Parse(extractString(prop["maxrank"])),
        CostType = extractString(prop["costType"]),
        Cooldown = extractString(prop["cooldownBurn"]),
        Effect = extractEffects((JArray)prop["effectBurn"]),
        Range = extractString(prop["rangeBurn"]),
        Cost = extractString(prop["costBurn"]),
        Vars = extractVars((JArray)prop["vars"]),
        ImageURL = image
      };
    }

    private List<string> extractEffects(JArray array) {
      if (array == null) {
        return new List<string>();
      } else {
        return array.Select(obj => extractString(obj)).ToList();
      }
    }

    private List<Var> extractVars(JArray array) {
      if (array == null) {
        return new List<Var>();
      } else {
        return array.Select(obj => extractVar((JObject)obj)).ToList();
      }
    }

    private Var extractVar(JObject prop) {
      return new Var {
        Coeffs = ((JArray)prop["coeff"]).Select(obj => double.Parse(extractString(obj))).ToList(),
        Key = extractString(prop["key"]),
        Type = extractString(prop["link"]),
        RanksWith = extractString(prop["ranksWith"])
      };
    }

    private Passive extractPassive(JObject prop) {
      string image = prop["image"]["full"].ToString();
      Caller.downloadPassiveImage(image);
      return new Passive {
        Name = prop["name"].ToString(),
        Description = extractString(prop["sanitizedDescription"]),
        ImageURL = image
      };
    }

    private Rune extractRune(JObject prop) {
      string image = prop["image"]["full"].ToString();
      Caller.downloadRuneImage(image);
      return new Rune {
        ID = prop["id"].ToString(),
        Name = prop["name"].ToString(),
        Description = extractString(prop["sanitizedDescription"]),
        Type = extractString(prop["rune"]["type"]),
        Stats = extractStatList((JObject)prop["stats"]),
        ImageURL = image
      };
    }

    private Branch extractBranch(JProperty branch, JObject masteryData) {
      var hasLimit5 = false;
      return new Branch {
        Name = branch.Name,
        Tiers = branch.Value.Select(tier => extractTier(tier, ref hasLimit5, masteryData)).ToList()
      };
    }

    private Tier extractTier(JToken tier, ref bool hasLimit5, JObject masteryData) {
      hasLimit5 = !hasLimit5;
      return new Tier {
        Limit = hasLimit5 ? 5 : 1,
        Masteries = tier["masteryTreeItems"].Where(mastery => mastery.Type != JTokenType.Null).Select(mastery => extractMastery(mastery, masteryData)).ToList()
      };
    }

    private Mastery extractMastery(JToken mastery, JObject masteryData) {
      string id = mastery["masteryId"].ToString();
      JToken find = masteryData.Properties().Where(x => x.Value["id"].ToString().Equals(id)).Select(x => x.Value).First();
      string image = find["image"]["full"].ToString();
      Caller.downloadMasteryImage(image);
      return new Mastery {
        ID = id,
        Name = find["name"].ToString(),
        Description = extractString(find["sanitizedDescription"]),
        ImageURL = image
      };
    }

    private Dictionary<string, string> buildEnchantmentMap(List<string> enchantments, List<dynamic> enchantables) {
      return enchantments.ToDictionary(enchantment => enchantment, enchantment => findEnchantableForEnchantment(enchantment, enchantments, enchantables));
    }

    private List<dynamic> extractEnchantablesList(JObject itemData, List<string> enchantments) {
      return itemData.Properties().Where(itDa => itDa.Value["into"] != null && itDa.Value["into"].All(it => enchantments.Contains(it.ToString()))).Select(itDa => new {
        Id = itDa.Value["id"].ToString(),
        Name = itDa.Value["name"].ToString(),
        Into = itDa.Value["into"].Select(it => it.ToString()).ToList()
      }).ToList<dynamic>();
    }

    private List<string> extractEnchantmentsIDs(JObject itemData) {
      return
        itemData.Properties()
          .Where(itDa => itDa.Value["name"] != null && itDa.Value["name"].ToString().StartsWith("Enchantment"))
          .Select(itDa => itDa.Value["id"].ToString())
          .ToList();
    }

    private string findEnchantableForEnchantment(string enchantment, List<string> enchantments, List<dynamic> enchantables) {
      return
        enchantables.Where(enchantable => enchantable.Into.Contains(enchantment))
          .Select(enchantable => enchantments.Contains(enchantable.Id) ? findEnchantableForEnchantment(enchantable.Id, enchantments, enchantables) : enchantable.Name)
          .DefaultIfEmpty<dynamic>("")
          .First();
    }

    private object extractToken(JToken token) {
      if (token == null || token.Type == JTokenType.Null) {
        return "";
      }
      if (token.Type == JTokenType.Object) {
        return extractObject((JObject)token);
      }
      if (token.Type == JTokenType.Array) {
        return extractArray((JArray)token);
      }
      return token.ToString();
    }

    private string extractString(JToken token) {
      if (token == null || token.Type == JTokenType.Null) {
        return "";
      }
      return token.ToString();
    }

    private List<Stat> extractStatList(JObject obj) {
      return obj.Properties().Select(prop => new Stat {
        Name = prop.Name,
        Value = double.Parse(prop.Value.ToString())
      }).ToList();
    }

    private Dictionary<string, object> extractObject(JObject obj) {
      return obj.Properties().ToDictionary(prop => prop.Name, prop => extractToken(prop.Value));
    }

    private List<object> extractArray(JArray array) {
      return array.Select(extractToken).ToList();
    }
  }
}
