using System;
using System.Collections.Generic;
using System.Linq;
using com.jcandksolutions.lol.DependencyInjection;
using com.jcandksolutions.lol.Model;
using Newtonsoft.Json;

namespace com.jcandksolutions.lol.BusinessLogic {
  public class BuildManager {
    private readonly List<Item> mItems;
    private readonly List<Rune> mMarks;
    private readonly List<Rune> mSeals;
    private readonly List<Rune> mGlyphs;
    private readonly List<Rune> mQuints;
    private Rune mEmptyRune;
    private Item mEmptyItem;
    private Champion mEmptyChampion;
    private List<Build> mBuilds;
    private List<ItemSet> mItemSets;
    private MasteryPageList mMasteryPages;
    private List<RunePage> mRunePages;
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
    public Champion EmptyChampion {
      get {
        return mEmptyChampion ?? (mEmptyChampion = new Champion {
          ID = "-1",
          Name = ""
        });
      }
    }
    public object[] MarksList {
      get {
        return mMarks.ToArray<object>();
      }
    }
    public object[] SealsList {
      get {
        return mSeals.ToArray<object>();
      }
    }
    public object[] GlyphsList {
      get {
        return mGlyphs.ToArray<object>();
      }
    }
    public object[] QuintsList {
      get {
        return mQuints.ToArray<object>();
      }
    }
    public object[] ItemsList {
      get {
        return mItems.ToArray<object>();
      }
    }
    public object[] ChampionsList {
      get {
        return ChampionsData.Select(x => x.Name).ToArray<object>();
      }
    }
    public object[] BuildsList {
      get {
        return mBuilds.OrderBy(x => x.BuildName).Select(x => x.BuildName).ToArray<object>();
      }
    }
    public object[] ItemSetsList {
      get {
        return mItemSets.OrderBy(x => x.ItemSetName).Select(x => x.ItemSetName).ToArray<object>();
      }
    }
    public object[] RunePagesList {
      get {
        return mRunePages.OrderBy(x => x.RunePageName).Select(x => x.RunePageName).ToArray<object>();
      }
    }
    public object[] MasteryPagesList {
      get {
        return mMasteryPages.OrderBy(x => x["name"].ToString()).Select(x => x["name"].ToString()).ToArray<object>();
      }
    }
    public List<Branch> MasteriesTree { get; private set; }
    public List<Champion> ChampionsData { get; private set; }
    public List<Build> BuildsData {
      get {
        return mBuilds;
      }
    }
    public MasteryPageList MasteryPagesData {
      get {
        return mMasteryPages;
      }
    }
    public List<RunePage> RunePagesData {
      get {
        return mRunePages;
      }
    }
    public List<ItemSet> ItemSetsData {
      get {
        return mItemSets;
      }
    }

    public BuildManager() {
      DBData staticData = loadDBData();
      List<Branch> masteries = staticData.Masteries;
      List<Rune> runes = staticData.Runes;
      List<Item> items = staticData.Items;
      List<Champion> champions = staticData.Champions;
      if (items == null || runes == null || masteries == null || champions == null) {
        throw new FormatException("The database file has wrong format or is corrupted");
      }
      mItems = items.OrderBy(x => x.Name).ToList();
      mItems.Add(EmptyItem);
      IOrderedEnumerable<Rune> tempRunes = runes.OrderBy(x => x.Name);
      mMarks = tempRunes.Where(x => x.Type == "red").ToList();
      mSeals = tempRunes.Where(x => x.Type == "yellow").ToList();
      mGlyphs = tempRunes.Where(x => x.Type == "blue").ToList();
      mQuints = tempRunes.Where(x => x.Type == "black").ToList();
      mMarks.Add(EmptyRune);
      mSeals.Add(EmptyRune);
      mGlyphs.Add(EmptyRune);
      mQuints.Add(EmptyRune);
      ChampionsData = champions.OrderBy(x => x.Name).ToList();
      ChampionsData.Add(EmptyChampion);
      MasteriesTree = masteries;
      MasteryPage.loadMasteryNames(MasteriesTree);
    }

    public void loadBuild(string path) {
      BuildData buildsData = loadBuildData(path);
      mItemSets = buildsData.ItemSets;
      mRunePages = buildsData.Runes;
      mMasteryPages = buildsData.Masteries;
      mBuilds = buildsData.Builds;
      if (mItemSets == null || mRunePages == null || mMasteryPages == null || mBuilds == null) {
        throw new FormatException("The builds file has wrong format or is corrupted");
      }
    }

