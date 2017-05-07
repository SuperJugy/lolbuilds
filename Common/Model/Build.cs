using System.Drawing;

using com.jcandksolutions.lol.DependencyInjection;

using Newtonsoft.Json;

namespace com.jcandksolutions.lol.Model {
  [JsonObject(MemberSerialization.OptIn)]
  public class Build {
    private string mChampionID;
    private string mChampionName;

    [JsonProperty("name")]
    public string BuildName { get; set; }
    [JsonProperty("runePage")]
    public string RunePage { get; set; }
    [JsonProperty("masteryPage")]
    public string MasteryPage { get; set; }
    [JsonProperty("itemSet")]
    public string ItemSet { get; set; }
    [JsonProperty("startAbilities")]
    public string StartAbilities { get; set; }
    [JsonProperty("maxOrder")]
    public string MaxOrder { get; set; }
    [JsonProperty("summoner1")]
    public string Summoner1ID {
      get {
        return Summoner1.ID;
      }
      set {
        Summoner1 = CommonInjector.provideBuildManager().getSummonerByID(value);
      }
    }
    [JsonProperty("summoner2")]
    public string Summoner2ID {
      get {
        return Summoner2.ID;
      }
      set {
        Summoner2 = CommonInjector.provideBuildManager().getSummonerByID(value);
      }
    }
    [JsonProperty("champion")]
    public string ChampionID {
      get {
        return mChampionID;
      }
      set {
        mChampionID = value;
        ChampionName = CommonInjector.provideBuildManager().GetChampionNameById(value);
      }
    }
    public string ChampionName {
      get {
        return mChampionName;
      }
      set {
        mChampionName = value;
        mChampionID = CommonInjector.provideBuildManager().GetChampionIDByName(value);
      }
    }
    public SummonerSpell Summoner1 { get; set; }
    public SummonerSpell Summoner2 { get; set; }
    public Bitmap Summoner1Image {
      get {
        return Summoner1.Image;
      }
    }
    public Bitmap Summoner2Image {
      get {
        return Summoner2.Image;
      }
    }

    public Build() {
      SummonerSpell emptySummoner = CommonInjector.provideBuildManager().EmptySummoner;
      BuildName = "";
      RunePage = "";
      MasteryPage = "";
      ItemSet = "";
      StartAbilities = "";
      MaxOrder = "";
      Summoner1 = emptySummoner;
      Summoner2 = emptySummoner;
      ChampionName = "";
      mChampionID = "";
    }

    public Build(Build build) {
      BuildName = "";
      RunePage = build.RunePage;
      MasteryPage = build.MasteryPage;
      ItemSet = build.ItemSet;
      StartAbilities = build.StartAbilities;
      MaxOrder = build.MaxOrder;
      Summoner1 = build.Summoner1;
      Summoner2 = build.Summoner2;
      mChampionID = build.mChampionID;
      ChampionName = build.ChampionName;
    }
  }
}
