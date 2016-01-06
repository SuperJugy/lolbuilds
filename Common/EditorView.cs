﻿using System.Collections.Generic;

namespace com.jcandksolutions.lol {
  public interface EditorView : BuildView {
    bool ShouldPauseBinding { get; set; }
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
  }
}
