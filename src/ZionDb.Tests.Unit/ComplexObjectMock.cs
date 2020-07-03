using System;
using System.Collections.Generic;
using System.Linq;

namespace ZionDb.Tests.Unit
{
    public class ComplexObjectMock
    {
        public char CharProperty { get; set; }
        public string StringProperty { get; set; }
        public short ShortProperty { get; set; }
        public int IntProperty { get; set; }
        public long LongProperty { get; set; }
        public DateTime DateTimeProperty { get; set; }
        public DateTimeOffset DateTimeOffsetProperty { get; set; }
        public List<ComplexObjectMock> ComplexObjectMocks { get; set; }

        public static bool operator ==(ComplexObjectMock firstObject, ComplexObjectMock secondObject)
        {
            if (ReferenceEquals(firstObject, secondObject))
                return true;
            if (firstObject is null || secondObject is null)
                return false;

            return firstObject.CharProperty == secondObject.CharProperty &&
                   firstObject.StringProperty == secondObject.StringProperty &&
                   firstObject.ShortProperty == secondObject.ShortProperty &&
                   firstObject.IntProperty == secondObject.IntProperty &&
                   firstObject.LongProperty == secondObject.LongProperty &&
                   firstObject.DateTimeProperty == secondObject.DateTimeProperty &&
                   firstObject.DateTimeOffsetProperty == secondObject.DateTimeOffsetProperty &&
                   IsSameLists(firstObject.ComplexObjectMocks, secondObject.ComplexObjectMocks);
        }

        public static bool operator !=(ComplexObjectMock firstObject, ComplexObjectMock secondObject) =>
            !(firstObject == secondObject);

        public override bool Equals(object obj) =>
            Equals(obj as ComplexObjectMock);

        public override int GetHashCode() =>
            HashCode.Combine(CharProperty, StringProperty, ShortProperty, IntProperty, LongProperty, DateTimeProperty, DateTimeOffsetProperty, ComplexObjectMocks);

        private bool Equals(ComplexObjectMock otherObject)
        {
            if (otherObject is null || GetType() != otherObject.GetType())
                return false;
            if (ReferenceEquals(this, otherObject))
                return true;

            return CharProperty == otherObject.CharProperty &&
                   StringProperty == otherObject.StringProperty &&
                   ShortProperty == otherObject.ShortProperty &&
                   IntProperty == otherObject.IntProperty &&
                   LongProperty == otherObject.LongProperty &&
                   DateTimeProperty == otherObject.DateTimeProperty &&
                   DateTimeOffsetProperty == otherObject.DateTimeOffsetProperty &&
                   IsSameLists(ComplexObjectMocks, otherObject.ComplexObjectMocks);
        }

        private static bool IsSameLists(IReadOnlyCollection<ComplexObjectMock> firstList, IReadOnlyCollection<ComplexObjectMock> secondList)
        {
            if (firstList == null && secondList == null) return true;
            if (firstList == null || secondList == null) return false;

            var firstNotSecond = firstList.Except(secondList).ToList();
            var secondNotFirst = secondList.Except(firstList).ToList();
            return !firstNotSecond.Any() && !secondNotFirst.Any();
        }
    }
}