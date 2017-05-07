using System.Collections.Generic;
using com.jcandksolutions.lol.Model;

namespace com.jcandksolutions.lol.UI {
  public interface BrowserView : BuildView {
    void bindChampionControls(List<Champion> championData);
    void bindBuildsControls(List<Build> buildsData);
    void bindMasteryPagesControls(MasteryPageList masteryPagesData);
    void bindRunePagesControls(List<RunePage> runePagesData);
    void bindItemSetsControls(List<ItemSet> itemSetsData);
  }
}
