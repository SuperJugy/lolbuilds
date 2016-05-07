using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace com.jcandksolutions.lol {
  public class BuildManager {
    private List<Item> mItems;
    private List<Rune> mMarks;
    private List<Rune> mSeals;
    private List<Rune> mGlyphs;
    private List<Rune> mQuints;
    private List<Champion> mChampions;
    private List<Branch> mMasteries;
    private JArray mItemSets = new JArray();
    private JArray mRunePages = new JArray();
    private JArray mMasteryPages = new JArray();
    private JArray mBuilds = new JArray();
    private Rune mEmptyRune;
    private Item mEmptyItem;
    private Champion mEmptyChampion;
    public Rune EmptyRune {
      get {
        if (mEmptyRune == null) {
          mEmptyRune = new Rune() { ID = "-1", Name = "" };
        }
        return mEmptyRune;
      }
    }
    public Item EmptyItem {
      get {
        if (mEmptyItem == null) {
          mEmptyItem = new Item() { ID = "-1", Name = "" };
        }
        return mEmptyItem;
      }
    }
    public Champion EmptyChampion {
      get {
        if (mEmptyChampion == null) {
          mEmptyChampion = new Champion() { ID = "-1", Name = "" };
        }
        return mEmptyChampion;
      }
    }
    public List<Branch> MasteriesTree {
      get {
        return mMasteries;
      }
    }
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
        return mChampions.Select(x => x.Name).ToArray();
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
          Champion = mChampions.Where(CH => B["champion"].ToString() == CH.ID).Select(CH => CH.Name).FirstOrDefault() ?? "Champion Not Found"
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
          Mark1 = mMarks.Where(I => RP["mark1"].ToString() == I.ID).FirstOrDefault() ?? EmptyRune,
          Mark2 = mMarks.Where(I => RP["mark2"].ToString() == I.ID).FirstOrDefault() ?? EmptyRune,
          Mark3 = mMarks.Where(I => RP["mark3"].ToString() == I.ID).FirstOrDefault() ?? EmptyRune,
          Mark4 = mMarks.Where(I => RP["mark4"].ToString() == I.ID).FirstOrDefault() ?? EmptyRune,
          Mark5 = mMarks.Where(I => RP["mark5"].ToString() == I.ID).FirstOrDefault() ?? EmptyRune,
          Mark6 = mMarks.Where(I => RP["mark6"].ToString() == I.ID).FirstOrDefault() ?? EmptyRune,
          Mark7 = mMarks.Where(I => RP["mark7"].ToString() == I.ID).FirstOrDefault() ?? EmptyRune,
          Mark8 = mMarks.Where(I => RP["mark8"].ToString() == I.ID).FirstOrDefault() ?? EmptyRune,
          Mark9 = mMarks.Where(I => RP["mark9"].ToString() == I.ID).FirstOrDefault() ?? EmptyRune,
          Seal1 = mSeals.Where(I => RP["seal1"].ToString() == I.ID).FirstOrDefault() ?? EmptyRune,
          Seal2 = mSeals.Where(I => RP["seal2"].ToString() == I.ID).FirstOrDefault() ?? EmptyRune,
          Seal3 = mSeals.Where(I => RP["seal3"].ToString() == I.ID).FirstOrDefault() ?? EmptyRune,
          Seal4 = mSeals.Where(I => RP["seal4"].ToString() == I.ID).FirstOrDefault() ?? EmptyRune,
          Seal5 = mSeals.Where(I => RP["seal5"].ToString() == I.ID).FirstOrDefault() ?? EmptyRune,
          Seal6 = mSeals.Where(I => RP["seal6"].ToString() == I.ID).FirstOrDefault() ?? EmptyRune,
          Seal7 = mSeals.Where(I => RP["seal7"].ToString() == I.ID).FirstOrDefault() ?? EmptyRune,
          Seal8 = mSeals.Where(I => RP["seal8"].ToString() == I.ID).FirstOrDefault() ?? EmptyRune,
          Seal9 = mSeals.Where(I => RP["seal9"].ToString() == I.ID).FirstOrDefault() ?? EmptyRune,
          Glyph1 = mGlyphs.Where(I => RP["glyph1"].ToString() == I.ID).FirstOrDefault() ?? EmptyRune,
          Glyph2 = mGlyphs.Where(I => RP["glyph2"].ToString() == I.ID).FirstOrDefault() ?? EmptyRune,
          Glyph3 = mGlyphs.Where(I => RP["glyph3"].ToString() == I.ID).FirstOrDefault() ?? EmptyRune,
          Glyph4 = mGlyphs.Where(I => RP["glyph4"].ToString() == I.ID).FirstOrDefault() ?? EmptyRune,
          Glyph5 = mGlyphs.Where(I => RP["glyph5"].ToString() == I.ID).FirstOrDefault() ?? EmptyRune,
          Glyph6 = mGlyphs.Where(I => RP["glyph6"].ToString() == I.ID).FirstOrDefault() ?? EmptyRune,
          Glyph7 = mGlyphs.Where(I => RP["glyph7"].ToString() == I.ID).FirstOrDefault() ?? EmptyRune,
          Glyph8 = mGlyphs.Where(I => RP["glyph8"].ToString() == I.ID).FirstOrDefault() ?? EmptyRune,
          Glyph9 = mGlyphs.Where(I => RP["glyph9"].ToString() == I.ID).FirstOrDefault() ?? EmptyRune,
          Quint1 = mQuints.Where(I => RP["quint1"].ToString() == I.ID).FirstOrDefault() ?? EmptyRune,
          Quint2 = mQuints.Where(I => RP["quint1"].ToString() == I.ID).FirstOrDefault() ?? EmptyRune,
          Quint3 = mQuints.Where(I => RP["quint1"].ToString() == I.ID).FirstOrDefault() ?? EmptyRune
        }).ToList();
      }
    }
    public List<Champion> ChampionsData {
      get {
        return mChampions;
      }
    }
    public List<ItemSet> ItemSetsData {
      get {
        return mItemSets.Select(IS => new ItemSet {
          ItemSetName = IS["name"].ToString(),
          Item1 = mItems.Where(I => IS["item1"].ToString() == I.ID).FirstOrDefault() ?? EmptyItem,
          Item2 = mItems.Where(I => IS["item2"].ToString() == I.ID).FirstOrDefault() ?? EmptyItem,
          Item3 = mItems.Where(I => IS["item3"].ToString() == I.ID).FirstOrDefault() ?? EmptyItem,
          Item4 = mItems.Where(I => IS["item4"].ToString() == I.ID).FirstOrDefault() ?? EmptyItem,
          Item5 = mItems.Where(I => IS["item5"].ToString() == I.ID).FirstOrDefault() ?? EmptyItem,
          Item6 = mItems.Where(I => IS["item6"].ToString() == I.ID).FirstOrDefault() ?? EmptyItem,
          Item7 = mItems.Where(I => IS["item7"].ToString() == I.ID).FirstOrDefault() ?? EmptyItem,
          Item8 = mItems.Where(I => IS["item8"].ToString() == I.ID).FirstOrDefault() ?? EmptyItem,
          Item9 = mItems.Where(I => IS["item9"].ToString() == I.ID).FirstOrDefault() ?? EmptyItem,
          Item10 = mItems.Where(I => IS["item10"].ToString() == I.ID).FirstOrDefault() ?? EmptyItem,
          Item11 = mItems.Where(I => IS["item11"].ToString() == I.ID).FirstOrDefault() ?? EmptyItem,
          Item12 = mItems.Where(I => IS["item12"].ToString() == I.ID).FirstOrDefault() ?? EmptyItem,
          Item13 = mItems.Where(I => IS["item13"].ToString() == I.ID).FirstOrDefault() ?? EmptyItem,
          Item14 = mItems.Where(I => IS["item14"].ToString() == I.ID).FirstOrDefault() ?? EmptyItem,
          Item15 = mItems.Where(I => IS["item15"].ToString() == I.ID).FirstOrDefault() ?? EmptyItem,
          Item16 = mItems.Where(I => IS["item16"].ToString() == I.ID).FirstOrDefault() ?? EmptyItem,
          Item17 = mItems.Where(I => IS["item17"].ToString() == I.ID).FirstOrDefault() ?? EmptyItem,
          Item18 = mItems.Where(I => IS["item18"].ToString() == I.ID).FirstOrDefault() ?? EmptyItem,
          Item19 = mItems.Where(I => IS["item19"].ToString() == I.ID).FirstOrDefault() ?? EmptyItem,
          Item20 = mItems.Where(I => IS["item20"].ToString() == I.ID).FirstOrDefault() ?? EmptyItem,
          Item21 = mItems.Where(I => IS["item21"].ToString() == I.ID).FirstOrDefault() ?? EmptyItem,
          Item22 = mItems.Where(I => IS["item22"].ToString() == I.ID).FirstOrDefault() ?? EmptyItem,
          Item23 = mItems.Where(I => IS["item23"].ToString() == I.ID).FirstOrDefault() ?? EmptyItem,
          Item24 = mItems.Where(I => IS["item24"].ToString() == I.ID).FirstOrDefault() ?? EmptyItem
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
      mItems = items.Select(x => extractItem(x)).OrderBy(x => x.Name).ToList();
      mItems.Add(EmptyItem);
      var tempRunes = runes.Select(x => extractRune(x)).OrderBy(x => x.Name).ToArray();
      mMarks = tempRunes.Where(x => x.Type == "red").ToList();
      mSeals = tempRunes.Where(x => x.Type == "yellow").ToList();
      mGlyphs = tempRunes.Where(x => x.Type == "blue").ToList();
      mQuints = tempRunes.Where(x => x.Type == "black").ToList();
      mMarks.Add(EmptyRune);
      mSeals.Add(EmptyRune);
      mGlyphs.Add(EmptyRune);
      mQuints.Add(EmptyRune);
      mChampions = champions.Select(x => extractChampion(x)).OrderBy(x => x.Name).ToList();
      mChampions.Add(EmptyChampion);
      mMasteries = masteries.Select(x => extractBranch(x)).OrderBy(x => x.Name).ToList();
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
        Champion = mChampions.Where(CH => B["champion"].ToString() == CH.ID).Select(CH => CH.Name).FirstOrDefault() ?? "Champion Not Found"
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
        Mark1 = mMarks.Where(I => RP["mark1"].ToString() == I.ID).FirstOrDefault() ?? EmptyRune,
        Mark2 = mMarks.Where(I => RP["mark2"].ToString() == I.ID).FirstOrDefault() ?? EmptyRune,
        Mark3 = mMarks.Where(I => RP["mark3"].ToString() == I.ID).FirstOrDefault() ?? EmptyRune,
        Mark4 = mMarks.Where(I => RP["mark4"].ToString() == I.ID).FirstOrDefault() ?? EmptyRune,
        Mark5 = mMarks.Where(I => RP["mark5"].ToString() == I.ID).FirstOrDefault() ?? EmptyRune,
        Mark6 = mMarks.Where(I => RP["mark6"].ToString() == I.ID).FirstOrDefault() ?? EmptyRune,
        Mark7 = mMarks.Where(I => RP["mark7"].ToString() == I.ID).FirstOrDefault() ?? EmptyRune,
        Mark8 = mMarks.Where(I => RP["mark8"].ToString() == I.ID).FirstOrDefault() ?? EmptyRune,
        Mark9 = mMarks.Where(I => RP["mark9"].ToString() == I.ID).FirstOrDefault() ?? EmptyRune,
        Seal1 = mSeals.Where(I => RP["seal1"].ToString() == I.ID).FirstOrDefault() ?? EmptyRune,
        Seal2 = mSeals.Where(I => RP["seal2"].ToString() == I.ID).FirstOrDefault() ?? EmptyRune,
        Seal3 = mSeals.Where(I => RP["seal3"].ToString() == I.ID).FirstOrDefault() ?? EmptyRune,
        Seal4 = mSeals.Where(I => RP["seal4"].ToString() == I.ID).FirstOrDefault() ?? EmptyRune,
        Seal5 = mSeals.Where(I => RP["seal5"].ToString() == I.ID).FirstOrDefault() ?? EmptyRune,
        Seal6 = mSeals.Where(I => RP["seal6"].ToString() == I.ID).FirstOrDefault() ?? EmptyRune,
        Seal7 = mSeals.Where(I => RP["seal7"].ToString() == I.ID).FirstOrDefault() ?? EmptyRune,
        Seal8 = mSeals.Where(I => RP["seal8"].ToString() == I.ID).FirstOrDefault() ?? EmptyRune,
        Seal9 = mSeals.Where(I => RP["seal9"].ToString() == I.ID).FirstOrDefault() ?? EmptyRune,
        Glyph1 = mGlyphs.Where(I => RP["glyph1"].ToString() == I.ID).FirstOrDefault() ?? EmptyRune,
        Glyph2 = mGlyphs.Where(I => RP["glyph2"].ToString() == I.ID).FirstOrDefault() ?? EmptyRune,
        Glyph3 = mGlyphs.Where(I => RP["glyph3"].ToString() == I.ID).FirstOrDefault() ?? EmptyRune,
        Glyph4 = mGlyphs.Where(I => RP["glyph4"].ToString() == I.ID).FirstOrDefault() ?? EmptyRune,
        Glyph5 = mGlyphs.Where(I => RP["glyph5"].ToString() == I.ID).FirstOrDefault() ?? EmptyRune,
        Glyph6 = mGlyphs.Where(I => RP["glyph6"].ToString() == I.ID).FirstOrDefault() ?? EmptyRune,
        Glyph7 = mGlyphs.Where(I => RP["glyph7"].ToString() == I.ID).FirstOrDefault() ?? EmptyRune,
        Glyph8 = mGlyphs.Where(I => RP["glyph8"].ToString() == I.ID).FirstOrDefault() ?? EmptyRune,
        Glyph9 = mGlyphs.Where(I => RP["glyph9"].ToString() == I.ID).FirstOrDefault() ?? EmptyRune,
        Quint1 = mQuints.Where(I => RP["quint1"].ToString() == I.ID).FirstOrDefault() ?? EmptyRune,
        Quint2 = mQuints.Where(I => RP["quint1"].ToString() == I.ID).FirstOrDefault() ?? EmptyRune,
        Quint3 = mQuints.Where(I => RP["quint1"].ToString() == I.ID).FirstOrDefault() ?? EmptyRune
      }).First();
    }

    public ItemSet getItemSetByName(string index) {
      return mItemSets.Where(IS => IS["name"].ToString() == index).Select(IS => new ItemSet {
        ItemSetName = IS["name"].ToString(),
        Item1 = mItems.Where(I => IS["item1"].ToString() == I.ID).FirstOrDefault() ?? EmptyItem,
        Item2 = mItems.Where(I => IS["item2"].ToString() == I.ID).FirstOrDefault() ?? EmptyItem,
        Item3 = mItems.Where(I => IS["item3"].ToString() == I.ID).FirstOrDefault() ?? EmptyItem,
        Item4 = mItems.Where(I => IS["item4"].ToString() == I.ID).FirstOrDefault() ?? EmptyItem,
        Item5 = mItems.Where(I => IS["item5"].ToString() == I.ID).FirstOrDefault() ?? EmptyItem,
        Item6 = mItems.Where(I => IS["item6"].ToString() == I.ID).FirstOrDefault() ?? EmptyItem,
        Item7 = mItems.Where(I => IS["item7"].ToString() == I.ID).FirstOrDefault() ?? EmptyItem,
        Item8 = mItems.Where(I => IS["item8"].ToString() == I.ID).FirstOrDefault() ?? EmptyItem,
        Item9 = mItems.Where(I => IS["item9"].ToString() == I.ID).FirstOrDefault() ?? EmptyItem,
        Item10 = mItems.Where(I => IS["item10"].ToString() == I.ID).FirstOrDefault() ?? EmptyItem,
        Item11 = mItems.Where(I => IS["item11"].ToString() == I.ID).FirstOrDefault() ?? EmptyItem,
        Item12 = mItems.Where(I => IS["item12"].ToString() == I.ID).FirstOrDefault() ?? EmptyItem,
        Item13 = mItems.Where(I => IS["item13"].ToString() == I.ID).FirstOrDefault() ?? EmptyItem,
        Item14 = mItems.Where(I => IS["item14"].ToString() == I.ID).FirstOrDefault() ?? EmptyItem,
        Item15 = mItems.Where(I => IS["item15"].ToString() == I.ID).FirstOrDefault() ?? EmptyItem,
        Item16 = mItems.Where(I => IS["item16"].ToString() == I.ID).FirstOrDefault() ?? EmptyItem,
        Item17 = mItems.Where(I => IS["item17"].ToString() == I.ID).FirstOrDefault() ?? EmptyItem,
        Item18 = mItems.Where(I => IS["item18"].ToString() == I.ID).FirstOrDefault() ?? EmptyItem,
        Item19 = mItems.Where(I => IS["item19"].ToString() == I.ID).FirstOrDefault() ?? EmptyItem,
        Item20 = mItems.Where(I => IS["item20"].ToString() == I.ID).FirstOrDefault() ?? EmptyItem,
        Item21 = mItems.Where(I => IS["item21"].ToString() == I.ID).FirstOrDefault() ?? EmptyItem,
        Item22 = mItems.Where(I => IS["item22"].ToString() == I.ID).FirstOrDefault() ?? EmptyItem,
        Item23 = mItems.Where(I => IS["item23"].ToString() == I.ID).FirstOrDefault() ?? EmptyItem,
        Item24 = mItems.Where(I => IS["item24"].ToString() == I.ID).FirstOrDefault() ?? EmptyItem
      }).First();
    }

    public void updateBuild(Build d) {
      var build = mBuilds.Where(x => x["name"].ToString() == d.BuildName).First();
      build["runePage"] = d.RunePage;
      build["masteryPage"] = d.MasteryPage;
      build["itemSet"] = d.ItemSet;
      build["startAbilities"] = d.StartAbilities;
      build["maxOrder"] = d.MaxOrder;
      build["champion"] = mChampions.Where(i => i.Name == d.Champion).Select(i => i.ID).First();
    }

    public void updateItemSet(ItemSet d) {
      var itemSet = mItemSets.Where(x => x["name"].ToString() == d.ItemSetName).First();
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
      var runePage = mRunePages.Where(x => x["name"].ToString() == d.RunePageName).First();
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
      var masteryPage = mMasteryPages.Where(x => x["name"].ToString() == d["name"]).First();
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
      build["champion"] = mChampions.Where(i => i.Name == d.Champion).Select(i => i.ID).First();
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
      mBuilds.Where(x => x["name"].ToString() == d.BuildName).First().Remove();
    }

    public void removeItemSet(ItemSet d) {
      mItemSets.Where(x => x["name"].ToString() == d.ItemSetName).First().Remove();
    }

    public void removeRunePage(RunePage d) {
      mRunePages.Where(x => x["name"].ToString() == d.RunePageName).First().Remove();
    }

    public void removeMasteryPage(MasteryPage d) {
      mMasteryPages.Where(x => x["name"].ToString() == d["name"]).First().Remove();
    }

    public void updateBuildName(Build d, string newName) {
      var build = mBuilds.Where(x => x["name"].ToString() == d.BuildName).First();
      build["name"] = newName;
      d.BuildName = newName;
    }

    public void updateItemSetName(ItemSet d, string newName) {
      var itemSet = mItemSets.Where(x => x["name"].ToString() == d.ItemSetName).First();
      itemSet["name"] = newName;
      d.ItemSetName = newName;
    }

    public void updateRunePageName(RunePage d, string newName) {
      var runePage = mRunePages.Where(x => x["name"].ToString() == d.RunePageName).First();
      runePage["name"] = newName;
      d.RunePageName = newName;
    }

    public void updateMasteryPageName(MasteryPage d, string newName) {
      var masteryPage = mMasteryPages.Where(x => x["name"].ToString() == d["name"]).First();
      masteryPage["name"] = newName;
      d["name"] = newName;
    }

    private Branch extractBranch(JToken b) {
      return new Branch() {
        Name = b["name"].ToString(),
        Tiers = b["tiers"].Select(x => extractTier(x)).ToList()
      };
    }

    private Tier extractTier(JToken t) {
      return new Tier() {
        Limit = int.Parse(t["limit"].ToString()),
        Masteries = t["masteries"].Select(x => extractMastery(x)).ToList()
      };
    }

    private Mastery extractMastery(JToken m) {
      MasteryPage.MasteryNames.Add(m["id"].ToString());
      return new Mastery() {
        ID = m["id"].ToString(),
        Name = m["name"].ToString(),
        Description = m["description"].ToString(),
        ImageURL = m["image"].ToString()
      };
    }

    private Rune extractRune(JToken r) {
      return new Rune() {
        Name = r["name"].ToString(),
        ID = r["id"].ToString(),
        Type = r["type"].ToString(),
        Description = r["description"].ToString(),
        ImageURL = r["image"].ToString()
      };
    }

    private Champion extractChampion(JToken ch) {
      return new Champion() {
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
      return new Spell() {
        Name = spell["name"].ToString(),
        Description = spell["description"].ToString(),
        Tooltip = spell["tooltip"].ToString(),
        Resource = spell["resource"].ToString(),
        MaxRank = int.Parse(spell["maxrank"].ToString()),
        Cooldown = spell["cooldown"].ToString(),
        Effect = spell["effect"].Select(x => x.ToString()).ToList(),
        Range = spell["range"].ToString(),
        Cost = spell["cost"].ToString(),
        Vars = spell["vars"] == null ? null : spell["vars"].Select(var => extractVar(var)).ToList(),
        ImageURL = spell["image"].ToString()
      };
    }

    private Var extractVar(JToken var) {
      return new Var() {
        Key = var["key"].ToString(),
        Type = var["link"].ToString(),
        Value = var["coeff"].Aggregate((i, j) => i.ToString() + "/" + j.ToString()).ToString()
      };
    }

    private Passive extractPassive(JToken passive) {
      return new Passive() {
        Name = passive["name"].ToString(),
        Description = passive["description"].ToString(),
        ImageURL = passive["image"].ToString()
      };
    }

    private Item extractItem(JToken item) {
      return new Item() {
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
