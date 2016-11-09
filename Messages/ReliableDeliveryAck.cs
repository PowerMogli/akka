namespace Naip.CommunicationMessages.Messages
{
    /// <summary>
    /// </summary>
    public class ReliableDeliveryAck
    {
        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="ReliableDeliveryAck"/> class.
        /// </summary>
        /// <param name="messageId">The message identifier.</param>
        public ReliableDeliveryAck(long messageId)
        {
            MessageId = messageId;
        }

        #endregion

        #region  Properties

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