    public void save(string path) {
      IOManager ioManager = CommonInjector.provideIOManager();
      var root = new BuildData {
        Builds = mBuilds,
        Masteries = mMasteryPages,
        Runes = mRunePages,
        ItemSets = mItemSets
      };
      ioManager.writeFile(path, JsonConvert.SerializeObject(root, Formatting.Indented));
    }

    public void clear() {
      mBuilds = new List<Build>();
      mMasteryPages = new MasteryPageList();
      mRunePages = new List<RunePage>();
      mItemSets = new List<ItemSet>();
    }

    public void addBuild(Build d) {
      mBuilds.Add(d);
    }

    public void addItemSet(ItemSet d) {
      mItemSets.Add(d);
    }

    public void addRunePage(RunePage d) {
      mRunePages.Add(d);
    }

    public void addMasteryPage(MasteryPage d) {
      mMasteryPages.Add(d);
    }

    public void removeBuild(Build d) {
      mBuilds.Remove(mBuilds.First(x => x.BuildName == d.BuildName));
    }

    public void removeItemSet(ItemSet d) {
      mItemSets.Remove(mItemSets.First(x => x.ItemSetName == d.ItemSetName));
    }

    public void removeRunePage(RunePage d) {
      mRunePages.Remove(mRunePages.First(x => x.RunePageName == d.RunePageName));
    }

    public void removeMasteryPage(MasteryPage d) {
      mMasteryPages.Remove(mMasteryPages.First(x => x["name"].ToString() == d["name"]));
    }

    public void updateBuildName(Build d, string newName) {
      d.BuildName = newName;
    }

    public void updateItemSetName(ItemSet d, string newName) {
      string name = d.ItemSetName;
      d.ItemSetName = newName;
      foreach (Build build in mBuilds.Where(x => x.ItemSet == name)) {
        build.ItemSet = newName;
      }
    }

    public void updateRunePageName(RunePage d, string newName) {
      string name = d.RunePageName;
      d.RunePageName = newName;
      foreach (Build build in mBuilds.Where(x => x.RunePage == name)) {
        build.RunePage = newName;
      }
    }

    public void updateMasteryPageName(MasteryPage d, string newName) {
      string name = d["name"];
      d["name"] = newName;
      foreach (Build build in mBuilds.Where(x => x.MasteryPage == name)) {
        build.MasteryPage = newName;
      }
    }

    public string GetChampionNameById(string id) {
      return ChampionsData.Where(CH => id == CH.ID).Select(CH => CH.Name).FirstOrDefault() ?? "Champion Not Found";
    }

    public string GetChampionIDByName(string name) {
      return ChampionsData.Where(CH => name == CH.Name).Select(CH => CH.ID).FirstOrDefault() ?? "Champion Not Found";
    }

    public Rune getMarkByID(string id) {
      return mMarks.FirstOrDefault(R => id == R.ID) ?? EmptyRune;
    }

    public Rune getSealByID(string id) {
      return mSeals.FirstOrDefault(R => id == R.ID) ?? EmptyRune;
    }

    public Rune getGlyphByID(string id) {
      return mGlyphs.FirstOrDefault(R => id == R.ID) ?? EmptyRune;
    }

    public Rune getQuintByID(string id) {
      return mQuints.FirstOrDefault(R => id == R.ID) ?? EmptyRune;
    }

    public Item getItemByID(string id) {
      return mItems.FirstOrDefault(I => id == I.ID) ?? EmptyItem;
    }
    
    public Build getBuildByName(string index) {
      return mBuilds.First(B => B.BuildName == index);
    }

    public MasteryPage getMasteryPageByName(string index) {
      return mMasteryPages.First(MP => MP["name"].ToString() == index);
    }

    public RunePage getRunePageByName(string index) {
      return mRunePages.First(RP => RP.RunePageName == index);
    }

    public ItemSet getItemSetByName(string index) {
      return mItemSets.First(IS => IS.ItemSetName == index);
    }

    private DBData loadDBData() {
      IOManager ioManager = CommonInjector.provideIOManager();
      return JsonConvert.DeserializeObject<DBData>(ioManager.readFile("./db.json"));
    }

    private BuildData loadBuildData(string path) {
      IOManager ioManager = CommonInjector.provideIOManager();
      return JsonConvert.DeserializeObject<BuildData>(ioManager.readFile(path));
    }
  }
}
