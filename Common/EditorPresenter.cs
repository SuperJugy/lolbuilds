using System;

namespace com.jcandksolutions.lol {
  public class EditorPresenter {
    private bool mShouldSaveBeforeExit;
    private EditorView mView;
    private string mBuildsPath;
    private const string CONFIRM_LOSE_CHANGES_MESSAGE = "You have unsaved changed. Do you really want to lose your changes?";
    private const string CONFIRM_LOSE_CHANGES_TITLE = "Confirm Lose Changes";
    private BuildManager mBuildManager;

    public enum DataChanged {
      BUILDS,
      MASTERY_PAGES,
      RUNE_PAGES,
      ITEM_SETS,
      NotRecognized
    }

    public EditorPresenter(EditorView view) {
      mView = view;
      mBuildManager = CommonInjector.provideBuildManager();
    }

    public void start() {
      mView.shouldPauseBinding = true;
      mView.configureBuildsDropdowns(mBuildManager.ChampionsList);
      mView.configureMasteryTrees(mBuildManager.MasteriesTree);
      mView.configureRunePagesDropdowns(mBuildManager.MarksList, mBuildManager.SealsList, mBuildManager.GlyphsList, mBuildManager.QuintsList);
      mView.configureItemSetsDropdowns(mBuildManager.ItemsList);
      mView.shouldPauseBinding = false;
    }

    public void onNewFileClicked() {
      if (!mShouldSaveBeforeExit || !mView.confirmNotLoseChanges(CONFIRM_LOSE_CHANGES_MESSAGE, CONFIRM_LOSE_CHANGES_TITLE)) {
        mBuildsPath = null;
        mShouldSaveBeforeExit = false;
        mView.setSaveEnabled(false);
        bindEmptyLists();
      }
    }

    public void onOpenFileClicked() {
      if (!mShouldSaveBeforeExit || !mView.confirmNotLoseChanges(CONFIRM_LOSE_CHANGES_MESSAGE, CONFIRM_LOSE_CHANGES_TITLE)) {
        string newBuildsPath = mView.askForOpenFilePath();
        if (newBuildsPath == null) {
          return;
        }
        mBuildsPath = newBuildsPath;
        mShouldSaveBeforeExit = false;
        mView.setSaveEnabled(false);
        mBuildManager.loadBuild(mBuildsPath);
        bindLists();
      }
    }

    public void onSaveFileClicked(bool isSaveAs) {
      if (mBuildsPath == null || isSaveAs) {
        string newBuildsPath = mView.askForSaveFilePath();
        if (newBuildsPath == null) {
          return;
        }
        mBuildsPath = newBuildsPath;
      }
      mShouldSaveBeforeExit = false;
      mView.setSaveEnabled(false);
      mBuildManager.save(mBuildsPath);
    }

    private void onDataChanged() {
      mView.setSaveEnabled(true);
      mShouldSaveBeforeExit = true;
    }

    public void onRunePageChanged(RunePage value) {
      onDataChanged();
      mBuildManager.updateRunePage(value);
    }

    public void onBuildChanged(Build value) {
      onDataChanged();
      mBuildManager.updateBuild(value);
    }

    public void onMasteryPageChanged(MasteryPage value) {
      onDataChanged();
      mBuildManager.updateMasteryPage(value);
    }

    public void onItemSetChanged(ItemSet value) {
      onDataChanged();
      mBuildManager.updateItemSet(value);
    }

    public bool shouldCancelFormClosing() {
      return mShouldSaveBeforeExit && mView.confirmNotLoseChanges(CONFIRM_LOSE_CHANGES_MESSAGE, CONFIRM_LOSE_CHANGES_TITLE);
    }

