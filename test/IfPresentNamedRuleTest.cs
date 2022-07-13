/*
 Not implemented features tests
 */

using Xunit;

namespace MagnetArgs.Test
{
    public class IfPresentNamedRuleTest
    {
        public void Eval_IfPresentNamed_Rule_Success()
        {
            var args = new string[] {
                "--a",TestValues.STRING_VALUE
            };

            var obj = new IfPresentNamedOnly();

            Magnet.Attract(args, obj);

            Assert.Equal(TestValues.STRING_VALUE, obj.ValueA);
            Assert.True(obj.ValueB);
        }

        public void Eval_IfPresentNamed_Rule_Ignore_Success()
        {
            var args = new string[0];

            var obj = new IfPresentNamedOnly();

            Magnet.Attract(args, obj);

            Assert.Equal(string.Empty, obj.ValueA);
            Assert.False(obj.ValueB);
        }

        [Magnetizable]
        private class IfPresentNamedOnly
        {
            [Argument("a")]
            public string ValueA { get; set; }

            [Argument("b"), IfPresent("a")]
            public bool ValueB { get; set; }
        }
    }
}
