
namespace MagnetArgs.Test.Models
{
    class RangeObject : MagnetOption
    {
        [Arg("range-value"), Range(1, 10)]
        public int RangeValue { get; set; }
    }
}
