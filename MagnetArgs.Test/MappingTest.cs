using Xunit;
using MagnetArgs.Test.Models;

namespace MagnetArgs.Test
{
    public class MappingTest
    {
        private string v1 = "Hello World";
        private char v2 = 'a';
        private int v3 = 2147483647;
        private long v4 = 9223372036854775807;
        private float v5 = 1000000.0f;
        private double v6 = 1000000.0d;
        private decimal v7 = 1000000.0m;

        [Fact]
        public void Alias()
        {
            var args = new string[] {
                "-string", $"{v1}",
                "-char", $"{v2}",
                "-int", $"{v3}",
                "-long", $"{v4}",
                "-bool", "true",
                "-float", $"{v5}",
                "-double", $"{v6}",
                "-decimal", $"{v7}"
            };

            var obj = new TypeObject();

            Magnet.Magnetize(obj, args);

            Assert.Equal(v1, obj.StringValue);
            Assert.Equal(v2, obj.CharValue);
            Assert.Equal(v3, obj.IntegerValue);
            Assert.Equal(v4, obj.LongValue);
            Assert.True(obj.BooleanValue);
            Assert.Equal(v5, obj.FloatValue);
            Assert.Equal(v6, obj.DoubleValue);
            Assert.Equal(v7, obj.DecimalValue);
        }

        [Fact]
        public void ValueTypes()
        {
            var args = new string[] {
                "--string-value",$"{v1}",
                "--char-value",$"{v2}",
                "--integer-value",$"{v3}",
                "--long-value",$"{v4}",
                "--boolean-value","true",
                "--float-value",$"{v5}",
                "--double-value",$"{v6}",
                "--decimal-value",$"{v7}"
            };

            var obj = new TypeObject();

            Magnet.Magnetize(obj, args);

            Assert.Equal(v1, obj.StringValue);
            Assert.Equal(v2, obj.CharValue);
            Assert.Equal(v3, obj.IntegerValue);
            Assert.Equal(v4, obj.LongValue);
            Assert.True(obj.BooleanValue);
            Assert.Equal(v5, obj.FloatValue);
            Assert.Equal(v6, obj.DoubleValue);
            Assert.Equal(v7, obj.DecimalValue);
        }

        [Fact]
        public void OptionSet()
        {
            var args = new string[] {
                "--present-value",
                "--raise-ex",
                "--custom-point","[-10,15]"
            };

            var obj = new OptionSetObject();

            Magnet.Magnetize(obj, args);

            Assert.True(obj.PObject.PresentValue);
            Assert.Equal(15, obj.CObject.Point.Y);
        }
    }
}
