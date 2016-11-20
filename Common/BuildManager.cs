using System;
using System.Collections.Generic;
using System.Linq;

using Newtonsoft.Json.Linq;

namespace com.jcandksolutions.lol {
  public class BuildManager {
    private readonly List<Rune> mGlyphs;
    private readonly List<Item> mItems;
    private readonly List<Rune> mMarks;
    private readonly List<Rune> mQuints;
    private readonly List<Rune> mSeals;
    private JArray mBuilds = new JArray();
    private JArray mItemSets = new JArray();
    private JArray mMasteryPages = new JArray();
    private JArray mRunePages = new JArray();
    private Champion mEmptyChampion;
    private Item mEmptyItem;
    private Rune mEmptyRune;
    public Rune EmptyRune {
      get {
        return mEmptyRune ?? (mEmptyRune = new Rune {
          ID = "-1",
          Name = ""
        });
      }
    }
    public Item EmptyItem {
      get {
        return mEmptyItem ?? (mEmptyItem = new Item {
          ID = "-1",
          Name = ""
        });
      }
    }
    private Champion EmptyChampion {
      get {
        return mEmptyChampion ?? (mEmptyChampion = new Champion {
          ID = "-1",
          Name = ""
        });
      }
    }
    public List<Branch> MasteriesTree { get; private set; }
    public Rune[] MarksList {
      get {
        return mMarks.ToArray();
      }
    }
    public Rune[] SealsList {
      get {
        return mSeals.ToArray();
      }
    }
    public Rune[] GlyphsList {
      get {
        return mGlyphs.ToArray();
      }
    }
    public Rune[] QuintsList {
      get {
        return mQuints.ToArray();
      }
    }
    public Item[] ItemsList {
      get {
        return mItems.ToArray();
      }
    }
    public string[] BuildsList {
      get {
        return mBuilds.OrderBy(x => x["name"].ToString()).Select(x => x["name"].ToString()).ToArray();
      }
    }
    public string[] ItemSetsList {
      get {
        return mItemSets.OrderBy(x => x["name"].ToString()).Select(x => x["name"].ToString()).ToArray();
      }
    }
    public string[] RunePagesList {
      get {
        return mRunePages.OrderBy(x => x["name"].ToString()).Select(x => x["name"].ToString()).ToArray();
      }
    }
    public string[] MasteryPagesList {
      get {
        return mMasteryPages.OrderBy(x => x["name"].ToString()).Select(x => x["name"].ToString()).ToArray();
      }
    }
    public string[] ChampionsList {
      get {
        return ChampionsData.Select(x => x.Name).ToArray();
      }
    }
    public List<Build> BuildsData {
      get {
        return mBuilds.Select(B => new Build {
          BuildName = B["name"].ToString(),
          RunePage = B["runePage"].ToString(),
          MasteryPage = B["masteryPage"].ToString(),
          ItemSet = B["itemSet"].ToString(),
          StartAbilities = B["startAbilities"].ToString(),
          MaxOrder = B["maxOrder"].ToString(),
          Champion = ChampionsData.Where(CH => B["champion"].ToString() == CH.ID).Select(CH => CH.Name).FirstOrDefault() ?? "Champion Not Found"
        }).ToList();
      }
    }
    public MasteryPageList MasteryPagesData {
      get {
        return mMasteryPages.Select(MP => {
          MasteryPage o = new MasteryPage();
          foreach (JProperty prop in ((JObject)MP).Properties()) {
            o[prop.Name] = prop.Value.ToString();
          }
          return o;
        }).ToMasteryPageList();
      }
    }
    public List<RunePage> RunePagesData {
      get {
        return mRunePages.Select(RP => new RunePage {
          RunePageName = RP["name"].ToString(),
          Mark1 = mMarks.FirstOrDefault(I => RP["mark1"].ToString() == I.ID) ?? EmptyRune,
          Mark2 = mMarks.FirstOrDefault(I => RP["mark2"].ToString() == I.ID) ?? EmptyRune,
          Mark3 = mMarks.FirstOrDefault(I => RP["mark3"].ToString() == I.ID) ?? EmptyRune,
          Mark4 = mMarks.FirstOrDefault(I => RP["mark4"].ToString() == I.ID) ?? EmptyRune,
          Mark5 = mMarks.FirstOrDefault(I => RP["mark5"].ToString() == I.ID) ?? EmptyRune,
          Mark6 = mMarks.FirstOrDefault(I => RP["mark6"].ToString() == I.ID) ?? EmptyRune,
          Mark7 = mMarks.FirstOrDefault(I => RP["mark7"].ToString() == I.ID) ?? EmptyRune,
          Mark8 = mMarks.FirstOrDefault(I => RP["mark8"].ToString() == I.ID) ?? EmptyRune,
          Mark9 = mMarks.FirstOrDefault(I => RP["mark9"].ToString() == I.ID) ?? EmptyRune,
          Seal1 = mSeals.FirstOrDefault(I => RP["seal1"].ToString() == I.ID) ?? EmptyRune,
          Seal2 = mSeals.FirstOrDefault(I => RP["seal2"].ToString() == I.ID) ?? EmptyRune,
          Seal3 = mSeals.FirstOrDefault(I => RP["seal3"].ToString() == I.ID) ?? EmptyRune,
          Seal4 = mSeals.FirstOrDefault(I => RP["seal4"].ToString() == I.ID) ?? EmptyRune,
          Seal5 = mSeals.FirstOrDefault(I => RP["seal5"].ToString() == I.ID) ?? EmptyRune,
          Seal6 = mSeals.FirstOrDefault(I => RP["seal6"].ToString() == I.ID) ?? EmptyRune,
          Seal7 = mSeals.FirstOrDefault(I => RP["seal7"].ToString() == I.ID) ?? EmptyRune,
          Seal8 = mSeals.FirstOrDefault(I => RP["seal8"].ToString() == I.ID) ?? EmptyRune,
          Seal9 = mSeals.FirstOrDefault(I => RP["seal9"].ToString() == I.ID) ?? EmptyRune,
          Glyph1 = mGlyphs.FirstOrDefault(I => RP["glyph1"].ToString() == I.ID) ?? EmptyRune,
          Glyph2 = mGlyphs.FirstOrDefault(I => RP["glyph2"].ToString() == I.ID) ?? EmptyRune,
          Glyph3 = mGlyphs.FirstOrDefault(I => RP["glyph3"].ToString() == I.ID) ?? EmptyRune,
          Glyph4 = mGlyphs.FirstOrDefault(I => RP["glyph4"].ToString() == I.ID) ?? EmptyRune,
          Glyph5 = mGlyphs.FirstOrDefault(I => RP["glyph5"].ToString() == I.ID) ?? EmptyRune,
          Glyph6 = mGlyphs.FirstOrDefault(I => RP["glyph6"].ToString() == I.ID) ?? EmptyRune,
          Glyph7 = mGlyphs.FirstOrDefault(I => RP["glyph7"].ToString() == I.ID) ?? EmptyRune,
          Glyph8 = mGlyphs.FirstOrDefault(I => RP["glyph8"].ToString() == I.ID) ?? EmptyRune,
          Glyph9 = mGlyphs.FirstOrDefault(I => RP["glyph9"].ToString() == I.ID) ?? EmptyRune,
          Quint1 = mQuints.FirstOrDefault(I => RP["quint1"].ToString() == I.ID) ?? EmptyRune,
          Quint2 = mQuints.FirstOrDefault(I => RP["quint2"].ToString() == I.ID) ?? EmptyRune,
          Quint3 = mQuints.FirstOrDefault(I => RP["quint3"].ToString() == I.ID) ?? EmptyRune
        }).ToList();
      }
    }
    public List<Champion> ChampionsData { get; private set; }
    public List<ItemSet> ItemSetsData {
      get {
        return mItemSets.Select(IS => new ItemSet {
          ItemSetName = IS["name"].ToString(),
          Item1 = mItems.FirstOrDefault(I => IS["item1"].ToString() == I.ID) ?? EmptyItem,
          Item2 = mItems.FirstOrDefault(I => IS["item2"].ToString() == I.ID) ?? EmptyItem,
          Item3 = mItems.FirstOrDefault(I => IS["item3"].ToString() == I.ID) ?? EmptyItem,
          Item4 = mItems.FirstOrDefault(I => IS["item4"].ToString() == I.ID) ?? EmptyItem,
          Item5 = mItems.FirstOrDefault(I => IS["item5"].ToString() == I.ID) ?? EmptyItem,
          Item6 = mItems.FirstOrDefault(I => IS["item6"].ToString() == I.ID) ?? EmptyItem,
          Item7 = mItems.FirstOrDefault(I => IS["item7"].ToString() == I.ID) ?? EmptyItem,
          Item8 = mItems.FirstOrDefault(I => IS["item8"].ToString() == I.ID) ?? EmptyItem,
          Item9 = mItems.FirstOrDefault(I => IS["item9"].ToString() == I.ID) ?? EmptyItem,
          Item10 = mItems.FirstOrDefault(I => IS["item10"].ToString() == I.ID) ?? EmptyItem,
          Item11 = mItems.FirstOrDefault(I => IS["item11"].ToString() == I.ID) ?? EmptyItem,
          Item12 = mItems.FirstOrDefault(I => IS["item12"].ToString() == I.ID) ?? EmptyItem,
          Item13 = mItems.FirstOrDefault(I => IS["item13"].ToString() == I.ID) ?? EmptyItem,
          Item14 = mItems.FirstOrDefault(I => IS["item14"].ToString() == I.ID) ?? EmptyItem,
          Item15 = mItems.FirstOrDefault(I => IS["item15"].ToString() == I.ID) ?? EmptyItem,
          Item16 = mItems.FirstOrDefault(I => IS["item16"].ToString() == I.ID) ?? EmptyItem,
          Item17 = mItems.FirstOrDefault(I => IS["item17"].ToString() == I.ID) ?? EmptyItem,
          Item18 = mItems.FirstOrDefault(I => IS["item18"].ToString() == I.ID) ?? EmptyItem,
          Item19 = mItems.FirstOrDefault(I => IS["item19"].ToString() == I.ID) ?? EmptyItem,
          Item20 = mItems.FirstOrDefault(I => IS["item20"].ToString() == I.ID) ?? EmptyItem,
          Item21 = mItems.FirstOrDefault(I => IS["item21"].ToString() == I.ID) ?? EmptyItem,
          Item22 = mItems.FirstOrDefault(I => IS["item22"].ToString() == I.ID) ?? EmptyItem,
          Item23 = mItems.FirstOrDefault(I => IS["item23"].ToString() == I.ID) ?? EmptyItem,
          Item24 = mItems.FirstOrDefault(I => IS["item24"].ToString() == I.ID) ?? EmptyItem
        }).ToList();
      }
    }

