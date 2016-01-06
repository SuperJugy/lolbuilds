using System;

namespace com.jcandksolutions.lol {
  public class BrowserPresenter {
    private BrowserView mView;
    private string mBuildsPath;
    private BuildManager mBuildManager;

    public BrowserPresenter(BrowserView view) {
      mView = view;
      mBuildManager = CommonInjector.provideBuildManager();
    }

    public void onStart() {
      try {
        mView.bindChampionControls(mBuildManager.ChampionsData);
        mView.configureMasteryTrees(mBuildManager.MasteriesTree);
      } catch (Exception ex) {
        mView.showErrorMessage(ex.Message + "\n\r" + ex.StackTrace);
        mView.Close();
        return;
      }
    }

    public void onOpenFileClicked() {
      string newBuildsPath = mView.askForOpenFilePath();
      if (newBuildsPath == null) {
        return;
      }
      mBuildsPath = newBuildsPath;
      mBuildManager.loadBuild(mBuildsPath);
      bindLists();
    }

    private void bindLists() {
      mView.bindBuildsControls(mBuildManager.BuildsData);
      mView.bindMasteryPagesControls(mBuildManager.MasteryPagesData);
      mView.bindRunePagesControls(mBuildManager.RunePagesData);
      mView.bindItemSetsControls(mBuildManager.ItemSetsData);
    }
  }
}
