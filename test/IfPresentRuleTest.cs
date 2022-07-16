using System;
using Xunit;

namespace MagnetArgs.Test
{
    public class IfPresentRuleTest
    {
        [Fact]
        public void Eval_IfPresent_Rule_Success()
        {
            var args = new string[] {
                "--present"
            };

            var obj = new PresentOnly();

            Magnet.Attract(args, obj);

            Assert.True(obj.ValueA);
        }

        [Fact]
        public void Eval_IfPressent_Rule_NotPresent()
        {
            var args = new string[0];

            var obj = new PresentOnly();

            Magnet.Attract(args, obj);

            Assert.False(obj.ValueA);
        }

        [Fact]
        public void Eval_IfPresent_Rule_With_Default_Success()
        {
            var args = new string[] {
                "--a"
            };

            var obj = new PresentOnlyWithDefault();

            Magnet.Attract(args, obj);

            Assert.Equal(TestValues.INT_VALUE, obj.ValueA);
        }

        [Fact]
        public void Eval_IfPresent_Rule_NotPresent_With_Default_Success()
        {
            var args = new string[0];

            var obj = new PresentOnlyWithDefault();

            Magnet.Attract(args, obj);

            Assert.Equal(0, obj.ValueA);
        }

        [Fact]
        public void Eval_IfPresent_Rule_With_Parser_Success()
        {
            var args = new string[] {
                "--a"
            };

            var obj = new PresentOnlyWithDefaultAndParser();

            Magnet.Attract(args, obj);

            Assert.Equal(TestValues.POINT, obj.ValueA.ToString());
        }

        [Fact]
        public void Eval_IfPresent_Rule_With_Parser_Failed() 
        {
            var args = new string[] {
                "--a"
            };

            var obj = new PresentOnlyWithDefaultAndParserError();

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
        private class PresentOnly
        {
            [Argument("present"), IfPresent]
            public bool ValueA { get; set; }
        }

        [Magnetizable]
        private class PresentOnlyWithDefault
        {
            [Argument("a"), IfPresent, Default(TestValues.INT_VALUE)]
            public int ValueA { get; set; }
        }

        [Magnetizable]
        private class PresentOnlyWithDefaultAndParser
        {
            [Argument("a"), IfPresent, Default(TestValues.POINT), Parser(typeof(PointParser))]
            public Point ValueA { get; set; }
        }

        [Magnetizable]
        private class PresentOnlyWithDefaultAndParserError
        {
            [Argument("a"), IfPresent, Default("{A,A}"), Parser(typeof(PointParser))]
            public Point ValueA { get; set; }
        }

        [Magnetizable]
        private class PresentOnlyWithParser
        {
            [Argument("a"), IfPresent, Parser(typeof(PointParser))]
            public Point ValueA { get; set; }
        }
    }
}