    public void onSelectedItemChanged(DataChanged data, string name) {
      mView.ShouldPauseBinding = true;
      switch (data) {
        case DataChanged.BUILDS:
          mView.populateBuild(mBuildManager.getBuildByName(name));
          break;
        case DataChanged.MASTERY_PAGES:
          mView.populateMasteryPage(mBuildManager.getMasteryPageByName(name));
          break;
        case DataChanged.RUNE_PAGES:
          mView.populateRunePage(mBuildManager.getRunePageByName(name));
          break;
        case DataChanged.ITEM_SETS:
          mView.populateItemSet(mBuildManager.getItemSetByName(name));
          break;
        case DataChanged.NotRecognized:
          throw new InvalidOperationException("Not recognized data changed");
      }
      mView.ShouldPauseBinding = false;
    }

    public void onSelectedItemChangedName(object data, string newName) {
      mView.setSaveEnabled(true);
      mShouldSaveBeforeExit = true;
      if (data is Build) {
        mBuildManager.updateBuildName((Build)data, newName);
      } else if (data is MasteryPage) {
        mBuildManager.updateMasteryPageName((MasteryPage)data, newName);
      } else if (data is RunePage) {
        mBuildManager.updateRunePageName((RunePage)data, newName);
      } else if (data is ItemSet) {
        mBuildManager.updateItemSetName((ItemSet)data, newName);
      } else {
        throw new InvalidOperationException("Not recognized data changed");
      }
    }

    public void onDeleteItem(object item) {
      mView.setSaveEnabled(true);
      mShouldSaveBeforeExit = true;
      if (item is Build) {
        mBuildManager.removeBuild((Build)item);
      } else if (item is MasteryPage) {
        mBuildManager.removeMasteryPage((MasteryPage)item);
      } else if (item is RunePage) {
        mBuildManager.removeRunePage((RunePage)item);
      } else if (item is ItemSet) {
        mBuildManager.removeItemSet((ItemSet)item);
      } else {
        throw new InvalidOperationException("Not recognized data changed");
      }
    }

    public void onAddItem(object newItem) {
      mView.setSaveEnabled(true);
      mShouldSaveBeforeExit = true;
      if (newItem is Build) {
        mBuildManager.addBuild((Build)newItem);
      } else if (newItem is MasteryPage) {
        mBuildManager.addMasteryPage((MasteryPage)newItem);
      } else if (newItem is RunePage) {
        mBuildManager.addRunePage((RunePage)newItem);
      } else if (newItem is ItemSet) {
        mBuildManager.addItemSet((ItemSet)newItem);
      } else {
        throw new InvalidOperationException("Not recognized data changed");
      }
    }

    //public void finalItemChanged() {
    //  Build build = mView.getCurrentBuild();
    //  JObject champion = (JObject)mChampions.Where(c => c["id"].ToString() == build.Champion).First();
    //  List<string> finalItemsNames = mView.getCurrentFinalItems();
    //  List<JObject> finalItems = getItemsById(finalItemsNames);
    //  var items = extractStatInfoFromItems(finalItems);
    //  var stats = new List<dynamic>();
    //  var stat = new {
    //    Name = "Armor",
    //    Base = int.Parse(champion["stats"]["armor"].ToString()),
    //    Growth = int.Parse(champion["stats"]["armorperlevel"].ToString()),
    //    Level18 = (int.Parse(champion["stats"]["armorperlevel"].ToString()) * 18) + int.Parse(champion["stats"]["armor"].ToString()),
    //    Items = items.Armor,
    //    //Runes = runes.Armor,
    //    //Runes18 = runes.Armor18,
    //    //Masteries = masteries.Armor,
    //    //Masteries18 = masteries.Armor18,
    //    Total = (int.Parse(champion["stats"]["armorperlevel"].ToString()) * 18) + int.Parse(champion["stats"]["armor"].ToString()) + items.Armor /*+ runes.Armor + masteries.Armor*/
    //  };
    //  stats.Add(stat);
    //}

    private void bindEmptyLists() {
      mBuildManager.clear();
      bindLists();
    }

