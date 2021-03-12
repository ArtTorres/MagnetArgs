using System;
using System.Collections.Generic;
using System.Text;

namespace MagnetArgs.Test.Models
{
    class PresentPassObject : IronOre
    {
        [Chunk("present-value"), IfPresent]
        public bool PresentValue { get; set; }

        [Chunk("raise-ex"), IfPresent, Default("10")]
        public int RaiseException { get; set; }
    }
}
