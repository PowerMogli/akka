#region using directives

using System;

using Akka.Actor;
using Akka.Configuration;

using Naip.CommunicationMessages.Messages;

#endregion

namespace Akka.Net_Remote_Client
{
    internal class Program
    {
        #region Private Methods

        private static void Main()
        {
            Config config = ConfigurationFactory.ParseString(AkkaSettings.Config);

            ActorSystem actorSystem = ActorSystem.Create("MyClient", config);

            IActorRef client = actorSystem.ActorOf<RemoteWorker>("RemoteWorker");

            while (true)
            {
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();

                if (consoleKeyInfo.Key == ConsoleKey.Enter)
                {
                    client.Tell(new ChangePrescriptionStatusToIssued(Guid.NewGuid(), string.Empty));
                }
            }
        }

        #endregion
    }
}