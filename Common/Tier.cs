using System.Collections.Generic;

namespace com.jcandksolutions.lol {
  public class Tier {
    private List<Mastery> mMasteries;
    public int Limit { get; set; }
    public List<Mastery> Masteries {
      get {
        return mMasteries;
      }
      set {
        mMasteries = value;
        foreach (var m in mMasteries) {
          foreach (var mp in mMasteries) {
            if (mp != m) {
              m.addPartner(mp.ID);
            }
          }
        }
      }
    }
  }
}
