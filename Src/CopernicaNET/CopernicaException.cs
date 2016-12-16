using System;
using System.Runtime.Serialization;

namespace Arlanet.CopernicaNET
{
    public class CopernicaException : Exception
    {
        public CopernicaException()
        {
            //Do nothing
        }

        public CopernicaException(string message)
            : base(message)
        {
            //Do nothing
        }

        public CopernicaException(string format, params object[] args)
            : base(string.Format(format, args))
        {
            //Do nothing
        }

        public CopernicaException(string message, Exception innerException)
            : base(message, innerException)
        {
            //Do nothing
        }

        public CopernicaException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException)
        {
            //Do nothing
        }

        protected CopernicaException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            //Do nothing
        }
    }
}
