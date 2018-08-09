
namespace MagnetArgs.Test.Models
{
    class RangeObject : MagnetArgument
    {
        [Arg("range-value"), Range(1, 10)]
        public int RangeValue { get; set; }
    }
}
