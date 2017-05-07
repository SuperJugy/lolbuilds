using com.jcandksolutions.lol.DependencyInjection;
using Newtonsoft.Json;

namespace com.jcandksolutions.lol.Model {
  [JsonObject(MemberSerialization.OptIn)]
  public class Build
  {
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
    [JsonProperty("champion")]
    public string ChampionID
    {
      get
      {
        return mChampionID;
      }
      set
      {
        mChampionID = value;
        ChampionName = CommonInjector.provideBuildManager().GetChampionNameById(value);
      }
    }

    public string ChampionName
    {
      get { return mChampionName; }
      set
      {
        mChampionName = value;
        mChampionID = CommonInjector.provideBuildManager().GetChampionIDByName(value);
      }
    }

    public Build() {
      BuildName = "";
      RunePage = "";
      MasteryPage = "";
      ItemSet = "";
      StartAbilities = "";
      MaxOrder = "";
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
      mChampionID = build.mChampionID;
      ChampionName = build.ChampionName;
    }
  }
}
