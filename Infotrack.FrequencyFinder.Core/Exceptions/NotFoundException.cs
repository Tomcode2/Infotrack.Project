using System;

namespace Infotrack.FrequencyFinder.Core.Exceptions
{
    /// <summary>
    /// Base class for not found exceptions.
    /// </summary>
    public abstract class NotFoundException : Exception
    {
        public string ErrorCode { get; }
        public NotFoundException(string message) : base(message)
        {
        }
        public NotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
        public NotFoundException(string message, string errorCode) : base(message)
        {
            ErrorCode = errorCode;
        }
    }
}
