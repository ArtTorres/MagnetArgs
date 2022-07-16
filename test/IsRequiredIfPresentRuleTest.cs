using System;
using Xunit;

namespace MagnetArgs.Test
{
    public class IsRequiredIfPresentRuleTest
    {
        [Fact]
        public void Eval_IsRequiredIfPresent_Rule_Success()
        {
            var args = new string[] {
                "--a", string.Empty,
                "--b", TestValues.STRING_VALUE
            };

            var obj = new RequiredIfPresentOnly();

            Magnet.Attract(args, obj);

            Assert.True(obj.ValueA);
            Assert.Equal(TestValues.STRING_VALUE, obj.ValueB);
        }

        [Fact]
        public void Eval_IsRequiredIfPresent_Rule_No_Arguments_Success()
        {
            var args = new string[0];

            var obj = new RequiredIfPresentOnly();

            Magnet.Attract(args, obj);

            Assert.False(obj.ValueA);
            Assert.Null(obj.ValueB);
        }

        [Fact]
        public void Eval_IsRequiredIfPresent_Rule_Exception()
        {
            var args = new string[] {
                "--a", string.Empty
            };

            var obj = new RequiredIfPresentOnly();

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
        public void Eval_IsRequiredIfPresent_Rule_Wrong_Target_Exception()
        {
            var args = new string[] {
                "--a", string.Empty
            };

            var obj = new RequiredIfPresentOnlyWrongTarget();

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
        public void Eval_IsRequired_Rule_With_IsRequiredIfPresent_Success()
        {
            var args = new string[] {
                "--a", TestValues.STRING_VALUE,
                "--b", TestValues.STRING_VALUE
            };

            var obj = new RequiredOnlyWithIsRequiredIfPresent();

            Magnet.Attract(args, obj);

            Assert.Equal(TestValues.STRING_VALUE, obj.ValueA);
            Assert.Equal(TestValues.STRING_VALUE, obj.ValueB);
        }

        [Fact]
        public void Eval_IsRequired_Rule_With_IsRequiredIfPresent_Failed()
        {
            var args = new string[0];

            var obj = new RequiredOnlyWithIsRequiredIfPresent();

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
        private class RequiredIfPresentOnly
        {
            [Argument("a"), IfPresent]
            public bool ValueA { get; set; }

            [Argument("b"), IsRequired, IfPresent("a")]
            public string ValueB { get; set; }
        }

        [Magnetizable]
        private class RequiredIfPresentOnlyWrongTarget
        {
            [Argument("a"), IfPresent]
            public bool ValueA { get; set; }

            [Argument("b"), IsRequired, IfPresent("c")]
            public string ValueB { get; set; }
        }

        [Magnetizable]
        private class RequiredOnlyWithIsRequiredIfPresent
        {
            [Argument("a"), IsRequired]
            public string ValueA { get; set; }

            [Argument("b"), IsRequired, IfPresent("a")]
            public string ValueB { get; set; }
        }
    }
}
