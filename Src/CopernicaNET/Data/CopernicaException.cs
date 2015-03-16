using System;
using System.Runtime.Serialization;

namespace Arlanet.CopernicaNET.Data
{
    public class CopernicaException : Exception
    {
        public CopernicaException()
        : base() { }
    
        public CopernicaException(string message)
            : base(message) { }
    
        public CopernicaException(string format, params object[] args)
            : base(string.Format(format, args)) { }
    
        public CopernicaException(string message, Exception innerException)
            : base(message, innerException) { }
    
        public CopernicaException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException) { }

        protected CopernicaException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }
}
