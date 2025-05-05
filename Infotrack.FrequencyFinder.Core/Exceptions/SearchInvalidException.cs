using System;

namespace Infotrack.FrequencyFinder.Core.Exceptions
{
    /// <summary>
    /// Represents an exception that occurs when a search is invalid.
    /// </summary>
    public class SearchInvalidException : Exception
    {
        public string ErrorCode { get; }
        public SearchInvalidException(string message) : base(message)
        {
        }
        public SearchInvalidException(string message, Exception innerException) : base(message, innerException)
        {
        }
        public SearchInvalidException(string message, string errorCode) : base(message)
        {
            ErrorCode = errorCode;
        }
    }
}
