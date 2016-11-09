#region using directives

using Akka.Actor;
using Akka.Persistence;

using Naip.CommunicationMessages.Messages;

#endregion

namespace Akka.Net_Remote_Client
{
    internal class RemoteWorker : AtLeastOnceDeliveryReceiveActor
    {
        #region Fields

        private readonly ActorPath _actorPath = ActorPath.Parse("akka.ssl.tcp://MyServer@{HOST}:{PORT}/user/MyServerActor");

        #endregion

        #region Construction

        public RemoteWorker()
        {
            IActorRef self = Self;
            Context.System.ActorSelection(_actorPath)
                   .Ask<ActorIdentity>(new Identify(null))
                   .PipeTo(self);

            Command<ActorIdentity>(actorIdentity =>
            {
                if (actorIdentity?.Subject == null)
                {
                    Log.Error($"Remote actor could not be located on scm2.0-server.");

                    return;
                }

                Context.Watch(actorIdentity.Subject);
            });

            Recover<ChangePrescriptionStatusToIssued>(msg => Deliver(_actorPath, deliveryId => new ReliableDeliveryEnvelope<ChangePrescriptionStatusToIssued>(msg, deliveryId)));

            Recover<ChangePrescriptionStatusToNotIssued>(msg => Deliver(_actorPath, deliveryId => new ReliableDeliveryEnvelope<ChangePrescriptionStatusToNotIssued>(msg, deliveryId)));

            Command<ChangePrescriptionStatusToIssued>(msg =>
            {
                Persist(msg, changeMessage =>
                {
                    Deliver(
                        _actorPath,
                        messageId => new ReliableDeliveryEnvelope<ChangePrescriptionStatusToIssued>(new ChangePrescriptionStatusToIssued(changeMessage.OrderId, msg.UserName), messageId));
                });
            });

            Command<ChangePrescriptionStatusToNotIssued>(msg =>
            {
                Persist(msg, changeMessage =>
                {
                    Deliver(
                        _actorPath,
                        messageId => new ReliableDeliveryEnvelope<ChangePrescriptionStatusToNotIssued>(new ChangePrescriptionStatusToNotIssued(changeMessage.OrderId, msg.UserName, string.Empty), messageId));
                });
            });

            Command<UnconfirmedWarning>(msg =>
            {
                foreach (UnconfirmedDelivery unconfirmedDelivery in msg.UnconfirmedDeliveries)
                {
                    ConfirmDelivery(unconfirmedDelivery.DeliveryId);

                    DeleteMessages(unconfirmedDelivery.DeliveryId);
                }
            });

            Command<ReliableDeliveryAck>(ack =>
            {
                ConfirmDelivery(ack.MessageId);

                DeleteMessages(ack.MessageId);
            });
        }

        #endregion

        #region  Properties

        public override string PersistenceId => Context.Self.Path.Name;

        #endregion
    }
}