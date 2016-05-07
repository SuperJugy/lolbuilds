namespace com.jcandksolutions.lol {
  public interface EditorView : BuildView {
    bool shouldPauseBinding { get; set; }
    void updateBuildsDropdown(string[] buildsList);
    void updateMasteryPagesDropdown(string[] masteryPagesList);
    void updateRunePagesDropdown(string[] runePagesList);
    void updateItemSetsDropdown(string[] itemSetsList);
    void configureRunePagesDropdowns(Rune[] marksList, Rune[] sealsList, Rune[] glyphsList, Rune[] quintsList);
    void configureBuildsDropdowns(string[] championsList);
    void configureItemSetsDropdowns(Item[] itemsList);
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
