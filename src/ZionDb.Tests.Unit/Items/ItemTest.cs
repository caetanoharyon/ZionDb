using System;
using Xunit;
using ZionDb.Items;

namespace ZionDb.Tests.Unit.Items
{
    public class ItemTest
    {
        [Fact]
        public void Should_create_an_item_whith_all_data_consistents()
        {
            var dateTimeOffsetLow = DateTimeOffset.UtcNow.AddSeconds(-2);
            var dateTimeOffsetHigh = DateTimeOffset.UtcNow.AddSeconds(2);
                var keyExpected = Guid.NewGuid().ToString();
            var valueExpected = "{\"teste\":\"teste\"}";
            var timeSpan = TimeSpan.FromHours(1);
            
            var item = new Item(keyExpected, valueExpected, timeSpan); 

            Assert.Equal(keyExpected, item.Key);
            Assert.Equal(valueExpected, item.Value);
            Assert.InRange(item.DateTimeOffsetOfCreation, dateTimeOffsetLow, dateTimeOffsetHigh);
            Assert.Equal(timeSpan.Ticks, item.TicksOfExpiration);
        }
    }
}