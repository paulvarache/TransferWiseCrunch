namespace Transferwise.Services
{
    public class TransferwiseClient : Transferwise.Services.Api.DefaultApi
    {
        public TransferwiseClient(string apiKey) : base()
        {
            Configuration.ApiKey.Add("Authorization", apiKey);
            Configuration.ApiKeyPrefix.Add("Authorization", "Bearer");
        }
    }
}