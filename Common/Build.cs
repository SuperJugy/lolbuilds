namespace com.jcandksolutions.lol {
  public class Build {
    public string BuildName { get; set; }
    public string RunePage { get; set; }
    public string MasteryPage { get; set; }
    public string ItemSet { get; set; }
    public string StartAbilities { get; set; }
    public string MaxOrder { get; set; }
    public string Champion { get; set; }

    public Build() {
      BuildName = "";
      RunePage = "";
      MasteryPage = "";
      ItemSet = "";
      StartAbilities = "";
      MaxOrder = "";
      Champion = "";
    }

    public Build(Build build) {
      BuildName = "";
      RunePage = build.RunePage;
      MasteryPage = build.MasteryPage;
      ItemSet = build.ItemSet;
      StartAbilities = build.StartAbilities;
      MaxOrder = build.MaxOrder;
      Champion = build.Champion;
    }
  }
}
