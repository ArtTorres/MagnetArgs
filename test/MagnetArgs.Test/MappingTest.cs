using System;
using Xunit;

namespace MagnetArgs.Test
{
    public class MappingTest
    {
        [Fact]
        public void Map_SimpleValue_Success()
        {
            var args = new string[] {
                "--string-value", $"{TestValues.STRING_VALUE}"
            };

            var obj = new SimpleObject();

            Magnet.Attract(args, obj);

            Assert.Equal(TestValues.STRING_VALUE, obj.StringValue);
        }

        [Fact]
        public void Map_SimpleValue_With_Shortcut_Success()
        {
            // TODO: Arreglar error de referencia

            var args = new string[] {
                "--string-value", $"{TestValues.STRING_VALUE}"
            };

            var obj = Magnet.Attract<SimpleObject>(args);

            Assert.Equal(TestValues.STRING_VALUE, obj.StringValue);
        }

        [Fact]
        public void Map_Value_By_Alias_Success()
        {
            var args = new string[] {
                "-string", $"{TestValues.STRING_VALUE}",
                "-char", $"{TestValues.CHAR_VALUE}",
                "-int", $"{TestValues.INT_VALUE}",
                "-long", $"{TestValues.LONG_VALUE}",
                "-bool", $"{TestValues.BOOLEAN_VALUE}",
                "-float", $"{TestValues.FLOAT_VALUE}",
                "-double", $"{TestValues.DOUBLE_VALUE}",
            };

            var obj = new TypeValidation();

            Magnet.Attract(args, obj);

            Assert.Equal(TestValues.STRING_VALUE, obj.StringValue);
            Assert.Equal(TestValues.CHAR_VALUE, obj.CharValue);
            Assert.Equal(TestValues.INT_VALUE, obj.IntegerValue);
            Assert.Equal(TestValues.LONG_VALUE, obj.LongValue);
            Assert.Equal(TestValues.BOOLEAN_VALUE, obj.BooleanValue);
            Assert.Equal(TestValues.FLOAT_VALUE, obj.FloatValue);
            Assert.Equal(TestValues.DOUBLE_VALUE, obj.DoubleValue);
        }

        [Fact]
        public void Map_Value_Types_Success()
        {
            var args = new string[] {
                "--string-value",$"{TestValues.STRING_VALUE}",
                "--char-value",$"{TestValues.CHAR_VALUE}",
                "--integer-value",$"{TestValues.INT_VALUE}",
                "--long-value",$"{TestValues.LONG_VALUE}",
                "--boolean-value",$"{TestValues.BOOLEAN_VALUE}",
                "--float-value",$"{TestValues.FLOAT_VALUE}",
                "--double-value",$"{TestValues.DOUBLE_VALUE}",
            };

            var obj = new TypeValidation();

            Magnet.Attract(args, obj);

            Assert.Equal(TestValues.STRING_VALUE, obj.StringValue);
            Assert.Equal(TestValues.CHAR_VALUE, obj.CharValue);
            Assert.Equal(TestValues.INT_VALUE, obj.IntegerValue);
            Assert.Equal(TestValues.LONG_VALUE, obj.LongValue);
            Assert.Equal(TestValues.BOOLEAN_VALUE, obj.BooleanValue);
            Assert.Equal(TestValues.FLOAT_VALUE, obj.FloatValue);
            Assert.Equal(TestValues.DOUBLE_VALUE, obj.DoubleValue);
        }

        [Fact]
        public void Map_Complex_Object_Type_Success()
        {
            var args = new string[] {
                "--label", TestValues.STRING_VALUE,
                "-point",TestValues.POINT
            };

            var obj = new ComplexObject();

            Magnet.Attract(args, obj);

            Assert.Equal(TestValues.STRING_VALUE, obj.Label);
            Assert.Equal(TestValues.POINT, obj.Point.ToString());
        }

        [Fact]
        public void Map_Complex_Object_Type_Failed()
        {
            var args = new string[] {
                "--label", TestValues.STRING_VALUE,
                "-point","{15,15}"
            };

            var obj = new ComplexObject();

            Assert.Throws<ArgumentFormatException>(delegate ()
            {
                try
                {
                    Magnet.Attract(args, obj);
                }
                catch (AggregateException ex)
                {
                    foreach (var e in ex.InnerExceptions)
                    {
                        throw e;
                    }
                }
            });
        }

        [Fact]
        public void Map_Custom_Symbol_Success()
        {
            var args = new string[] {
                "$$label", TestValues.STRING_VALUE,
                "$point","{15,15}"
            };

            var obj = new ComplexObject();

            Assert.Throws<ArgumentFormatException>(delegate ()
            {
                try
                {
                    Magnet.Attract(args, obj, '$');
                }
                catch (AggregateException ex)
                {
                    foreach (var e in ex.InnerExceptions)
                    {
                        throw e;
                    }
                }
            });
        }
        
        [Magnetizable]
        private class SimpleObject
        {
            [Argument("string-value")]
            public string StringValue { get; set; }
        }

        [Magnetizable]
        private class TypeValidation
        {
            [Argument("string-value", Alias = "string")]
            public string StringValue { get; set; }

            [Argument("char-value", Alias = "char")]
            public char CharValue { get; set; }

            [Argument("integer-value", Alias = "int")]
            public int IntegerValue { get; set; }

            [Argument("long-value", Alias = "long")]
            public long LongValue { get; set; }

            [Argument("boolean-value", Alias = "bool")]
            public bool BooleanValue { get; set; }

            [Argument("float-value", Alias = "float")]
            public float FloatValue { get; set; }

            [Argument("double-value", Alias = "double")]
            public double DoubleValue { get; set; }

            [Argument("decimal-value", Alias = "decimal")]
            public decimal DecimalValue { get; set; }
        }

        [Magnetizable]
        private class ComplexObject
        {
            [Argument("label"), IsRequired]
            public string Label { get; set; }

            [Argument("custom-point", Alias = "point"), IsRequired, Parser(typeof(PointParser))]
            public Point Point { get; set; }
        }
    }
}
