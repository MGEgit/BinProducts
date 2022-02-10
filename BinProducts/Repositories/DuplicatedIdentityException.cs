using System;
using System.Runtime.Serialization;

namespace BinProducts.Repositories
{
    [Serializable]
    internal class DuplicatedIdentityException : Exception
    {
        public DuplicatedIdentityException()
        {
        }

        public DuplicatedIdentityException(string message) : base(message)
        {
        }

        public DuplicatedIdentityException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DuplicatedIdentityException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}