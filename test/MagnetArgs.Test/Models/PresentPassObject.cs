using System;
using System.Collections.Generic;
using System.Text;

namespace MagnetArgs.Test.Models
{
    class PresentPassObject : MagnetSet
    {
        [Arg("present-value"), IfPresent]
        public bool PresentValue { get; set; }

        [Arg("raise-ex"), IfPresent, Default("10")]
        public int RaiseException { get; set; }
    }
}
