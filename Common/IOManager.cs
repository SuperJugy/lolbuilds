using System.IO;

namespace com.jcandksolutions.lol {
  public class IOManager {
    public string readFile(string path) {
      return File.ReadAllText(path);
    }

    public void writeFile(string file, string text) {
      File.WriteAllText(file, text);
    }
  }
}