    public BuildManager() {
      var staticData = loadDBData();
      var masteries = (JArray)staticData["masteries"];
      var runes = (JArray)staticData["runes"];
      var items = (JArray)staticData["items"];
      var champions = (JArray)staticData["champions"];
      if (items == null || runes == null || masteries == null || champions == null) {
        throw new FormatException("The database file has wrong format or is corrupted");
      }
      mItems = items.Select(extractItem).OrderBy(x => x.Name).ToList();
      mItems.Add(EmptyItem);
      var tempRunes = runes.Select(extractRune).OrderBy(x => x.Name).ToArray();
      mMarks = tempRunes.Where(x => x.Type == "red").ToList();
      mSeals = tempRunes.Where(x => x.Type == "yellow").ToList();
      mGlyphs = tempRunes.Where(x => x.Type == "blue").ToList();
      mQuints = tempRunes.Where(x => x.Type == "black").ToList();
      mMarks.Add(EmptyRune);
      mSeals.Add(EmptyRune);
      mGlyphs.Add(EmptyRune);
      mQuints.Add(EmptyRune);
      ChampionsData = champions.Select(extractChampion).OrderBy(x => x.Name).ToList();
      ChampionsData.Add(EmptyChampion);
      MasteriesTree = masteries.Select(extractBranch).OrderBy(x => x.Name).ToList();
    }

