using System;
using System.Collections.Generic;
using System.Text;

namespace MagnetArgs.Test.Models
{
    class ComplexObject : IronOre
    {
        [Chunk("required-value"), IsRequired]
        public string RequiredValue { get; set; }

        [Chunk("present-value"), IfPresent]
        public bool PresentValue { get; set; }

        [Chunk("default-value"), Default("25")]
        public int DefaultValue { get; set; }
    }
}
