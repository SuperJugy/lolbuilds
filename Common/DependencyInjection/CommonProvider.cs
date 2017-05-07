using com.jcandksolutions.lol.BusinessLogic;

namespace com.jcandksolutions.lol.DependencyInjection {
  public class CommonProvider {
    private BuildManager mBuildManager;
    private IOManager mIOManager;

    public IOManager provideIOManager() {
      return mIOManager ?? (mIOManager = new IOManager());
    }

    public APICaller provideAPICaller() {
      return new APICaller();
    }

    public DataTransformer provideDataTransformer() {
      return new DataTransformer();
    }

    public BuildManager provideBuildManager() {
      return mBuildManager ?? (mBuildManager = new BuildManager());
    }

    public DBUpdater provideDBUpdater() {
      return new DBUpdater();
    }
  }
}
