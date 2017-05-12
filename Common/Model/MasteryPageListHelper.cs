using System.Collections.Generic;

namespace com.jcandksolutions.lol.Model {
  public static class MasteryPageListHelper {
    public static MasteryPageList ToMasteryPageList(this IEnumerable<MasteryPage> source) {
      var list = new MasteryPageList();
      foreach (MasteryPage m in source) {
        list.Add(m);
      }

      return list;
    }
  }
}
