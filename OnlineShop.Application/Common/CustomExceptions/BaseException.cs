
namespace OnlineShop.Application.Common.CustomExceptions
{
    using System.Runtime.Serialization;

    [Serializable]
    public abstract class BaseException : Exception
    {
        /// <summary>
        ///     Base exception handler.
        /// </summary>
        protected BaseException()
        {
        }

        /// <summary>
        ///     Base exception handler.
        /// </summary>
        /// <param name="message">Exception message.</param>
        protected BaseException(string message)
            : base(message)
        {
        }

        protected BaseException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public string UiMessage { get; protected set; }
    }
}
