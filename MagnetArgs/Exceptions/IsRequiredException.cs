using System;

namespace MagnetArgs
{
    public class IsRequiredException : MagnetException
    {
        public IsRequiredException()
        {
        }

        public IsRequiredException(string message)
            : base(message)
        {
        }

        public IsRequiredException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
