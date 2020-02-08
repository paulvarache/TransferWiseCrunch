using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Security.Cryptography;
using Transferwise.Utilities;
using Transferwise.Services.Model;
using Transferwise.Models;
using Transferwise.Services;
using Transferwise.Services.Client;
using System.Diagnostics;

namespace Functions
{
    public static class TransferUpdateEvents
    {
        private static EnvVars Env = EnvVars.FromEnv();
        private static TransferwiseClient Client = new TransferwiseClient(Env.TransferwiseAccessToken);

        [FunctionName("TransferUpdateEvents")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            if (req.Headers.TryGetValue("X-Test-Notification", out var isTestNotif))
            {
                return new OkResult();
            }
            if (!req.Headers.TryGetValue("X-Signature", out var signature))
            {
                return new BadRequestObjectResult("Missing X-Signature header");
            }

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

            var isValid = VerifySignature(Env.TransferwisePublicKey, signature, requestBody);

            if (!isValid)
            {
                return new BadRequestObjectResult("Could not validate the signature");
            }

            var payload = JsonConvert.DeserializeObject<TransferwiseRequest>(requestBody);

            switch (payload.EventType)
            {
                case TransferwiseEventTypes.StatusChange:
                    {
                        var data = JsonConvert.DeserializeObject<StateChange>(payload.Data.ToString());
                        return await HandleStatusChange(data);
                    }
                default:
                    return new BadRequestObjectResult($"Unknown event_type: {payload.EventType}");
            }
        }
        public static bool VerifySignature(string encodedPublicKey, string base64Signature, string payload)
        {
            RSACryptoServiceProvider provider = PEMKeyLoader.CryptoServiceProviderFromPublicKeyInfo(encodedPublicKey);

            // The signature is supposed to be encoded in base64 and the SHA1 checksum
            // of the message is computed against the UTF-8 representation of the message
            byte[] signature = System.Convert.FromBase64String(base64Signature);
            SHA1Managed sha = new SHA1Managed();
            byte[] data = System.Text.Encoding.UTF8.GetBytes(payload);

            return provider.VerifyData(data, sha, signature);
        }
        public static async Task<IActionResult> HandleStatusChange(StateChange data)
        {
            Console.WriteLine(data);
            try
            {
                var res = await Client.GetTransferByIdAsync(data.Resource.Id);
                Console.WriteLine(res);
                return new OkResult();
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling DefaultApi.GetTransferById: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
                return new OkResult();
            }
        }
    }
}
