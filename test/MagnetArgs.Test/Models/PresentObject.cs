using System;
using System.Collections.Generic;
using System.Text;

namespace MagnetArgs.Test.Models
{
    class PresentObject : IronOre
    {
        [Chunk("present-value"), IfPresent]
        public bool PresentValue { get; set; }

        [Chunk("raise-ex"), IfPresent]
        public int RaiseException { get; set; }
    }
}
