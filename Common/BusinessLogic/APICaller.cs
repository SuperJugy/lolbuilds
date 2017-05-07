using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

using Newtonsoft.Json.Linq;

namespace com.jcandksolutions.lol.BusinessLogic {
  public class APICaller {
    private const string MASTERY_TYPE = "img/mastery/";
    private const string RUNE_TYPE = "img/rune/";
    private const string ITEM_TYPE = "img/item/";
    private const string PASSIVE_TYPE = "img/passive/";
    private const string CHAMPION_TYPE = "img/champion/";
    private const string SPELL_TYPE = "img/spell/";
    private string mDownloadURL;
    private string mQueryURL;
    public string APIKey { private get; set; }
    public string Server { private get; set; }
    public string Locale { private get; set; }
    private string QueryURL {
      get {
        return mQueryURL ?? (mQueryURL = string.Format("https://{0}.api.riotgames.com/lol/static-data/v3/{1}api_key={2}&locale={3}", Server, "{0}", APIKey, Locale));
      }
    }
    private string DownloadURL {
      get {
        if (mDownloadURL == null) {
          JObject data = callAPI("realms?");
          mDownloadURL = data["cdn"] + "/" + data["v"] + "/";
        }
        return mDownloadURL;
      }
    }

    public JObject queryItems() {
      return callAPI("items?itemListData=all&");
    }

    public JObject queryChampions() {
      return callAPI("champions?dataById=true&champListData=all&");
    }

    public JObject queryRunes() {
      return callAPI("runes?runeListData=all&");
    }

    public JObject queryMasteries() {
      return callAPI("masteries?masteryListData=all&");
    }

    public JObject querySummonerSpells() {
      return callAPI("summoner-spells?spellListData=all&dataById=true&");
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
      using (var client = new HttpClient()) {
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        HttpResponseMessage response = client.GetAsync(string.Format(QueryURL, query)).Result;
        if (!response.IsSuccessStatusCode) {
          throw new InvalidOperationException("Error calling Riot API servers. Status Code: " + response.StatusCode);
        }

        return JObject.Parse(response.Content.ReadAsStringAsync().Result);
      }
    }

    private void downloadImage(string type, string image) {
      using (var webClient = new WebClient()) {
        Directory.CreateDirectory(type);
        string query = type + image;
        webClient.DownloadFile(DownloadURL + query, query);
      }
    }
  }
}
