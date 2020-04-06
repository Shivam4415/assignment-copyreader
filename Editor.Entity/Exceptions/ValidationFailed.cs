using System;
using System.Net;
using System.Runtime.Serialization;

namespace Editor.Entity.Exceptions
{
    public class ValidationFailed : Exception
    {
        public HttpStatusCode _code = HttpStatusCode.BadRequest;
        public HttpStatusCode StatusCode
        {
            get
            {
                return _code;
            }
            set
            {
                _code = value;
            }
        }
        /// <summary>
        /// Just create the exception
        /// </summary>
        public ValidationFailed()
    : base()
        {
        }

        /// <summary>
        /// Create the exception with description
        /// </summary>
        /// <param name="message">Exception description</param>
        public ValidationFailed(String message)
    : base(message)
        {
        }

        /// <summary>
        /// Create the exception with description and inner cause
        /// </summary>
        /// <param name="message">Exception description</param>
        /// <param name="innerException">Exception inner cause</param>
        public ValidationFailed(String message, Exception innerException)
    : base(message, innerException)
        {
        }

        /// <summary>
        /// Create the exception from serialized data.
        /// Usual scenario is when exception is occured somewhere on the remote workstation
        /// and we have to re-create/re-throw the exception on the local machine
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Serialization context</param>
        protected ValidationFailed(SerializationInfo info, StreamingContext context)
    : base(info, context)
        {
        }
    }

}