    public void loadBuild(string path) {
      var buildsData = loadBuildData(path);
      mItemSets = (JArray)buildsData["itemsets"];
      mRunePages = (JArray)buildsData["runes"];
      mMasteryPages = (JArray)buildsData["masteries"];
      mBuilds = (JArray)buildsData["builds"];
      if (mItemSets == null || mRunePages == null || mMasteryPages == null || mBuilds == null) {
        throw new FormatException("The builds file has wrong format or is corrupted");
      }
    }

    public void save(string path) {
      var ioManager = CommonInjector.provideIOManager();
      JObject root = new JObject();
      root["builds"] = mBuilds;
      root["masteries"] = mMasteryPages;
      root["runes"] = mRunePages;
      root["itemsets"] = mItemSets;
      ioManager.writeFile(path, root.ToString());
    }

    public void clear() {
      mBuilds = new JArray();
      mMasteryPages = new JArray();
      mRunePages = new JArray();
      mItemSets = new JArray();
    }

    public Build getBuildByName(string index) {
      return mBuilds.Where(B => B["name"].ToString() == index).Select(B => new Build {
        BuildName = B["name"].ToString(),
        RunePage = B["runePage"].ToString(),
        MasteryPage = B["masteryPage"].ToString(),
        ItemSet = B["itemSet"].ToString(),
        StartAbilities = B["startAbilities"].ToString(),
        MaxOrder = B["maxOrder"].ToString(),
        Champion = ChampionsData.Where(CH => B["champion"].ToString() == CH.ID).Select(CH => CH.Name).FirstOrDefault() ?? "Champion Not Found"
      }).First();
    }

    public MasteryPage getMasteryPageByName(string index) {
      return mMasteryPages.Where(MP => MP["name"].ToString() == index).Select(MP => {
        MasteryPage o = new MasteryPage();
        foreach (JProperty prop in ((JObject)MP).Properties()) {
          o[prop.Name] = prop.Value.ToString();
        }
        return o;
      }).First();
    }

