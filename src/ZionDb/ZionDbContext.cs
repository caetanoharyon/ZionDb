using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace ZionDb
{
    public class ZionDbContext
    {
        private static readonly HashSet<KeyValuePair<string, string>> Contexto = new HashSet<KeyValuePair<string, string>>();

        public void Set(string key, object value)
        {
            Contexto.Add(new KeyValuePair<string, string>(key, JsonConvert.SerializeObject(value)));
        }

        public T Get<T>(string key)
        {
            return JsonConvert.DeserializeObject<T>(Contexto.FirstOrDefault(i => i.Key == key).Value);
        }
    }
}