    private void bindLists() {
      mView.updateMasteryPagesDropdown(mBuildManager.MasteryPagesList);
      mView.updateRunePagesDropdown(mBuildManager.RunePagesList);
      mView.updateItemSetsDropdown(mBuildManager.ItemSetsList);
      mView.updateBuildsDropdown(mBuildManager.BuildsList);
    }

    //private string[] getItemsFromItemSet(JObject itemSet) {
    //  return (from items in mItems
    //          where itemSet.Properties().Select(x => x.Value.ToString()).ToList().Contains(items["id"].ToString())
    //          orderby items["name"].ToString() ascending
    //          select (string)items["name"]).ToArray();
    //}

    //private List<JObject> getItemsById(List<string> finalItemsNames) {
    //  return mItems.Where(x => finalItemsNames.Contains(x["name"].ToString())).Select(x => (JObject)x).ToList();
    //}

    //private dynamic extractStatInfoFromItems(List<JObject> finalItems) {
    //  var armor = finalItems.Where(x => x["stats"]["FlatArmorMod"] != null).Sum(x => int.Parse(x["stats"]["FlatArmorMod"].ToString()));
    //  var abilityPower = finalItems.Where(x => x["stats"]["FlatMagicDamageMod"] != null).Sum(x => int.Parse(x["stats"]["FlatMagicDamageMod"].ToString()));
    //  var attackDamage = finalItems.Where(x => x["stats"]["FlatPhysicalDamageMod"] != null).Sum(x => int.Parse(x["stats"]["FlatPhysicalDamageMod"].ToString()));
    //  var attackSpeed = finalItems.Where(x => x["stats"]["PercentAttackSpeedMod"] != null).Sum(x => int.Parse(x["stats"]["PercentAttackSpeedMod"].ToString()));
    //  var crit = finalItems.Where(x => x["stats"]["FlatCritChanceMod"] != null).Sum(x => int.Parse(x["stats"]["FlatCritChanceMod"].ToString()));
    //  var hp = finalItems.Where(x => x["stats"]["FlatHPPoolMod"] != null).Sum(x => int.Parse(x["stats"]["FlatHPPoolMod"].ToString()));
    //  var hpRegen = finalItems.Where(x => x["stats"]["FlatHPRegenMod"] != null).Sum(x => int.Parse(x["stats"]["FlatHPRegenMod"].ToString()));
    //  var mana = finalItems.Where(x => x["stats"]["FlatMPPoolMod"] != null).Sum(x => int.Parse(x["stats"]["FlatMPPoolMod"].ToString()));
    //  var manaRegen = finalItems.Where(x => x["stats"]["FlatMPRegenMod"] != null).Sum(x => int.Parse(x["stats"]["FlatMPRegenMod"].ToString()));
    //  var magicResist = finalItems.Where(x => x["stats"]["FlatSpellBlockMod"] != null).Sum(x => int.Parse(x["stats"]["FlatSpellBlockMod"].ToString()));
    //  var moveSpeed = finalItems.Where(x => x["stats"]["FlatMovementSpeedMod"] != null).Sum(x => int.Parse(x["stats"]["FlatMovementSpeedMod"].ToString()));
    //  var percentMoveSpeed = finalItems.Where(x => x["stats"]["PercentMovementSpeedMod"] != null).Sum(x => int.Parse(x["stats"]["PercentMovementSpeedMod"].ToString()));
    //  return new {
    //    Armor = armor,
    //    AbilityPower = abilityPower,
    //    AttackDamage = attackDamage,
    //    AttackSpeed = attackSpeed,
    //    Crit = crit,
    //    HP = hp,
    //    HPRegen = hpRegen,
    //    Mana = mana,
    //    ManaRegen = manaRegen,
    //    MagicResist = magicResist,
    //    AttackRange = 0,
    //    MoveSpeed = moveSpeed,
    //    PercentMoveSpeed = percentMoveSpeed
    //  };
    //}
  }
}
