using System.Collections.Generic;
using Newtonsoft.Json;

namespace com.jcandksolutions.lol {
  public class Tier {
    private List<Mastery> mMasteries;
    [JsonProperty("limit")]
    public int Limit { get; set; }
    [JsonProperty("masteries")]
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
