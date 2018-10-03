using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MessageMedia.Messages.Models
{
    public struct Message
    {
        [JsonProperty("message_id")] public string MessageId { get; set; }

        /// <summary>
        /// Urls of the media files to send in the Message
        /// 
        /// <remarks>Only valid if the Format is MMS</remarks>
        /// </summary>
        [JsonProperty("media")] public string[] Media { get; set; }

        /// <summary>
        /// Subject of the Message
        /// 
        /// <remarks>Only valid if the Format is MMS</remarks>
        /// </summary>
        [JsonProperty("subject")] public string Subject { get; set; }

        [JsonProperty("status")] public MessageStatus Status { get; set; }

        /// <summary>
        /// Replies and delivery reports for this message will be pushed to the URL"
        /// </summary>
        [JsonProperty("callback_url")] public string CallbackUrl { get; set; }

        /// <summary>
        /// Content of the message
        /// <example>Hello world!</example>
        /// </summary>
        [JsonProperty("content")] public string Content { get; set; }

        /// <summary>
        /// Destination number of the message
        /// <example>+61491570156</example>
        /// </summary>
        [JsonProperty("destination_number")] public string DestinationNumber { get; set; }

        /// <summary>
        /// Request a delivery report for this message
        /// </summary>
        [JsonProperty("delivery_report")] public bool DeliveryReport { get; set; }

        /// <summary>
        /// Format of message, SMS or TTS (Text To Speech).
        /// </summary>
        [JsonProperty("format")] public MessageFormat Format { get; set; }

        /// <summary>
        /// Date time after which the message expires and will not be sent
        /// </summary>
        [JsonProperty("message_expiry_timestamp")]
        public DateTime MessageExpiryTimestamp { get; set; }

        /// <summary>
        /// Metadata for the message specified as a set of key value pairs.
        /// 
        /// <remarks>Each key can be up to 100 characters long and each value can be up to 256 characters long.</remarks>
        /// </summary>
        [JsonProperty("metadata")] public Dictionary<string, string> Metadata { get; set; }

        /// <summary>
        /// Scheduled delivery date time of the message
        /// </summary>
        [JsonProperty("scheduled")] public DateTime Scheduled { get; set; }

        /// <summary>
        /// Source of the message
        /// 
        /// <example>+61491570156</example>
        /// <example>Reminders</example>
        /// 
        /// <remarks>By default this feature is not available and will be ignored in the request. Please contact support@messagemedia.com for more information. Specifying a source number is optional and a by default a source number will be assigned to the message.</remarks>
        /// </summary>
        [JsonProperty("source_number")] public string SourceNumber { get; set; }

        /// <summary>
        /// Type of source address specified
        /// </summary>
        [JsonProperty("source_number_type")] public NumberType SourceNumberType { get; set; }
    }
}