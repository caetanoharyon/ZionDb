using System;

namespace ZionDb.Items
{
    public class Content<T>
    {
        public T Value { get; }
        public DateTimeOffset DateTimeOffsetOfCreation { get; }
        public long TicksOfExpirationAsLong { get; }

        public Content(T value, TimeSpan ticksOfExpiration = default)
        {
            Value = value;
            DateTimeOffsetOfCreation = DateTimeOffset.UtcNow;
            TicksOfExpirationAsLong = ticksOfExpiration.Ticks;
        }
    }
}