    public RunePage getRunePageByName(string index) {
      return mRunePages.Where(RP => RP["name"].ToString() == index).Select(RP => new RunePage {
        RunePageName = RP["name"].ToString(),
        Mark1 = mMarks.FirstOrDefault(I => RP["mark1"].ToString() == I.ID) ?? EmptyRune,
        Mark2 = mMarks.FirstOrDefault(I => RP["mark2"].ToString() == I.ID) ?? EmptyRune,
        Mark3 = mMarks.FirstOrDefault(I => RP["mark3"].ToString() == I.ID) ?? EmptyRune,
        Mark4 = mMarks.FirstOrDefault(I => RP["mark4"].ToString() == I.ID) ?? EmptyRune,
        Mark5 = mMarks.FirstOrDefault(I => RP["mark5"].ToString() == I.ID) ?? EmptyRune,
        Mark6 = mMarks.FirstOrDefault(I => RP["mark6"].ToString() == I.ID) ?? EmptyRune,
        Mark7 = mMarks.FirstOrDefault(I => RP["mark7"].ToString() == I.ID) ?? EmptyRune,
        Mark8 = mMarks.FirstOrDefault(I => RP["mark8"].ToString() == I.ID) ?? EmptyRune,
        Mark9 = mMarks.FirstOrDefault(I => RP["mark9"].ToString() == I.ID) ?? EmptyRune,
        Seal1 = mSeals.FirstOrDefault(I => RP["seal1"].ToString() == I.ID) ?? EmptyRune,
        Seal2 = mSeals.FirstOrDefault(I => RP["seal2"].ToString() == I.ID) ?? EmptyRune,
        Seal3 = mSeals.FirstOrDefault(I => RP["seal3"].ToString() == I.ID) ?? EmptyRune,
        Seal4 = mSeals.FirstOrDefault(I => RP["seal4"].ToString() == I.ID) ?? EmptyRune,
        Seal5 = mSeals.FirstOrDefault(I => RP["seal5"].ToString() == I.ID) ?? EmptyRune,
        Seal6 = mSeals.FirstOrDefault(I => RP["seal6"].ToString() == I.ID) ?? EmptyRune,
        Seal7 = mSeals.FirstOrDefault(I => RP["seal7"].ToString() == I.ID) ?? EmptyRune,
        Seal8 = mSeals.FirstOrDefault(I => RP["seal8"].ToString() == I.ID) ?? EmptyRune,
        Seal9 = mSeals.FirstOrDefault(I => RP["seal9"].ToString() == I.ID) ?? EmptyRune,
        Glyph1 = mGlyphs.FirstOrDefault(I => RP["glyph1"].ToString() == I.ID) ?? EmptyRune,
        Glyph2 = mGlyphs.FirstOrDefault(I => RP["glyph2"].ToString() == I.ID) ?? EmptyRune,
        Glyph3 = mGlyphs.FirstOrDefault(I => RP["glyph3"].ToString() == I.ID) ?? EmptyRune,
        Glyph4 = mGlyphs.FirstOrDefault(I => RP["glyph4"].ToString() == I.ID) ?? EmptyRune,
        Glyph5 = mGlyphs.FirstOrDefault(I => RP["glyph5"].ToString() == I.ID) ?? EmptyRune,
        Glyph6 = mGlyphs.FirstOrDefault(I => RP["glyph6"].ToString() == I.ID) ?? EmptyRune,
        Glyph7 = mGlyphs.FirstOrDefault(I => RP["glyph7"].ToString() == I.ID) ?? EmptyRune,
        Glyph8 = mGlyphs.FirstOrDefault(I => RP["glyph8"].ToString() == I.ID) ?? EmptyRune,
        Glyph9 = mGlyphs.FirstOrDefault(I => RP["glyph9"].ToString() == I.ID) ?? EmptyRune,
        Quint1 = mQuints.FirstOrDefault(I => RP["quint1"].ToString() == I.ID) ?? EmptyRune,
        Quint2 = mQuints.FirstOrDefault(I => RP["quint2"].ToString() == I.ID) ?? EmptyRune,
        Quint3 = mQuints.FirstOrDefault(I => RP["quint3"].ToString() == I.ID) ?? EmptyRune
      }).First();
    }

