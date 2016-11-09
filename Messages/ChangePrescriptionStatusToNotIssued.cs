#region using directives

using System;

#endregion

namespace Naip.CommunicationMessages.Messages
{
    /// <summary>
    ///     Class to change the order prescription status to issued
    /// </summary>
    public class ChangePrescriptionStatusToNotIssued
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChangePrescriptionStatusToNotIssued" /> class.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        /// <param name="userName">Name of the user.</param>
        /// <param name="comment">The comment.</param>
        public ChangePrescriptionStatusToNotIssued(Guid orderId, string userName, string comment)
        {
            OrderId = orderId;
            UserName = userName;
            Comment = comment;
        }

        /// <summary>
        ///     Gets or sets the name of the user.
        /// </summary>
        /// <value>
        ///     The name of the user.
        /// </value>
        public string UserName { get; }

        /// <summary>
        ///     Gets the order identifier.
        /// </summary>
        /// <value>
        ///     The order identifier.
        /// </value>
        public Guid OrderId { get; }

        /// <summary>
        ///     Gets the comment.
        /// </summary>
        /// <value>
        ///     The comment.
        /// </value>
        public string Comment { get; }
    }
}