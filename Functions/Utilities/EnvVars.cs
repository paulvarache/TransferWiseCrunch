using System;

namespace Transferwise.Utilities
{
    public class EnvVars
    {
        public string TransferwisePublicKey {get; set;}
        public string TransferwiseAccessToken { get; internal set; }

        public static EnvVars FromEnv()
        {
            var env = new EnvVars();

            env.TransferwisePublicKey = Environment.GetEnvironmentVariable("TRANSFERWISE_PUBLIC_KEY");
            env.TransferwiseAccessToken = Environment.GetEnvironmentVariable("TRANSFERWISE_ACCESS_TOKEN");

            return env;
        }
    }
}