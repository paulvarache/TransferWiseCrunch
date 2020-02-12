using System;

namespace Transferwise.Utilities
{
    public class EnvVars
    {
        public string TransferwisePublicKey { get; set; }
        public string TransferwiseAccessToken { get; internal set; }
        public string EmailBusConnectionString { get; internal set; }
        public string EmailBusName { get; internal set; }

        public static EnvVars FromEnv()
        {
            var env = new EnvVars();

            env.TransferwisePublicKey = Environment.GetEnvironmentVariable("TRANSFERWISE_PUBLIC_KEY");
            env.TransferwiseAccessToken = Environment.GetEnvironmentVariable("TRANSFERWISE_ACCESS_TOKEN");
            env.EmailBusConnectionString = Environment.GetEnvironmentVariable("AzureWebJobsServiceBus");
            env.EmailBusName = Environment.GetEnvironmentVariable("EMAIL_BUS_NAME");

            return env;
        }
    }
}