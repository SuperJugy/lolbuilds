namespace com.jcandksolutions.lol {
  public class CommonProvider {
    private IOManager mIOManager;
    private BuildManager mBuildManager;

    public IOManager provideIOManager() {
      if (mIOManager == null) {
        mIOManager = new IOManager();
      }
      return mIOManager;
    }

    public APICaller provideAPICaller() {
      return new APICaller();
    }

    public DataTransformer provideDataTransformer() {
      return new DataTransformer();
    }

    public BuildManager provideBuildManager() {
      if (mBuildManager == null) {
        mBuildManager = new BuildManager();
      }
      return mBuildManager;
    }

    public DBUpdater provideDBUpdater() {
      return new DBUpdater();
    }
  }
}
