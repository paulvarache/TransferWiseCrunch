using System;
using Newtonsoft.Json;

namespace Transferwise.Models
{
    public class TransferwiseRequest
    {
        [JsonProperty("subscription_id")]
        public Guid SubscriptionId { get; set; }

        [JsonProperty("event_type")]
        public string EventType { get; set; }

        [JsonProperty("schema_version")]
        public string SchemaVersion { get; set; }

        [JsonProperty("sent_at")]
        public DateTime SentAt { get; set; }

        [JsonProperty("data")]
        public object Data { get; set; }
    }
}