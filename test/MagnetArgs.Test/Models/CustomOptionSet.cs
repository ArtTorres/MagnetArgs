using System;
using System.Collections.Generic;
using System.Text;

namespace MagnetArgs.Test.Models
{
    class CustomOptionSet
    {
        [OptionSet]
        public CustomObject Custom { get; set; }

        [OptionSet]
        public ComplexObject Complex { get; set; }
    }
}
