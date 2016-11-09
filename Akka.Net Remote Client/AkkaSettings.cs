namespace Akka.Net_Remote_Client
{
    public class AkkaSettings
    {
        public static string Config = @"
            akka {  
                remote {
                    helios.tcp {
                        port = {PORT}
                        hostname = {HOSTNAME}
                        enable-ssl = true
                    }
                    helios.ssl {
                        enable-ssl = true
                        security {
                            protocol = ""TLSv1.2""
                        }                        
                    }
                }
                stdout-loglevel = DEBUG
                loglevel = DEBUG
                log-config-on-start = on
                actor {
                    debug {  
                        receive = on 
                        autoreceive = on
                        lifecycle = on
                        event-stream = on
                        unhandled = on
                    }
                    provider = ""Akka.Remote.RemoteActorRefProvider, Akka.Remote""
                    serializers {
                        wire = ""Akka.Serialization.WireSerializer, Akka.Serialization.Wire""
                    }
                    serialization-bindings {
                        ""System.Object"" = wire
                    }
                }
                persistence {
                    journal {
                        plugin = ""akka.persistence.journal.sql-server""
                        sql-server {
                            # qualified type name of the SQL Server persistence journal actor
                            class = ""Akka.Persistence.SqlServer.Journal.SqlServerJournal, Akka.Persistence.SqlServer""

                            # dispatcher used to drive journal actor
                            plugin-dispatcher = ""akka.actor.default-dispatcher""

                            # connection string used for database access
                            connection-string = ""data source=(local);initial catalog=SoftCareManagerWeb;integrated security=True;MultipleActiveResultSets=True;""

                            # default SQL commands timeout
                            connection-timeout = 30s

                            # SQL server schema name to table corresponding with persistent journal
                            schema-name = dbo

                            # SQL server table corresponding with persistent journal
                            table-name = EventJournal

                            # should corresponding journal table be initialized automatically
                            auto-initialize = on

                            # timestamp provider used for generation of journal entries timestamps
                            timestamp-provider = ""Akka.Persistence.Sql.Common.Journal.DefaultTimestampProvider, Akka.Persistence.Sql.Common""

                            # metadata table
                            metadata-table-name = Metadata
                        }
                    } 
                    snapshot-store {
                        # Absolute path to the snapshot plugin configuration entry used by
                        # persistent actor or view by default.
                        # Persistent actor or view can override `snapshotPluginId` method
                        # in order to rely on a different snapshot plugin.
                        # It is not mandatory to specify a snapshot store plugin.
                        # If you don't use snapshots you don't have to configure it.
                        # Note that Cluster Sharding is using snapshots, so if you
                        # use Cluster Sharding you need to define a snapshot store plugin.
                        plugin = """"
                    }
                }
            }";
    }
}