using MagnetArgs.Test.Models;
using System;
using Xunit;

namespace MagnetArgs.Test
{
    public class ConditionTest
    {
        [Fact]
        public void IsRequired()
        {
            var args = "--required-value HelloWorld --present-value  --default-value 50".Split(' ');

            var obj = new ComplexObject();

            Magnet.Magnetize(obj, args);

            Assert.Equal("HelloWorld", obj.RequiredValue);
        }

        [Fact]
        public void IsRequiredException()
        {
            var args = "--present-value  --default-value 50".Split(' ');

            var obj = new ComplexObject();

            Magnet.Magnetize(obj, args);

            Assert.Throws<IsRequiredException>(delegate ()
            {
                foreach (var ex in obj.Exceptions)
                {
                    throw ex;
                }
            });
        }

        [Fact]
        public void IfPresent()
        {
            var args = "--required-value HelloWorld --present-value  --default-value 50".Split(' ');

            var obj = new ComplexObject();

            Magnet.Magnetize(obj, args);

            Assert.True(obj.PresentValue);
        }

        [Fact]
        public void IfNotPresent()
        {
            var args = "--required-value HelloWorld  --default-value 50".Split(' ');

            var obj = new ComplexObject();

            Magnet.Magnetize(obj, args);

            Assert.False(obj.PresentValue);
        }

        [Fact]
        public void IfPresentException()
        {
            //TODO: Evaluate if keep this behavior
            var args = "--required-value HelloWorld --present-value  --default-value 50".Split(' ');

            var obj = new ComplexObject();

            Magnet.Magnetize(obj, args);

            Assert.Throws<IsRequiredException>(delegate ()
            {
                foreach (var ex in obj.Exceptions)
                {
                    throw ex;
                }
            });
        }

        [Fact]
        public void DefaultValue()
        {
            var args = "--required-value HelloWorld --present-value".Split(' ');

            var obj = new ComplexObject();

            Magnet.Magnetize(obj, args);

            Assert.Equal(25, obj.DefaultValue);
        }

        [Fact]
        public void NotDefaultValue()
        {
            var args = "--required-value HelloWorld --present-value --default-value 50".Split(' ');

            var obj = new ComplexObject();

            Magnet.Magnetize(obj, args);

            Assert.Equal(50, obj.DefaultValue);
        }

        [Fact]
        public void RangeValue()
        {
            var args = "--range-value 5".Split(' ');

            var obj = new RangeObject();

            Magnet.Magnetize(obj, args);

            Assert.Equal(5, obj.RangeValue);
        }

        [Fact]
        public void OutOfRangeValue()
        {
            var args = "--range-value 15".Split(' ');

            var obj = new RangeObject();

            Magnet.Magnetize(obj, args);

            Assert.Throws<OutOfRangeException>(delegate ()
            {
                foreach (var ex in obj.Exceptions)
                {
                    throw ex;
                }
            });
        }

        [Fact]
        public void ParseValue()
        {
            var args = $"--custom-point [-10,15]".Split(' ');

            var obj = new CustomObject();

            Magnet.Magnetize(obj, args);

            Assert.Equal(-10, obj.Point.X);
            Assert.Equal(15, obj.Point.Y);
        }

        [Fact]
        public void ParseValueException()
        {
            var args = "--custom-point {-10,15}".Split(' ');

            var obj = new CustomObject();

            Magnet.Magnetize(obj, args);

            Assert.Throws<Exception>(delegate ()
            {
                foreach (var ex in obj.Exceptions)
                {
                    throw ex;
                }
            });
        }
    }
}
