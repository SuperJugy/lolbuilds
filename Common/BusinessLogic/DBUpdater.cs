using System.Configuration;

using com.jcandksolutions.lol.DependencyInjection;

namespace com.jcandksolutions.lol.BusinessLogic {
  public class DBUpdater {
    public void update() {
      APICaller caller = CommonInjector.provideAPICaller();
      caller.APIKey = ConfigurationManager.AppSettings["apikey"];
      caller.Server = ConfigurationManager.AppSettings["server"];
      caller.Locale = ConfigurationManager.AppSettings["locale"];
      DataTransformer transformer = CommonInjector.provideDataTransformer();
      transformer.Caller = caller;
      IOManager ioManager = CommonInjector.provideIOManager();
      ioManager.writeFile("./db.json", transformer.extractDB());
    }
  }
}
