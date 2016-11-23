using System.Collections.Generic;
using System.ComponentModel;

namespace com.jcandksolutions.lol {
  public class MasteryPage : INotifyPropertyChanged {
    private static readonly HashSet<string> mMasteryNames = new HashSet<string> {
      "name"
    };
    private readonly Dictionary<string, string> mMasteries = new Dictionary<string, string>();
    public static HashSet<string> MasteryNames {
      get {
        return mMasteryNames;
      }
    }
    public Dictionary<string, string> Properties {
      get {
        return mMasteries;
      }
    }
    public string this[string fieldName] {
      get {
        string value;
        mMasteries.TryGetValue(fieldName, out value);
        return value;
      }
      set {
        mMasteries[fieldName] = value;
        OnPropertyChanged(new PropertyChangedEventArgs(fieldName));
      }
    }

    public MasteryPage() {
      foreach (string name in mMasteryNames) {
        if (name == "name") {
          mMasteries[name] = "";
        } else {
          mMasteries[name] = "0";
        }
      }
    }

    public MasteryPage(MasteryPage masteryPage) {
      foreach (string name in mMasteryNames) {
        if (name == "name") {
          mMasteries[name] = "";
        } else {
          mMasteries[name] = masteryPage[name];
        }
      }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    private void OnPropertyChanged(PropertyChangedEventArgs e) {
      if (null != PropertyChanged) {
        PropertyChanged(this, e);
      }
    }

    public static void loadMasteryNames(List<Branch> masteriesTree) {
      foreach (Branch branch in masteriesTree) {
        foreach (Tier tier in branch.Tiers) {
          foreach (Mastery mastery in tier.Masteries) {
            mMasteryNames.Add(mastery.ID);
          }
        }
      }
    }
  }
}
