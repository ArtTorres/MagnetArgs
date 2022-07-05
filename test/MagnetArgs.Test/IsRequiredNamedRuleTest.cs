using System;
using Xunit;

namespace MagnetArgs.Test
{
    public class IsRequiredNamedRuleTest
    {
        [Fact(DisplayName = "Eval_IsRequiredNamed_Rule_Success")]
        public void Eval_IsRequiredNamed_Rule_Success()
        {
            var args = new string[] {
                "--a",TestValues.STRING_VALUE,
                "--b", TestValues.STRING_VALUE
            };

            var obj = new RequiredNamedOnly();

            Magnet.Attract(args, obj);

            Assert.Equal(TestValues.STRING_VALUE, obj.ValueA);
            Assert.Equal(TestValues.STRING_VALUE, obj.ValueB);
        }

        [Fact]
        public void Eval_IsRequiredNamed_Rule_Failed()
        {
            var args = new string[] {
                "--a",TestValues.STRING_VALUE
            };

            var obj = new RequiredNamedOnly();

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
        public void Eval_IsRequiredNamedRule_Depends_Success()
        {
            var args = new string[]
            {
                "--b", TestValues.STRING_VALUE
            };

            var obj = new RequiredNamedOnly();

            Magnet.Attract(args, obj);

            Assert.Equal(string.Empty, obj.ValueA);
            Assert.Equal(TestValues.STRING_VALUE, obj.ValueB);
        }

        [Fact]
        public void Eval_IsRequiredNamedRule_Ignore_Success()
        {
            var args = new string[0];

            var obj = new RequiredNamedOnly();

            Magnet.Attract(args, obj);

            Assert.Equal(string.Empty, obj.ValueA);
            Assert.Equal(string.Empty, obj.ValueB);
        }

        [Magnetizable]
        private class RequiredNamedOnly
        {
            [Argument("a")]
            public string ValueA { get; set; }

            [Argument("b"), IsRequired("a")] // Is Required If A
            public string ValueB { get; set; }
        }
    }
}
