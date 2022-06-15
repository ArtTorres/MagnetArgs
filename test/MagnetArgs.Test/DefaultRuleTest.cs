using System;
using Xunit;

namespace MagnetArgs.Test
{
    public class DefaultRuleTest
    {
        [Fact]
        public void Eval_DefaultValue_Rule_NativeValues_Success()
        {
            var args = new string[0];

            var obj = new DefaultValues();

            Magnet.Attract(args, obj);

            Assert.Equal(TestValues.STRING_VALUE, obj.ValueString);
            Assert.Equal(TestValues.CHAR_VALUE, obj.ValueChar);
            Assert.Equal(TestValues.BOOLEAN_VALUE, obj.ValueBool);
            Assert.Equal(TestValues.BYTE_VALUE, obj.ValueByte);
            Assert.Equal(TestValues.SBYTE_VALUE, obj.ValueSByte);
            Assert.Equal(TestValues.SHORT_VALUE, obj.ValueShort);
            Assert.Equal(TestValues.USHORT_VALUE, obj.ValueUShort);
            Assert.Equal(TestValues.INT_VALUE, obj.ValueInt);
            Assert.Equal(TestValues.UINT_VALUE, obj.ValueUInt);
            Assert.Equal(TestValues.LONG_VALUE, obj.ValueLong);
            Assert.Equal(TestValues.ULONG_VALUE, obj.ValueULong);
            Assert.Equal(TestValues.FLOAT_VALUE, obj.ValueFloat);
            Assert.Equal(TestValues.DOUBLE_VALUE, obj.ValueDouble);
        }

        [Fact]
        public void Eval_DefaultValue_Rule_WithParser_Success()
        {
            var args = new string[]
            {
                "--parser", TestValues.POINT
            };

            var obj = new DefaultValuesWithParser();

            Magnet.Attract(args, obj);

            Assert.Equal(TestValues.POINT, obj.ValueA.ToString());
        }

        [Fact]
        public void Eval_DefaultValue_Rule_WithParser_Fail()
        {
            var args = new string[0];

            var obj = new DefaultValuesWithWrongDefault();

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

        [Magnetizable]
        private class DefaultValues
        {
            [Argument("string"), Default(TestValues.STRING_VALUE)]
            public string ValueString { get; set; }

            [Argument("char"), Default(TestValues.CHAR_VALUE)]
            public char ValueChar { get; set; }

            [Argument("bool"), Default(TestValues.BOOLEAN_VALUE)]
            public bool ValueBool { get; set; }

            [Argument("byte"), Default(TestValues.BYTE_VALUE)]
            public byte ValueByte { get; set; }

            [Argument("sbyte"), Default(TestValues.SBYTE_VALUE)]
            public sbyte ValueSByte { get; set; }

            [Argument("short"), Default(TestValues.SHORT_VALUE)]
            public short ValueShort { get; set; }

            [Argument("ushort"), Default(TestValues.USHORT_VALUE)]
            public ushort ValueUShort { get; set; }

            [Argument("int"), Default(TestValues.INT_VALUE)]
            public int ValueInt { get; set; }

            [Argument("uint"), Default(TestValues.UINT_VALUE)]
            public uint ValueUInt { get; set; }

            [Argument("long"), Default(TestValues.LONG_VALUE)]
            public long ValueLong { get; set; }

            [Argument("ulong"), Default(TestValues.ULONG_VALUE)]
            public ulong ValueULong { get; set; }

            [Argument("float"), Default(TestValues.FLOAT_VALUE)]
            public float ValueFloat { get; set; }

            [Argument("double"), Default(TestValues.DOUBLE_VALUE)]
            public double ValueDouble { get; set; }
        }

        [Magnetizable]
        private class DefaultValuesWithParser
        {
            [Argument("parser"), Default(TestValues.POINT), Parser(typeof(PointParser))]
            public Point ValueA { get; set; }
        }

        [Magnetizable]
        private class DefaultValuesWithWrongDefault
        {
            [Argument("int"), Default(TestValues.STRING_VALUE)]
            public int ValueInt { get; set; }
        }
    }
}