    public ItemSet getItemSetByName(string index) {
      return mItemSets.Where(IS => IS["name"].ToString() == index).Select(IS => new ItemSet {
        ItemSetName = IS["name"].ToString(),
        Item1 = mItems.FirstOrDefault(I => IS["item1"].ToString() == I.ID) ?? EmptyItem,
        Item2 = mItems.FirstOrDefault(I => IS["item2"].ToString() == I.ID) ?? EmptyItem,
        Item3 = mItems.FirstOrDefault(I => IS["item3"].ToString() == I.ID) ?? EmptyItem,
        Item4 = mItems.FirstOrDefault(I => IS["item4"].ToString() == I.ID) ?? EmptyItem,
        Item5 = mItems.FirstOrDefault(I => IS["item5"].ToString() == I.ID) ?? EmptyItem,
        Item6 = mItems.FirstOrDefault(I => IS["item6"].ToString() == I.ID) ?? EmptyItem,
        Item7 = mItems.FirstOrDefault(I => IS["item7"].ToString() == I.ID) ?? EmptyItem,
        Item8 = mItems.FirstOrDefault(I => IS["item8"].ToString() == I.ID) ?? EmptyItem,
        Item9 = mItems.FirstOrDefault(I => IS["item9"].ToString() == I.ID) ?? EmptyItem,
        Item10 = mItems.FirstOrDefault(I => IS["item10"].ToString() == I.ID) ?? EmptyItem,
        Item11 = mItems.FirstOrDefault(I => IS["item11"].ToString() == I.ID) ?? EmptyItem,
        Item12 = mItems.FirstOrDefault(I => IS["item12"].ToString() == I.ID) ?? EmptyItem,
        Item13 = mItems.FirstOrDefault(I => IS["item13"].ToString() == I.ID) ?? EmptyItem,
        Item14 = mItems.FirstOrDefault(I => IS["item14"].ToString() == I.ID) ?? EmptyItem,
        Item15 = mItems.FirstOrDefault(I => IS["item15"].ToString() == I.ID) ?? EmptyItem,
        Item16 = mItems.FirstOrDefault(I => IS["item16"].ToString() == I.ID) ?? EmptyItem,
        Item17 = mItems.FirstOrDefault(I => IS["item17"].ToString() == I.ID) ?? EmptyItem,
        Item18 = mItems.FirstOrDefault(I => IS["item18"].ToString() == I.ID) ?? EmptyItem,
        Item19 = mItems.FirstOrDefault(I => IS["item19"].ToString() == I.ID) ?? EmptyItem,
        Item20 = mItems.FirstOrDefault(I => IS["item20"].ToString() == I.ID) ?? EmptyItem,
        Item21 = mItems.FirstOrDefault(I => IS["item21"].ToString() == I.ID) ?? EmptyItem,
        Item22 = mItems.FirstOrDefault(I => IS["item22"].ToString() == I.ID) ?? EmptyItem,
        Item23 = mItems.FirstOrDefault(I => IS["item23"].ToString() == I.ID) ?? EmptyItem,
        Item24 = mItems.FirstOrDefault(I => IS["item24"].ToString() == I.ID) ?? EmptyItem
      }).First();
    }

    public void updateBuild(Build d) {
      var build = mBuilds.First(x => x["name"].ToString() == d.BuildName);
      build["runePage"] = d.RunePage;
      build["masteryPage"] = d.MasteryPage;
      build["itemSet"] = d.ItemSet;
      build["startAbilities"] = d.StartAbilities;
      build["maxOrder"] = d.MaxOrder;
      build["champion"] = ChampionsData.Where(i => i.Name == d.Champion).Select(i => i.ID).First();
    }

    public void updateItemSet(ItemSet d) {
      var itemSet = mItemSets.First(x => x["name"].ToString() == d.ItemSetName);
      itemSet["item1"] = mItems.Where(i => i == d.Item1).Select(i => i.ID).First();
      itemSet["item2"] = mItems.Where(i => i == d.Item2).Select(i => i.ID).First();
      itemSet["item3"] = mItems.Where(i => i == d.Item3).Select(i => i.ID).First();
      itemSet["item4"] = mItems.Where(i => i == d.Item4).Select(i => i.ID).First();
      itemSet["item5"] = mItems.Where(i => i == d.Item5).Select(i => i.ID).First();
      itemSet["item6"] = mItems.Where(i => i == d.Item6).Select(i => i.ID).First();
      itemSet["item7"] = mItems.Where(i => i == d.Item7).Select(i => i.ID).First();
      itemSet["item8"] = mItems.Where(i => i == d.Item8).Select(i => i.ID).First();
      itemSet["item9"] = mItems.Where(i => i == d.Item9).Select(i => i.ID).First();
      itemSet["item10"] = mItems.Where(i => i == d.Item10).Select(i => i.ID).First();
      itemSet["item11"] = mItems.Where(i => i == d.Item11).Select(i => i.ID).First();
      itemSet["item12"] = mItems.Where(i => i == d.Item12).Select(i => i.ID).First();
      itemSet["item13"] = mItems.Where(i => i == d.Item13).Select(i => i.ID).First();
      itemSet["item14"] = mItems.Where(i => i == d.Item14).Select(i => i.ID).First();
      itemSet["item15"] = mItems.Where(i => i == d.Item15).Select(i => i.ID).First();
      itemSet["item16"] = mItems.Where(i => i == d.Item16).Select(i => i.ID).First();
      itemSet["item17"] = mItems.Where(i => i == d.Item17).Select(i => i.ID).First();
      itemSet["item18"] = mItems.Where(i => i == d.Item18).Select(i => i.ID).First();
      itemSet["item19"] = mItems.Where(i => i == d.Item19).Select(i => i.ID).First();
      itemSet["item20"] = mItems.Where(i => i == d.Item20).Select(i => i.ID).First();
      itemSet["item21"] = mItems.Where(i => i == d.Item21).Select(i => i.ID).First();
      itemSet["item22"] = mItems.Where(i => i == d.Item22).Select(i => i.ID).First();
      itemSet["item23"] = mItems.Where(i => i == d.Item23).Select(i => i.ID).First();
      itemSet["item24"] = mItems.Where(i => i == d.Item24).Select(i => i.ID).First();
    }

