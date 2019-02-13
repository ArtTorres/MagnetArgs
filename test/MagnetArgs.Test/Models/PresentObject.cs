using System;
using System.Collections.Generic;
using System.Text;

namespace MagnetArgs.Test.Models
{
    class PresentObject : MagnetSet
    {
        [Arg("present-value"), IfPresent]
        public bool PresentValue { get; set; }

        [Arg("raise-ex"), IfPresent]
        public int RaiseException { get; set; }
    }
}
