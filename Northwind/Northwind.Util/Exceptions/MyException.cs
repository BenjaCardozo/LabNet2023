using System;
using System.Runtime.Serialization;

namespace Northwind.Util.Exceptions
{
    public class MyException : Exception
    {
        public MyException() : base() { }
        public MyException(string message) : base(message) { }
        public MyException(string message, Exception innerException) : base(message, innerException) { }
        protected MyException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
