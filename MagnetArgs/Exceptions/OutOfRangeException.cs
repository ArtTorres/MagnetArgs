﻿using System;

namespace MagnetArgs
{
    public class OutOfRangeException : MagnetException
    {
        public OutOfRangeException()
        {
        }

        public OutOfRangeException(string message)
            : base(message)
        {
        }

        public OutOfRangeException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