    public void updateRunePage(RunePage d) {
      var runePage = mRunePages.First(x => x["name"].ToString() == d.RunePageName);
      runePage["mark1"] = mMarks.Where(i => i == d.Mark1).Select(i => i.ID).First();
      runePage["mark2"] = mMarks.Where(i => i == d.Mark2).Select(i => i.ID).First();
      runePage["mark3"] = mMarks.Where(i => i == d.Mark3).Select(i => i.ID).First();
      runePage["mark4"] = mMarks.Where(i => i == d.Mark4).Select(i => i.ID).First();
      runePage["mark5"] = mMarks.Where(i => i == d.Mark5).Select(i => i.ID).First();
      runePage["mark6"] = mMarks.Where(i => i == d.Mark6).Select(i => i.ID).First();
      runePage["mark7"] = mMarks.Where(i => i == d.Mark7).Select(i => i.ID).First();
      runePage["mark8"] = mMarks.Where(i => i == d.Mark8).Select(i => i.ID).First();
      runePage["mark9"] = mMarks.Where(i => i == d.Mark9).Select(i => i.ID).First();
      runePage["seal1"] = mSeals.Where(i => i == d.Seal1).Select(i => i.ID).First();
      runePage["seal2"] = mSeals.Where(i => i == d.Seal2).Select(i => i.ID).First();
      runePage["seal3"] = mSeals.Where(i => i == d.Seal3).Select(i => i.ID).First();
      runePage["seal4"] = mSeals.Where(i => i == d.Seal4).Select(i => i.ID).First();
      runePage["seal5"] = mSeals.Where(i => i == d.Seal5).Select(i => i.ID).First();
      runePage["seal6"] = mSeals.Where(i => i == d.Seal6).Select(i => i.ID).First();
      runePage["seal7"] = mSeals.Where(i => i == d.Seal7).Select(i => i.ID).First();
      runePage["seal8"] = mSeals.Where(i => i == d.Seal8).Select(i => i.ID).First();
      runePage["seal9"] = mSeals.Where(i => i == d.Seal9).Select(i => i.ID).First();
      runePage["glyph1"] = mGlyphs.Where(i => i == d.Glyph1).Select(i => i.ID).First();
      runePage["glyph2"] = mGlyphs.Where(i => i == d.Glyph2).Select(i => i.ID).First();
      runePage["glyph3"] = mGlyphs.Where(i => i == d.Glyph3).Select(i => i.ID).First();
      runePage["glyph4"] = mGlyphs.Where(i => i == d.Glyph4).Select(i => i.ID).First();
      runePage["glyph5"] = mGlyphs.Where(i => i == d.Glyph5).Select(i => i.ID).First();
      runePage["glyph6"] = mGlyphs.Where(i => i == d.Glyph6).Select(i => i.ID).First();
      runePage["glyph7"] = mGlyphs.Where(i => i == d.Glyph7).Select(i => i.ID).First();
      runePage["glyph8"] = mGlyphs.Where(i => i == d.Glyph8).Select(i => i.ID).First();
      runePage["glyph9"] = mGlyphs.Where(i => i == d.Glyph9).Select(i => i.ID).First();
      runePage["quint1"] = mQuints.Where(i => i == d.Quint1).Select(i => i.ID).First();
      runePage["quint2"] = mQuints.Where(i => i == d.Quint2).Select(i => i.ID).First();
      runePage["quint3"] = mQuints.Where(i => i == d.Quint3).Select(i => i.ID).First();
    }

    public void updateMasteryPage(MasteryPage d) {
      var masteryPage = mMasteryPages.First(x => x["name"].ToString() == d["name"]);
      foreach (var prop in d.Properties) {
        masteryPage[prop.Key] = prop.Value;
      }
    }

    public void addBuild(Build d) {
      var build = new JObject();
      build["name"] = d.BuildName;
      build["runePage"] = d.RunePage;
      build["masteryPage"] = d.MasteryPage;
      build["itemSet"] = d.ItemSet;
      build["startAbilities"] = d.StartAbilities;
      build["maxOrder"] = d.MaxOrder;
      build["champion"] = ChampionsData.Where(i => i.Name == d.Champion).Select(i => i.ID).First();
      mBuilds.Add(build);
    }

