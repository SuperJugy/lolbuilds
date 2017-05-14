using System;
using System.Collections.Generic;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace com.jcandksolutions.lol.Model {
  public class MasteryPageConverter : JsonConverter {
    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
      Dictionary<string, string> dictionary = ((MasteryPage)value).Properties;
      JObject t = JObject.FromObject(dictionary);
      t.WriteTo(writer);
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
      JObject token = JObject.Load(reader);
      var properties = token.ToObject<Dictionary<string, string>>();
      return new MasteryPage(properties);
    }

    public override bool CanConvert(Type objectType) {
      return objectType == typeof(MasteryPage);
    }
  }
}
