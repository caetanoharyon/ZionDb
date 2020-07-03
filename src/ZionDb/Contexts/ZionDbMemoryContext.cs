using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ZionDb.Items;

namespace ZionDb.Contexts
{
    public class ZionDbMemoryContext
    {
        private static readonly HashSet<KeyValuePair<string, string>> Context = new HashSet<KeyValuePair<string, string>>();

        public async Task SetAsync<T>(string key, T value, TimeSpan ticksOfExpiration = default)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException($"'{nameof(key)}' must have a valid value. The value passed was '{key}'.");

            var content = new Content<T>(value, ticksOfExpiration);
            var contentSerialized = await Task.Run(() => JsonConvert.SerializeObject(content));
            Context.Add(new KeyValuePair<string, string>(key, contentSerialized));
        }

        public async Task<T> GetAsync<T>(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
                return await Task.Run(() => default(T));

            var pair = Context.FirstOrDefault(p => p.Key == key);
            var contentSerialized = pair.Value;

            if (string.IsNullOrWhiteSpace(contentSerialized))
                return await Task.Run(() => default(T));

            var content = await Task.Run(() => JsonConvert.DeserializeObject<Content<T>>(contentSerialized));

            return content.Value;
        }
    }
}