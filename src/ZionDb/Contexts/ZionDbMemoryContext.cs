using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace ZionDb
{
    public class ZionDbMemoryContext
    {
        private static readonly HashSet<KeyValuePair<string, string>> Context = new HashSet<KeyValuePair<string, string>>();

        public void Set(string key, object value)
        {
            Context.Add(new KeyValuePair<string, string>(key, JsonConvert.SerializeObject(value)));
        }

        public T Get<T>(string key)
        {
            return JsonConvert.DeserializeObject<T>(Context.FirstOrDefault(i => i.Key == key).Value);
        }
    }
}