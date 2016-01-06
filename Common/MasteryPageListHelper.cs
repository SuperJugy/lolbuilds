using System.Collections.Generic;

namespace com.jcandksolutions.lol {
  public static class MasteryPageListHelper {
    public static MasteryPageList ToMasteryPageList(this IEnumerable<MasteryPage> source) {
      var list = new MasteryPageList();
      foreach (var m in source) {
        list.Add(m);
      }
      return list;
    }
  }
}
