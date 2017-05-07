using com.jcandksolutions.lol.Model;

namespace com.jcandksolutions.lol.UI {
  public interface EditorView : BuildView {
    bool shouldPauseBinding { set; }

    void updateBuildsDropdown(object[] buildsList);

    void updateMasteryPagesDropdown(object[] masteryPagesList);

    void updateRunePagesDropdown(object[] runePagesList);

    void updateItemSetsDropdown(object[] itemSetsList);

    void configureRunePagesDropdowns(object[] marksList, object[] sealsList, object[] glyphsList, object[] quintsList);

    void configureBuildsDropdowns(object[] championsList, object[] summonersList);

    void configureItemSetsDropdowns(object[] itemsList);

    bool confirmNotLoseChanges(string message, string title);

    void setSaveEnabled(bool enabled);

    string askForSaveFilePath();

    void populateBuild(Build build);

    void populateMasteryPage(MasteryPage masteryPage);

    void populateRunePage(RunePage runePage);

    void populateItemSet(ItemSet itemSet);

    string askForName();

    void addBuild(Build build);

    void addMasteryPage(MasteryPage masteryPage);

    void addRunePage(RunePage runePage);

    void addItemSet(ItemSet runePage);

    void updateBuildName(string name);

    void updateMasteryPageName(string name);

    void updateRunePageName(string name);

    void updateItemSetName(string name);
  }
}
