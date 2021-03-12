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
            var args = new string[] {
                "--required-value","HelloWorld",
                "--present-value",
                "--default-value","50"
            };

            var obj = new ComplexObject();

            Magnet.Attract(obj, args);

            Assert.Equal("HelloWorld", obj.RequiredValue);
        }

        [Fact]
        public void IsRequiredException()
        {
            var args = new string[] {
                "--present-value",
                "--default-value","50"
            };

            var obj = new ComplexObject();

            Magnet.Attract(obj, args);

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
            var args = new string[] {
                "--required-value","HelloWorld",
                "--present-value",
                "--default-value","50"
            };

            var obj = new ComplexObject();

            Magnet.Attract(obj, args);

            Assert.True(obj.PresentValue);
        }

        [Fact]
        public void IfNotPresent()
        {
            var args = new string[] {
                "--required-value","HelloWorld",
                "--default-value","50"
            };

            var obj = new ComplexObject();

            Magnet.Attract(obj, args);

            Assert.False(obj.PresentValue);
        }

        [Fact]
        public void IfPresentException()
        {
            var args = new string[] {
                "--present-value",
                "--raise-ex"
            };

            var obj = new PresentObject();

            Magnet.Attract(obj, args);

            Assert.Throws<IfPresentException>(delegate ()
            {
                foreach (var ex in obj.Exceptions)
                {
                    throw ex;
                }
            });
        }

        [Fact]
        public void IfPresentExceptionPass()
        {
            var args = new string[] {
                "--present-value",
                "--raise-ex"
            };

            var obj = new PresentPassObject();

            Magnet.Attract(obj, args);

            Assert.True(obj.PresentValue);
        }

        [Fact]
        public void DefaultValue()
        {
            var args = new string[] {
                "--required-value","HelloWorld",
                "--present-value"
            };

            var obj = new ComplexObject();

            Magnet.Attract(obj, args);

            Assert.Equal(25, obj.DefaultValue);
        }

        [Fact]
        public void NotDefaultValue()
        {
            var args = new string[] {
                "--required-value","HelloWorld",
                "--present-value",
                "--default-value","50"
            };

            var obj = new ComplexObject();

            Magnet.Attract(obj, args);

            Assert.Equal(50, obj.DefaultValue);
        }

        [Fact]
        public void ParseValue()
        {
            var args = new string[] {
                "--custom-point","[-10,15]"
            };

            var obj = new CustomObject();

            Magnet.Attract(obj, args);

            Assert.Equal(-10, obj.Point.X);
            Assert.Equal(15, obj.Point.Y);
        }

        [Fact]
        public void ParseValueException()
        {
            var args = new string[] {
                "--custom-point","{-10,15}"
            };

            var obj = new CustomObject();

            Magnet.Attract(obj, args);

            Assert.Throws<FormatException>(delegate ()
            {
                foreach (var ex in obj.Exceptions)
                {
                    throw ex;
                }
            });
        }
    }
}
