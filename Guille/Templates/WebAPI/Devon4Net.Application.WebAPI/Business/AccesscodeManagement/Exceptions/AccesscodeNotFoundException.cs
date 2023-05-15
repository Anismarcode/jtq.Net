using Devon4Net.Infrastructure.Common.Exceptions;

namespace Devon4Net.Application.WebAPI.Business.AccescodeManagement.Exceptions
{
    /// <summary>
    /// Custom exception AccesscodeNotFoundException
    /// </summary>
    [Serializable]
    public class AccesscodeNotFoundException : Exception, IWebApiException
    {
        /// <summary>
        /// The forced http status code to be fired on the exception manager
        /// </summary>
        public int StatusCode => StatusCodes.Status404NotFound;

        /// <summary>
        /// Show the message on the response?
        /// </summary>
        public bool ShowMessage => true;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccesscodeNotFoundException"/> class.
        /// </summary>
        public AccesscodeNotFoundException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AccesscodeNotFoundException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public AccesscodeNotFoundException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AccesscodeNotFoundException"/> class.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public AccesscodeNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AccesscodeNotFoundException"/> class.
        /// </summary>
        /// <param name="serializationInfo"></param>
        /// <param name="streamingContext"></param>
        protected AccesscodeNotFoundException(System.Runtime.Serialization.SerializationInfo serializationInfo, System.Runtime.Serialization.StreamingContext streamingContext)
            : base(serializationInfo, streamingContext)
        {
        }
    }
}