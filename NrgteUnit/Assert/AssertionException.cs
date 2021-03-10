#nullable enable
using System;
using System.Runtime.Serialization;

namespace NrgteUnit.Assert {
    /// <summary>
    /// Class of exceptions thrown by assertion failures.
    /// </summary>
    public class AssertionException : Exception {
        public AssertionException() {}
        protected AssertionException(SerializationInfo info, StreamingContext context) : base(info, context) {}
        public AssertionException(string? message) : base(message) {}
        public AssertionException(string? message, Exception? innerException) : base(message, innerException) {}
    }
}