    public void addItemSet(ItemSet d) {
      var itemSet = new JObject();
      itemSet["name"] = d.ItemSetName;
      itemSet["item1"] = mItems.Where(i => i == d.Item1).Select(i => i.ID).First();
      itemSet["item2"] = mItems.Where(i => i == d.Item2).Select(i => i.ID).First();
      itemSet["item3"] = mItems.Where(i => i == d.Item3).Select(i => i.ID).First();
      itemSet["item4"] = mItems.Where(i => i == d.Item4).Select(i => i.ID).First();
      itemSet["item5"] = mItems.Where(i => i == d.Item5).Select(i => i.ID).First();
      itemSet["item6"] = mItems.Where(i => i == d.Item6).Select(i => i.ID).First();
      itemSet["item7"] = mItems.Where(i => i == d.Item7).Select(i => i.ID).First();
      itemSet["item8"] = mItems.Where(i => i == d.Item8).Select(i => i.ID).First();
      itemSet["item9"] = mItems.Where(i => i == d.Item9).Select(i => i.ID).First();
      itemSet["item10"] = mItems.Where(i => i == d.Item10).Select(i => i.ID).First();
      itemSet["item11"] = mItems.Where(i => i == d.Item11).Select(i => i.ID).First();
      itemSet["item12"] = mItems.Where(i => i == d.Item12).Select(i => i.ID).First();
      itemSet["item13"] = mItems.Where(i => i == d.Item13).Select(i => i.ID).First();
      itemSet["item14"] = mItems.Where(i => i == d.Item14).Select(i => i.ID).First();
      itemSet["item15"] = mItems.Where(i => i == d.Item15).Select(i => i.ID).First();
      itemSet["item16"] = mItems.Where(i => i == d.Item16).Select(i => i.ID).First();
      itemSet["item17"] = mItems.Where(i => i == d.Item17).Select(i => i.ID).First();
      itemSet["item18"] = mItems.Where(i => i == d.Item18).Select(i => i.ID).First();
      itemSet["item19"] = mItems.Where(i => i == d.Item19).Select(i => i.ID).First();
      itemSet["item20"] = mItems.Where(i => i == d.Item20).Select(i => i.ID).First();
      itemSet["item21"] = mItems.Where(i => i == d.Item21).Select(i => i.ID).First();
      itemSet["item22"] = mItems.Where(i => i == d.Item22).Select(i => i.ID).First();
      itemSet["item23"] = mItems.Where(i => i == d.Item23).Select(i => i.ID).First();
      itemSet["item24"] = mItems.Where(i => i == d.Item24).Select(i => i.ID).First();
      mItemSets.Add(itemSet);
    }

    public void addRunePage(RunePage d) {
      var runePage = new JObject();
      runePage["name"] = d.RunePageName;
      runePage["mark1"] = mMarks.Where(i => i == d.Mark1).Select(i => i.ID).First();
      runePage["mark2"] = mMarks.Where(i => i == d.Mark2).Select(i => i.ID).First();
      runePage["mark3"] = mMarks.Where(i => i == d.Mark3).Select(i => i.ID).First();
      runePage["mark4"] = mMarks.Where(i => i == d.Mark4).Select(i => i.ID).First();
      runePage["mark5"] = mMarks.Where(i => i == d.Mark5).Select(i => i.ID).First();
      runePage["mark6"] = mMarks.Where(i => i == d.Mark6).Select(i => i.ID).First();
      runePage["mark7"] = mMarks.Where(i => i == d.Mark7).Select(i => i.ID).First();
      runePage["mark8"] = mMarks.Where(i => i == d.Mark8).Select(i => i.ID).First();
      runePage["mark9"] = mMarks.Where(i => i == d.Mark9).Select(i => i.ID).First();
      runePage["seal1"] = mSeals.Where(i => i == d.Seal1).Select(i => i.ID).First();
      runePage["seal2"] = mSeals.Where(i => i == d.Seal2).Select(i => i.ID).First();
      runePage["seal3"] = mSeals.Where(i => i == d.Seal3).Select(i => i.ID).First();
      runePage["seal4"] = mSeals.Where(i => i == d.Seal4).Select(i => i.ID).First();
      runePage["seal5"] = mSeals.Where(i => i == d.Seal5).Select(i => i.ID).First();
      runePage["seal6"] = mSeals.Where(i => i == d.Seal6).Select(i => i.ID).First();
      runePage["seal7"] = mSeals.Where(i => i == d.Seal7).Select(i => i.ID).First();
      runePage["seal8"] = mSeals.Where(i => i == d.Seal8).Select(i => i.ID).First();
      runePage["seal9"] = mSeals.Where(i => i == d.Seal9).Select(i => i.ID).First();
      runePage["glyph1"] = mGlyphs.Where(i => i == d.Glyph1).Select(i => i.ID).First();
      runePage["glyph2"] = mGlyphs.Where(i => i == d.Glyph2).Select(i => i.ID).First();
      runePage["glyph3"] = mGlyphs.Where(i => i == d.Glyph3).Select(i => i.ID).First();
      runePage["glyph4"] = mGlyphs.Where(i => i == d.Glyph4).Select(i => i.ID).First();
      runePage["glyph5"] = mGlyphs.Where(i => i == d.Glyph5).Select(i => i.ID).First();
      runePage["glyph6"] = mGlyphs.Where(i => i == d.Glyph6).Select(i => i.ID).First();
      runePage["glyph7"] = mGlyphs.Where(i => i == d.Glyph7).Select(i => i.ID).First();
      runePage["glyph8"] = mGlyphs.Where(i => i == d.Glyph8).Select(i => i.ID).First();
      runePage["glyph9"] = mGlyphs.Where(i => i == d.Glyph9).Select(i => i.ID).First();
      runePage["quint1"] = mQuints.Where(i => i == d.Quint1).Select(i => i.ID).First();
      runePage["quint2"] = mQuints.Where(i => i == d.Quint2).Select(i => i.ID).First();
      runePage["quint3"] = mQuints.Where(i => i == d.Quint3).Select(i => i.ID).First();
      mRunePages.Add(runePage);
    }

