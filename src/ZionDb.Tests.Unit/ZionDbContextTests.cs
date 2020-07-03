using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using ZionDb.Contexts;

namespace ZionDb.Tests.Unit
{
    public class ZionDbContextTests
    {
        [Fact]
        public async Task Should_get_value_by_key()
        {
            var sut = new ZionDbMemoryContext();
            const string key = "a key";
            var valueExpected = new ComplexObjectMock
            {
                CharProperty = 'r',
                StringProperty = "a test",
                ShortProperty = short.MaxValue,
                IntProperty = int.MaxValue,
                LongProperty = long.MaxValue,
                DateTimeProperty = DateTime.Now.AddMinutes(5),
                DateTimeOffsetProperty = DateTimeOffset.Now.AddMinutes(10),
                ComplexObjectMocks = new List<ComplexObjectMock>
                {
                    new ComplexObjectMock {
                        CharProperty = 's',
                        StringProperty = "other test",
                        ShortProperty = short.MinValue,
                        IntProperty = int.MinValue,
                        LongProperty = long.MinValue,
                        DateTimeProperty = DateTime.Now.AddMinutes(6),
                        DateTimeOffsetProperty = DateTimeOffset.Now.AddMinutes(11)
                    }
                }
            };
            await sut.SetAsync(key, valueExpected);

            var valueGetted = await sut.GetAsync<ComplexObjectMock>(key);

            Assert.Equal(valueExpected, valueGetted);
        }

        [Fact]
        public async Task Shouldnt_throw_an_exception_when_parameters_are_valid()
        {
            var sut = new ZionDbMemoryContext();
            const string aKey = "aKey";
            const string aContent = "a content";

            async Task Action() => await sut.SetAsync(aKey, aContent);

            Assert.Null(await Record.ExceptionAsync(Action));
        }

        [Fact]
        public async Task Should_get_value_default_when_the_item_does_not_exist()
        {
            var sut = new ZionDbMemoryContext();

            var valueGetted = await sut.GetAsync<ComplexObjectMock>("other key");

            Assert.Equal(default, valueGetted);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async Task Should_get_value_default_when_the_key_is_invalid(string key)
        {
            var sut = new ZionDbMemoryContext();

            var valueGetted = await sut.GetAsync<ComplexObjectMock>(key);

            Assert.Equal(default, valueGetted);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async Task Should_throw_exception_when_the_key_in_set_async_is_invalid(string key)
        {
            var sut = new ZionDbMemoryContext();
            const string aContent = "a content";

            async Task Action() => await sut.SetAsync(key, aContent);

            var exception = await Assert.ThrowsAsync<ArgumentException>(Action);
            Assert.Equal($"'key' must have a valid value. The value passed was '{key}'.", exception.Message);
        }
    }
}