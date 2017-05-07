using com.jcandksolutions.lol.BusinessLogic;

namespace com.jcandksolutions.lol.DependencyInjection {
  public static class CommonInjector {
    private static CommonProvider mProvider;

    public static void setProvider(CommonProvider provider) {
      mProvider = provider;
    }

    public static IOManager provideIOManager() {
      return mProvider.provideIOManager();
    }

    public static APICaller provideAPICaller() {
      return mProvider.provideAPICaller();
    }

    public static DataTransformer provideDataTransformer() {
      return mProvider.provideDataTransformer();
    }

    public static BuildManager provideBuildManager() {
      return mProvider.provideBuildManager();
    }

    public static DBUpdater provideDBUpdater() {
      return mProvider.provideDBUpdater();
    }
  }
}
