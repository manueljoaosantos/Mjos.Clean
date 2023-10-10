using Mjos.Clean.Domain.Common;

namespace Mjos.Clean.Tests.Domain.Common
{
    public class ValueObjectTests
    {
        private class SampleValueObject : ValueObject
        {
            public int Value { get; }

            public SampleValueObject(int value)
            {
                Value = value;
            }

            protected override IEnumerable<object> GetEqualityComponents()
            {
                yield return Value;
            }
        }

        [Fact]
        public void Equals_NullObject_ReturnsFalse()
        {
            SampleValueObject obj1 = new SampleValueObject(42);
            SampleValueObject obj2 = null;

            Assert.False(obj1.Equals(obj2));
        }

        [Fact]
        public void Equals_SameInstance_ReturnsTrue()
        {
            SampleValueObject obj1 = new SampleValueObject(42);

            Assert.True(obj1.Equals(obj1));
        }

        [Fact]
        public void Equals_SameValues_ReturnsTrue()
        {
            SampleValueObject obj1 = new SampleValueObject(42);
            SampleValueObject obj2 = new SampleValueObject(42);

            Assert.True(obj1.Equals(obj2));
        }

        [Fact]
        public void Equals_DifferentValues_ReturnsFalse()
        {
            SampleValueObject obj1 = new SampleValueObject(42);
            SampleValueObject obj2 = new SampleValueObject(99);

            Assert.False(obj1.Equals(obj2));
        }

        [Fact]
        public void Equals_DifferentValueObjectTypes_ReturnsFalse()
        {
            SampleValueObject obj1 = new SampleValueObject(42);
            object obj2 = new object();

            Assert.False(obj1.Equals(obj2));
        }

        [Fact]
        public void GetHashCode_SameValue_ReturnsSameHashCode()
        {
            SampleValueObject obj1 = new SampleValueObject(42);
            SampleValueObject obj2 = new SampleValueObject(42);

            Assert.Equal(obj1.GetHashCode(), obj2.GetHashCode());
        }

        [Fact]
        public void GetHashCode_DifferentValues_ReturnsDifferentHashCodes()
        {
            SampleValueObject obj1 = new SampleValueObject(42);
            SampleValueObject obj2 = new SampleValueObject(99);

            Assert.NotEqual(obj1.GetHashCode(), obj2.GetHashCode());
        }
    }
}