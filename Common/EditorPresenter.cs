namespace com.jcandksolutions.lol {
  public class EditorPresenter {
    private const string CONFIRM_LOSE_CHANGES_MESSAGE = "You have unsaved changed. Do you really want to lose your changes?";
    private const string CONFIRM_LOSE_CHANGES_TITLE = "Confirm Lose Changes";
    private readonly BuildManager mBuildManager;
    private readonly EditorView mView;
    private string mBuildsPath;
    private bool mShouldSaveBeforeExit;

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
        onDataSaved();
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
        onDataSaved();
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
      onDataSaved();
      mBuildManager.save(mBuildsPath);
    }

    private void onDataChanged() {
      mView.setSaveEnabled(true);
      mShouldSaveBeforeExit = true;
    }

    private void onDataSaved() {
      mView.setSaveEnabled(false);
      mShouldSaveBeforeExit = false;
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

    public void onSelectedBuildChanged(string name) {
      mView.shouldPauseBinding = true;
      mView.populateBuild(mBuildManager.getBuildByName(name));
      mView.shouldPauseBinding = false;
    }

    public void onSelectedMasteryPageChanged(string name) {
      mView.shouldPauseBinding = true;
      mView.populateMasteryPage(mBuildManager.getMasteryPageByName(name));
      mView.shouldPauseBinding = false;
    }

    public void onSelectedRunePageChanged(string name) {
      mView.shouldPauseBinding = true;
      mView.populateRunePage(mBuildManager.getRunePageByName(name));
      mView.shouldPauseBinding = false;
    }

    public void onSelectedItemSetChanged(string name) {
      mView.shouldPauseBinding = true;
      mView.populateItemSet(mBuildManager.getItemSetByName(name));
      mView.shouldPauseBinding = false;
    }

    public void onRenameBuild(Build data) {
      var name = mView.askForName();
      if (name == null) {
        return;
      }
      onDataChanged();
      mView.shouldPauseBinding = true;
      mView.updateBuildName(name);
      mView.shouldPauseBinding = false;
      mBuildManager.updateBuildName(data, name);
    }

    public void onRenameMasteryPage(MasteryPage data) {
      var name = mView.askForName();
      if (name == null) {
        return;
      }
      onDataChanged();
      mView.shouldPauseBinding = true;
      mView.updateMasteryPageName(name);
      mView.shouldPauseBinding = false;
      mBuildManager.updateMasteryPageName(data, name);
    }

    public void onRenameRunePage(RunePage data) {
      var name = mView.askForName();
      if (name == null) {
        return;
      }
      onDataChanged();
      mView.shouldPauseBinding = true;
      mView.updateRunePageName(name);
      mView.shouldPauseBinding = false;
      mBuildManager.updateRunePageName(data, name);
    }

    public void onRenameItemSet(ItemSet data) {
      var name = mView.askForName();
      if (name == null) {
        return;
      }
      onDataChanged();
      mView.shouldPauseBinding = true;
      mView.updateItemSetName(name);
      mView.shouldPauseBinding = false;
      mBuildManager.updateItemSetName(data, name);
    }

    public void onDeleteBuild(Build item) {
      onDataChanged();
      mBuildManager.removeBuild(item);
    }

    public void onDeleteMasteryPage(MasteryPage item) {
      onDataChanged();
      mBuildManager.removeMasteryPage(item);
    }

    public void onDeleteRunePage(RunePage item) {
      onDataChanged();
      mBuildManager.removeRunePage(item);
    }

    public void onDeleteItemSet(ItemSet item) {
      onDataChanged();
      mBuildManager.removeItemSet(item);
    }

    public void onAddBuild() {
      var name = mView.askForName();
      if (name == null) {
        return;
      }
      onDataChanged();
      var build = new Build {
        BuildName = name
      };
      mBuildManager.addBuild(build);
      mView.addBuild(build);
    }

    public void onAddMasteryPage() {
      var name = mView.askForName();
      if (name == null) {
        return;
      }
      onDataChanged();
      var masteryPage = new MasteryPage();
      masteryPage["name"] = name;
      mBuildManager.addMasteryPage(masteryPage);
      mView.addMasteryPage(masteryPage);
    }

    public void onAddRunePage() {
      var name = mView.askForName();
      if (name == null) {
        return;
      }
      onDataChanged();
      var runePage = new RunePage {
        RunePageName = name
      };
      mBuildManager.addRunePage(runePage);
      mView.addRunePage(runePage);
    }

    public void onAddItemSet() {
      var name = mView.askForName();
      if (name == null) {
        return;
      }
      onDataChanged();
      var itemSet = new ItemSet {
        ItemSetName = name
      };
      mBuildManager.addItemSet(itemSet);
      mView.addItemSet(itemSet);
    }

    public void onCopyBuild(Build oldBuild) {
      var name = mView.askForName();
      if (name == null) {
        return;
      }
      onDataChanged();
      var build = new Build(oldBuild) {
        BuildName = name
      };
      mBuildManager.addBuild(build);
      mView.addBuild(build);
    }

    public void onCopyMasteryPage(MasteryPage oldMasteryPage) {
      var name = mView.askForName();
      if (name == null) {
        return;
      }
      onDataChanged();
      var masteryPage = new MasteryPage(oldMasteryPage);
      masteryPage["name"] = name;
      mBuildManager.addMasteryPage(masteryPage);
      mView.addMasteryPage(masteryPage);
    }

    public void onCopyRunePage(RunePage oldRunepage) {
      var name = mView.askForName();
      if (name == null) {
        return;
      }
      onDataChanged();
      var runePage = new RunePage(oldRunepage) {
        RunePageName = name
      };
      mBuildManager.addRunePage(runePage);
      mView.addRunePage(runePage);
    }

    public void onCopyItemSet(ItemSet oldItemset) {
      var name = mView.askForName();
      if (name == null) {
        return;
      }
      onDataChanged();
      var itemSet = new ItemSet(oldItemset) {
        ItemSetName = name
      };
      mBuildManager.addItemSet(itemSet);
      mView.addItemSet(itemSet);
    }

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
  }
}
