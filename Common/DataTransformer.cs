using System.Collections.Generic;
using System.Linq;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace com.jcandksolutions.lol {
  public class DataTransformer {
    public APICaller Caller { private get; set; }

    public string extractDB() {
      var root = new {
        items = extractItems(Caller.queryItems()),
        champions = extractChampions(Caller.queryChampions()),
        runes = extractRunes(Caller.queryRunes()),
        masteries = extractMasteries(Caller.queryMasteries())
      };
      return JsonConvert.SerializeObject(root, Formatting.Indented);
    }

    private List<object> extractItems(JObject data) {
      JObject itemData = (JObject)data["data"];
      List<string> enchantments = extractEnchantmentsIDs(itemData);
      List<dynamic> enchantables = extractEnchantablesList(itemData, enchantments);
      Dictionary<string, string> enchantmentMap = buildEnchantmentMap(enchantments, enchantables);
      List<object> items = itemData.Properties().Select(prop => extractItem(enchantmentMap, (JObject)prop.Value)).ToList<object>();
      return items;
    }

    private List<object> extractChampions(JObject data) {
      JObject championData = (JObject)data["data"];
      List<object> champions = championData.Properties().Select(prop => extractChampion((JObject)prop.Value)).ToList<object>();
      return champions;
    }

    private List<object> extractRunes(JObject data) {
      JObject runeData = (JObject)data["data"];
      List<object> runes = runeData.Properties().Where(prop => prop.Value["rune"]["tier"].ToString().Equals("3")).Select(prop => extractRune((JObject)prop.Value)).ToList<object>();
      return runes;
    }

    private List<object> extractMasteries(JObject data) {
      JObject tree = (JObject)data["tree"];
      JObject masteryData = (JObject)data["data"];
      return tree.Properties().Select(branch => extractBranch(branch, masteryData)).ToList<object>();
    }

    private Dictionary<string, object> extractItem(Dictionary<string, string> enchantmentMap, JObject prop) {
      string key = (string)extractToken(prop["id"]);
      string image = (string)extractToken(prop["image"]["full"]);
      Caller.downloadItemImage(image);
      return new Dictionary<string, object> {
        {
          "id", key
        }, {
          "description", extractToken(prop["sanitizedDescription"])
        }, {
          "gold", extractToken(prop["gold"]["total"])
        }, {
          "name", enchantmentMap.ContainsKey(key) && enchantmentMap[key] != "" ? enchantmentMap[key] + " - " + extractToken(prop["name"]) : extractToken(prop["name"])
        }, {
          "stats", extractToken(prop["stats"])
        }, {
          "image", image
        }
      };
    }

    private Dictionary<string, object> extractChampion(JObject prop) {
      string image = extractToken(prop["image"]["full"]).ToString();
      Caller.downloadChampionImage(image);
      return new Dictionary<string, object> {
        {
          "id", extractToken(prop["id"])
        }, {
          "name", extractToken(prop["name"])
        }, {
          "secondBarType", extractToken(prop["partype"])
        }, {
          "stats", extractToken(prop["stats"])
        }, {
          "image", image
        }, {
          "passive", extractPassive((JObject)prop["passive"])
        }, {
          "spells", extractSpells((JArray)prop["spells"])
        }
      };
    }

    private List<object> extractSpells(JArray array) {
      return array.Select(obj => extractSpell((JObject)obj)).ToList<object>();
    }

    private Dictionary<string, object> extractSpell(JObject prop) {
      string image = (string)extractToken(prop["image"]["full"]);
      Caller.downloadSpellImage(image);
      return new Dictionary<string, object> {
        {
          "name", extractToken(prop["name"])
        }, {
          "description", extractToken(prop["sanitizedDescription"])
        }, {
          "tooltip", extractToken(prop["sanitizedTooltip"])
        }, {
          "resource", extractToken(prop["resource"])
        }, {
          "maxrank", extractToken(prop["maxrank"])
        }, {
          "costType", extractToken(prop["costType"])
        }, {
          "cooldown", extractToken(prop["cooldownBurn"])
        }, {
          "effect", extractToken(prop["effectBurn"])
        }, {
          "range", extractToken(prop["rangeBurn"])
        }, {
          "cost", extractToken(prop["costBurn"])
        }, {
          "vars", extractToken(prop["vars"])
        }, {
          "image", image
        }
      };
    }

    private Dictionary<string, object> extractPassive(JObject prop) {
      string image = (string)extractToken(prop["image"]["full"]);
      Caller.downloadPassiveImage(image);
      return new Dictionary<string, object> {
        {
          "name", extractToken(prop["name"])
        }, {
          "description", extractToken(prop["sanitizedDescription"])
        }, {
          "image", image
        }
      };
    }

    private Dictionary<string, object> extractRune(JObject prop) {
      string image = (string)extractToken(prop["image"]["full"]);
      Caller.downloadRuneImage(image);
      return new Dictionary<string, object> {
        {
          "id", extractToken(prop["id"])
        }, {
          "name", extractToken(prop["name"])
        }, {
          "description", extractToken(prop["sanitizedDescription"])
        }, {
          "type", extractToken(prop["rune"]["type"])
        }, {
          "stats", extractToken(prop["stats"])
        }, {
          "image", image
        }
      };
    }

    private Dictionary<string, object> extractBranch(JProperty branch, JObject masteryData) {
      bool hasLimit5 = false;
      return new Dictionary<string, object> {
        {
          "name", branch.Name
        }, {
          "tiers", branch.Value.Select(tier => extractTier(tier, ref hasLimit5, masteryData)).ToList()
        }
      };
    }

    private Dictionary<string, object> extractTier(JToken tier, ref bool hasLimit5, JObject masteryData) {
      hasLimit5 = !hasLimit5;
      return new Dictionary<string, object> {
        {
          "limit", hasLimit5 ? "5" : "1"
        }, {
          "masteries", tier["masteryTreeItems"].Where(mastery => mastery.Type != JTokenType.Null).Select(mastery => extractMastery(mastery, masteryData)).ToList()
        }
      };
    }

    private Dictionary<string, object> extractMastery(JToken mastery, JObject masteryData) {
      var id = mastery["masteryId"].ToString();
      var find = masteryData.Properties().Where(x => x.Value["id"].ToString().Equals(id)).Select(x => x.Value).First();
      string image = find["image"]["full"].ToString();
      Caller.downloadMasteryImage(image);
      return new Dictionary<string, object> {
        {
          "id", id
        }, {
          "name", extractToken(find["name"])
        }, {
          "description", extractToken(find["sanitizedDescription"])
        }, {
          "image", image
        }
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
          .DefaultIfEmpty("")
          .First();
    }

    private object extractToken(JToken token) {
      if (token == null || token.Type == JTokenType.Null) {
        return null;
      }
      if (token.Type == JTokenType.Object) {
        return extractObject((JObject)token);
      }
      if (token.Type == JTokenType.Array) {
        return extractArray((JArray)token);
      }
      return token.ToString();
    }

    private Dictionary<string, object> extractObject(JObject obj) {
      return obj.Properties().ToDictionary(prop => prop.Name, prop => extractToken(prop.Value));
    }

    private List<object> extractArray(JArray array) {
      return array.Select(extractToken).ToList();
    }
  }
}
