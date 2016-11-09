namespace Naip.CommunicationMessages.Messages
{
    /// <summary>
    /// </summary>
    /// <typeparam name="TMessage">The type of the message.</typeparam>
    public class ReliableDeliveryEnvelope<TMessage>
    {
        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="ReliableDeliveryEnvelope{TMessage}"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="messageId">The message identifier.</param>
        public ReliableDeliveryEnvelope(TMessage message, long messageId)
        {
            Message = message;
            MessageId = messageId;
        }

        #endregion

        #region  Properties

        /// <summary>
        ///     Gets the message.
        /// </summary>
        /// <value>
        ///     The message.
        /// </value>
        public TMessage Message { get; }

        /// <summary>
        ///     Gets the message identifier.
        /// </summary>
        /// <value>
        ///     The message identifier.
        /// </value>
        public long MessageId { get; }

        #endregion
    }
}