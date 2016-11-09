#region using directives

using System;

#endregion

namespace Naip.CommunicationMessages.Messages
{
    /// <summary>
    ///     Class to change the order prescription status to not issued
    /// </summary>
    public class ChangePrescriptionStatusToIssued 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChangePrescriptionStatusToIssued" /> class.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        /// <param name="userName">Name of the user.</param>
        public ChangePrescriptionStatusToIssued(Guid orderId, string userName)
        {
            OrderId = orderId;
            UserName = userName;
        }

        /// <summary>
        ///     Gets the order identifier.
        /// </summary>
        /// <value>
        ///     The order identifier.
        /// </value>
        public Guid OrderId { get; }

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        public string UserName { get; }
    }
}