using System;

namespace ZionDb.Items
{
    public sealed class Item
    {
        public string Key { get; private set; }
        public string Value { get; private set; }
        public DateTimeOffset DateTimeOffsetOfCreation { get; private set; }
        public long TicksOfExpiration { get; private set; }

        public Item(string key, string value, TimeSpan ticksOfExpiration)
        {
            Key = key;
            Value = value;
            TicksOfExpiration = ticksOfExpiration.Ticks;
            DateTimeOffsetOfCreation = DateTimeOffset.UtcNow;
        }
    }
}