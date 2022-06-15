using System;
using Xunit;

namespace MagnetArgs.Test
{
    public class ParseRuleTest
    {
        [Fact]
        public void Eval_Parse_Rule_Success()
        {
            var args = new string[] {
                "--point",TestValues.POINT
            };

            var obj = new ParserOnly();

            Magnet.Attract(args, obj);

            Assert.True(obj.Point.X != 0);
            Assert.True(obj.Point.Y != 0);
        }

        [Fact]
        public void Eval_Parse_Rule_Exception()
        {
            var args = new string[] {
                "--point","{-10,15}"
            };

            var obj = new ParserOnly();

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
        public void Eval_Parse_Rule_Missing_Parser_Exception()
        {
            // TODO: Implement missing parser

            var args = new string[] {
                "--point",TestValues.POINT
            };

            var obj = new ParserOnlyWithInvalidParser();

            Assert.Throws<MissingParserException>(delegate ()
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
        private class ParserOnly
        {
            [Argument("point"), Parser(typeof(PointParser))]
            public Point Point { get; set; }
        }

        [Magnetizable]
        private class ParserOnlyWithInvalidParser
        {
            [Argument("point"), Parser(typeof(Point))]
            public Point Point { get; set; }
        }
    }
}
