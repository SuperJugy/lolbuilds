using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;

namespace com.jcandksolutions.lol {
  public class APICaller {
    private string mDownloadURL;
    private string mQueryURL;
    private const string MASTERY_TYPE = "img/mastery/";
    private const string RUNE_TYPE = "img/rune/";
    private const string ITEM_TYPE = "img/item/";
    private const string PASSIVE_TYPE = "img/passive/";
    private const string CHAMPION_TYPE = "img/champion/";
    private const string SPELL_TYPE = "img/spell/";
    public string APIKey { get; set; }
    public string Server { get; set; }
    public string Locale { get; set; }

    public JObject queryItems() {
      return callAPI("item?itemListData=all&");
    }

    public JObject queryChampions() {
      return callAPI("champion?dataById=true&champData=all&");
    }

    public JObject queryRunes() {
      return callAPI("rune?runeListData=all&");
    }

    public JObject queryMasteries() {
      return callAPI("mastery?masteryListData=all&");
    }

    public void downloadMasteryImage(string image) {
      downloadImage(MASTERY_TYPE, image);
    }

    public void downloadRuneImage(string image) {
      downloadImage(RUNE_TYPE, image);
    }

    public void downloadItemImage(string image) {
      downloadImage(ITEM_TYPE, image);
    }

    public void downloadChampionImage(string image) {
      downloadImage(CHAMPION_TYPE, image);
    }

    public void downloadSpellImage(string image) {
      downloadImage(SPELL_TYPE, image);
    }

    public void downloadPassiveImage(string image) {
      downloadImage(PASSIVE_TYPE, image);
    }

    private JObject callAPI(string query) {
      using (HttpClient client = new HttpClient()) {
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        var response = client.GetAsync(string.Format(QueryURL, query)).Result;
        if (!response.IsSuccessStatusCode) {
          throw new InvalidOperationException("Error calling Riot API servers. Status Code: " + response.StatusCode);
        }
        return JObject.Parse(response.Content.ReadAsStringAsync().Result);
      }
    }

    private void downloadImage(string type, string image) {
      using (WebClient webClient = new WebClient()) {
        Directory.CreateDirectory(type);
        var query = type + image;
        webClient.DownloadFile(DownloadURL + query, query);
      }
    }

    private string QueryURL {
      get {
        if (mQueryURL == null) {
          mQueryURL = string.Format("https://global.api.pvp.net/api/lol/static-data/{0}/v1.2/{1}api_key={2}&locale={3}", Server, "{0}", APIKey, Locale);
        }
        return mQueryURL;
      }
    }

    private string DownloadURL {
      get {
        if (mDownloadURL == null) {
          JObject data = callAPI("realm?");
          mDownloadURL = data["cdn"].ToString() + "/" + data["v"].ToString() + "/";
        }
        return mDownloadURL;
      }
    }
  }
}
