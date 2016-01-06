using System.Collections.Generic;

namespace com.jcandksolutions.lol {
  public interface BrowserView : BuildView {
    void bindChampionControls(List<Champion> championData);
    void bindBuildsControls(List<Build> buildsData);
    void bindMasteryPagesControls(MasteryPageList masteryPagesData);
    void bindRunePagesControls(List<RunePage> runePagesData);
    void bindItemSetsControls(List<ItemSet> itemSetsData);
  }
}
