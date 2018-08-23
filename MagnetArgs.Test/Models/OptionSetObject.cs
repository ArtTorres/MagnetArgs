
namespace MagnetArgs.Test.Models
{
    class OptionSetObject
    {
        [OptionSet]
        public PresentPassObject PObject { get; set; }

        [OptionSet]
        public CustomObject CObject { get; set; }
    }
}
