using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MessageMedia.Messages.Models
{
    public struct Message
    {
        [JsonProperty("message_id", NullValueHandling = NullValueHandling.Ignore)] public string MessageId { get; set; }

        /// <summary>
        /// Urls of the media files to send in the Message
        /// 
        /// <remarks>Only valid if the Format is MMS</remarks>
        /// </summary>
        [JsonProperty("media", NullValueHandling = NullValueHandling.Ignore)] public string[] Media { get; set; }

        /// <summary>
        /// Subject of the Message
        /// 
        /// <remarks>Only valid if the Format is MMS</remarks>
        /// </summary>
        [JsonProperty("subject", NullValueHandling = NullValueHandling.Ignore)] public string Subject { get; set; }

        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public MessageStatus? Status { get; set; }

        /// <summary>
        /// Replies and delivery reports for this message will be pushed to the URL"
        /// </summary>
        [JsonProperty("callback_url", NullValueHandling = NullValueHandling.Ignore)] public string CallbackUrl { get; set; }

        /// <summary>
        /// Content of the message
        /// <example>Hello world!</example>
        /// </summary>
        [JsonProperty("content", NullValueHandling = NullValueHandling.Ignore)] public string Content { get; set; }

        /// <summary>
        /// Destination number of the message
        /// <example>+61491570156</example>
        /// </summary>
        [JsonProperty("destination_number", NullValueHandling = NullValueHandling.Ignore)] public string DestinationNumber { get; set; }

        /// <summary>
        /// Request a delivery report for this message
        /// </summary>
        [JsonProperty("delivery_report", NullValueHandling = NullValueHandling.Ignore)] public bool DeliveryReport { get; set; }

        /// <summary>
        /// Format of message, SMS or TTS (Text To Speech).
        /// </summary>
        [JsonProperty("format", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public MessageFormat Format { get; set; }

        /// <summary>
        /// Date time after which the message expires and will not be sent
        /// </summary>
        [JsonProperty("message_expiry_timestamp", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? MessageExpiryTimestamp { get; set; }

        /// <summary>
        /// Metadata for the message specified as a set of key value pairs.
        /// 
        /// <remarks>Each key can be up to 100 characters long and each value can be up to 256 characters long.</remarks>
        /// </summary>
        [JsonProperty("metadata", NullValueHandling = NullValueHandling.Ignore)] public Dictionary<string, string> Metadata { get; set; }

        /// <summary>
        /// Scheduled delivery date time of the message
        /// </summary>
        [JsonProperty("scheduled", NullValueHandling = NullValueHandling.Ignore)] public DateTime? Scheduled { get; set; }

        /// <summary>
        /// Source of the message
        /// 
        /// <example>+61491570156</example>
        /// <example>Reminders</example>
        /// 
        /// <remarks>By default this feature is not available and will be ignored in the request. Please contact support@messagemedia.com for more information. Specifying a source number is optional and a by default a source number will be assigned to the message.</remarks>
        /// </summary>
        [JsonProperty("source_number", NullValueHandling = NullValueHandling.Ignore)] public string SourceNumber { get; set; }

        /// <summary>
        /// Type of source address specified
        /// </summary>
        [JsonProperty("source_number_type", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(NumberTypeConverter))]
        public NumberType? SourceNumberType { get; set; }
    }
}