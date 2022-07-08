using System;
using Xunit;

namespace MagnetArgs.Test
{
    public class IsRequiredRuleTest
    {
        [Fact]
        public void Eval_IsRequired_Rule_Success()
        {
            var args = new string[] {
                "--a",TestValues.STRING_VALUE
            };

            var obj = new RequiredOnly();

            Magnet.Attract(args, obj);

            Assert.Equal(TestValues.STRING_VALUE, obj.ValueA);
        }

        [Fact]
        public void Eval_IsRequired_Rule_Exception()
        {
            var args = new string[] {
                "--b"
            };

            var obj = new RequiredOnly();

            Assert.Throws<ArgumentNotFoundException>(delegate ()
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
        public void Eval_IsRequired_Rule_With_Default_Success()
        {
            var args = new string[] {
                "--a", TestValues.INT_VALUE.ToString()
            };

            var obj = new RequiredOnlyWithDefault();

            Magnet.Attract(args, obj);

            Assert.Equal(TestValues.INT_VALUE, obj.ValueA);
        }

        [Fact]
        public void Eval_IsRequired_Rule_With_No_Default_No_Argument_Failed()
        {
            var args = new string[0];

            var obj = new RequiredOnly();

            Assert.Throws<ArgumentNotFoundException>(delegate ()
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
        public void Eval_IsRequired_Rule_With_IfPresent_Success()
        {
            var args = new string[] {
                "--a", TestValues.BOOLEAN_VALUE.ToString()
            };

            var obj = new RequiredOnlyWithPresent();

            Magnet.Attract(args, obj);

            Assert.Equal(TestValues.BOOLEAN_VALUE, obj.ValueA);
        }

        [Fact]
        public void Eval_IsRequired_Rule_With_IfPresent_Failed()
        {
            var args = new string[0];

            var obj = new RequiredOnly();

            Assert.Throws<ArgumentNotFoundException>(delegate ()
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
        public void Eval_IsRequired_Rule_With_Parser_Success()
        {
            var args = new string[] {
                "--a", TestValues.POINT
            };

            var obj = new RequiredOnlyWithParser();

            Magnet.Attract(args, obj);

            Assert.Equal(TestValues.POINT, obj.ValueA.ToString());
        }

        [Fact]
        public void Eval_IsRequired_Rule_With_Parser_Failed()
        {
            var args = new string[0];

            var obj = new RequiredOnlyWithParser();

            Assert.Throws<ArgumentNotFoundException>(delegate ()
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
        private class RequiredOnly
        {
            [Argument("a"), IsRequired]
            public string ValueA { get; set; }
        }

        [Magnetizable]
        private class RequiredOnlyWithDefault
        {
            [Argument("a"), IsRequired, Default(50)]
            public int ValueA { get; set; }
        }

        [Magnetizable]
        private class RequiredOnlyWithPresent
        {
            [Argument("a"), IsRequired, IfPresent]
            public bool ValueA { get; set; }
        }


        [Magnetizable]
        private class RequiredOnlyWithParser
        {
            [Argument("a"), IsRequired, Parser(typeof(PointParser))]
            public Point ValueA { get; set; }
        }
    }
}
