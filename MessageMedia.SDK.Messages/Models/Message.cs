using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MessageMedia.Messages.Models
{
    public struct Message
    {
        [JsonProperty("message_id")] public string MessageId { get; set; }

        [JsonProperty("media")] public string[] Media { get; set; }

        [JsonProperty("status")] public MessageStatus Status { get; set; }

        [JsonProperty("callback_url")] public string CallbackUrl { get; set; }

        [JsonProperty("content")] public string Content { get; set; }

        [JsonProperty("destination_number")] public string DestinationNumber { get; set; }

        [JsonProperty("delivery_report")] public bool DeliveryReport { get; set; }

        [JsonProperty("format")] public MessageFormat Format { get; set; }

        [JsonProperty("message_expiry_timestamp")]
        public DateTime MessageExpiryTimestamp { get; set; }

        [JsonProperty("metadata")] public Dictionary<string, string> Metadata { get; set; }

        [JsonProperty("scheduled")] public DateTime Scheduled { get; set; }

        [JsonProperty("source_number")] public string SourceNumber { get; set; }

        [JsonProperty("source_number_type")] public NumberType SourceNumberType { get; set; }
    }
}