    public void addMasteryPage(MasteryPage d) {
      var masteryPage = new JObject();
      foreach (var prop in d.Properties) {
        masteryPage[prop.Key] = prop.Value;
      }
      mMasteryPages.Add(masteryPage);
    }

    public void removeBuild(Build d) {
      mBuilds.First(x => x["name"].ToString() == d.BuildName).Remove();
    }

    public void removeItemSet(ItemSet d) {
      mItemSets.First(x => x["name"].ToString() == d.ItemSetName).Remove();
    }

    public void removeRunePage(RunePage d) {
      mRunePages.First(x => x["name"].ToString() == d.RunePageName).Remove();
    }

    public void removeMasteryPage(MasteryPage d) {
      mMasteryPages.First(x => x["name"].ToString() == d["name"]).Remove();
    }

    public void updateBuildName(Build d, string newName) {
      var build = mBuilds.First(x => x["name"].ToString() == d.BuildName);
      build["name"] = newName;
      d.BuildName = newName;
    }

    public void updateItemSetName(ItemSet d, string newName) {
      var itemSet = mItemSets.First(x => x["name"].ToString() == d.ItemSetName);
      itemSet["name"] = newName;
      d.ItemSetName = newName;
    }

    public void updateRunePageName(RunePage d, string newName) {
      var runePage = mRunePages.First(x => x["name"].ToString() == d.RunePageName);
      runePage["name"] = newName;
      d.RunePageName = newName;
    }

    public void updateMasteryPageName(MasteryPage d, string newName) {
      var masteryPage = mMasteryPages.First(x => x["name"].ToString() == d["name"]);
      masteryPage["name"] = newName;
      d["name"] = newName;
    }

    private Branch extractBranch(JToken b) {
      return new Branch {
        Name = b["name"].ToString(),
        Tiers = b["tiers"].Select(extractTier).ToList()
      };
    }

    private Tier extractTier(JToken t) {
      return new Tier {
        Limit = int.Parse(t["limit"].ToString()),
        Masteries = t["masteries"].Select(extractMastery).ToList()
      };
    }

    private Mastery extractMastery(JToken m) {
      MasteryPage.MasteryNames.Add(m["id"].ToString());
      return new Mastery {
        ID = m["id"].ToString(),
        Name = m["name"].ToString(),
        Description = m["description"].ToString(),
        ImageURL = m["image"].ToString()
      };
    }

    private Rune extractRune(JToken r) {
      return new Rune {
        Name = r["name"].ToString(),
        ID = r["id"].ToString(),
        Type = r["type"].ToString(),
        Description = r["description"].ToString(),
        ImageURL = r["image"].ToString()
      };
    }

    private Champion extractChampion(JToken ch) {
      return new Champion {
        ID = ch["id"].ToString(),
        Name = ch["name"].ToString(),
        Passive = extractPassive(ch["passive"]),
        Spell1 = extractSpell(ch["spells"][0]),
        Spell2 = extractSpell(ch["spells"][1]),
        Spell3 = extractSpell(ch["spells"][2]),
        Spell4 = extractSpell(ch["spells"][3]),
        ImageURL = ch["image"].ToString()
      };
    }

    private Spell extractSpell(JToken spell) {
      return new Spell {
        Name = spell["name"].ToString(),
        Description = spell["description"].ToString(),
        Tooltip = spell["tooltip"].ToString(),
        Resource = spell["resource"].ToString(),
        MaxRank = int.Parse(spell["maxrank"].ToString()),
        Cooldown = spell["cooldown"].ToString(),
        Effect = spell["effect"].Select(x => x.ToString()).ToList(),
        Range = spell["range"].ToString(),
        Cost = spell["cost"].ToString(),
        Vars = spell["vars"] == null ? null : spell["vars"].Select(extractVar).ToList(),
        ImageURL = spell["image"].ToString()
      };
    }

    private Var extractVar(JToken var) {
      return new Var {
        Key = var["key"].ToString(),
        Type = var["link"].ToString(),
        RanksWith = var["ranksWith"].ToString(),
        Value = var["coeff"].Aggregate((i, j) => i.ToString() + "/" + j.ToString()).ToString()
      };
    }

    private Passive extractPassive(JToken passive) {
      return new Passive {
        Name = passive["name"].ToString(),
        Description = passive["description"].ToString(),
        ImageURL = passive["image"].ToString()
      };
    }

    private Item extractItem(JToken item) {
      return new Item {
        Name = item["name"].ToString(),
        ID = item["id"].ToString(),
        Description = item["description"].ToString(),
        Gold = item["gold"].ToString(),
        ImageURL = item["image"].ToString()
      };
    }

    private JObject loadDBData() {
      var ioManager = CommonInjector.provideIOManager();
      return JObject.Parse(ioManager.readFile("./db.json"));
    }

    private JObject loadBuildData(string path) {
      var ioManager = CommonInjector.provideIOManager();
      return JObject.Parse(ioManager.readFile(path));
    }
  }
}
