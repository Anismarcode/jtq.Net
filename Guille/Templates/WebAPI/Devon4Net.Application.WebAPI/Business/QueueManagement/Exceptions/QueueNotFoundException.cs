using Devon4Net.Infrastructure.Common.Exceptions;

namespace Devon4Net.Application.WebAPI.Business.QueueManagement.Exceptions
{
    /// <summary>
    /// Custom exception QueueNotFoundException
    /// </summary>
    [Serializable]
    public class QueueNotFoundException : Exception, IWebApiException
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
        /// Initializes a new instance of the <see cref="QueueNotFoundException"/> class.
        /// </summary>
        public QueueNotFoundException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueueNotFoundException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public QueueNotFoundException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueueNotFoundException"/> class.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public QueueNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueueNotFoundException"/> class.
        /// </summary>
        /// <param name="serializationInfo"></param>
        /// <param name="streamingContext"></param>
        protected QueueNotFoundException(System.Runtime.Serialization.SerializationInfo serializationInfo, System.Runtime.Serialization.StreamingContext streamingContext)
            : base(serializationInfo, streamingContext)
        {
        }
    }
}