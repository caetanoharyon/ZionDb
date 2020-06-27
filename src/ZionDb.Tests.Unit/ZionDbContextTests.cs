using System;
using Xunit;

namespace ZionDb.Tests.Unit
{
    public class ZionDbContextTests
    {
        [Fact]
        public void Should_get_value_by_key()
        {
            var sut = new ZionDbMemoryContext();
            const string key = "a key";
            var valueExpected = new ComplexObjectMock { StringProperty = "a test" };
            sut.Set(key, valueExpected);

            var valueGetted = sut.Get<ComplexObjectMock>(key);

            Assert.Equal(valueExpected, valueGetted);
        }
    }

    public class ComplexObjectMock
    {
        public char CharProperty { get; set; }
        public string StringProperty { get; set; }
        public short ShortProperty { get; set; }
        public int IntProperty { get; set; }
        public long LongProperty { get; set; }
        public DateTime DateTimeProperty { get; set; }
        public DateTimeOffset DateTimeOffsetProperty { get; set; }

        public override bool Equals(object? obj)
        {
            var objeto = (ComplexObjectMock)obj;

            return objeto != null &&
                   CharProperty == objeto.CharProperty &&
                   StringProperty == objeto.StringProperty &&
                   ShortProperty == objeto.ShortProperty &&
                   IntProperty == objeto.IntProperty &&
                   LongProperty == objeto.LongProperty &&
                   DateTimeProperty == objeto.DateTimeProperty &&
                   DateTimeOffsetProperty == objeto.DateTimeOffsetProperty;
        }
    }
}