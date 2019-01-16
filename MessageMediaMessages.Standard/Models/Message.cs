/*
 * MessageMediaMessages.Standard
 *
 * This file was automatically generated for MessageMedia by APIMATIC v2.0 ( https://apimatic.io ).
 */
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using MessageMedia.Messages;
using MessageMedia.Messages.Utilities;


namespace MessageMedia.Messages.Models
{
    public class Message : BaseModel 
    {
        // These fields hold the values for the public properties.
        private string callbackUrl;
        private string content;
        private string destinationNumber;
        private bool? deliveryReport = false;
        private Models.FormatEnum? format;
        private DateTime? messageExpiryTimestamp;
        private object metadata;
        private DateTime? scheduled;
        private string sourceNumber;
        private Models.SourceNumberTypeEnum? sourceNumberType;
        private Guid? messageId;
        private Models.StatusEnum? status;
        private List<string> media;
        private string subject;

        /// <summary>
        /// URL replies and delivery reports to this message will be pushed to
        /// </summary>
        [JsonProperty("callback_url")]
        public string CallbackUrl 
        { 
            get 
            {
                return this.callbackUrl; 
            } 
            set 
            {
                if (value != null){
                    this.callbackUrl = value;
                    onPropertyChanged("CallbackUrl");
                }

            }
        }

        /// <summary>
        /// Content of the message
        /// </summary>
        [JsonProperty("content")]
        public string Content 
        { 
            get 
            {
                return this.content; 
            } 
            set 
            {
                this.content = value;
                onPropertyChanged("Content");
            }
        }

        /// <summary>
        /// Destination number of the message
        /// </summary>
        [JsonProperty("destination_number")]
        public string DestinationNumber 
        { 
            get 
            {
                return this.destinationNumber; 
            } 
            set 
            {
                this.destinationNumber = value;
                onPropertyChanged("DestinationNumber");
            }
        }

        /// <summary>
        /// Request a delivery report for this message
        /// </summary>
        [JsonProperty("delivery_report")]
        public bool? DeliveryReport 
        { 
            get 
            {
                return this.deliveryReport; 
            } 
            set 
            {
                this.deliveryReport = value;
                onPropertyChanged("DeliveryReport");
            }
        }

        /// <summary>
        /// Format of message, SMS or TTS (Text To Speech).
        /// </summary>
        [JsonProperty("format", ItemConverterType = typeof(StringValuedEnumConverter))]
        public Models.FormatEnum? Format 
        { 
            get 
            {
                return this.format; 
            } 
            set 
            {
                this.format = value;
                onPropertyChanged("Format");
            }
        }

        /// <summary>
        /// Date time after which the message expires and will not be sent
        /// </summary>
        [JsonConverter(typeof(IsoDateTimeConverter))]
        [JsonProperty("message_expiry_timestamp")]
        public DateTime? MessageExpiryTimestamp 
        { 
            get 
            {
                return this.messageExpiryTimestamp; 
            } 
            set 
            {
                this.messageExpiryTimestamp = value;
                onPropertyChanged("MessageExpiryTimestamp");
            }
        }

        /// <summary>
        /// Metadata for the message specified as a set of key value pairs, each key can be up to 100 characters long and each value can be up to 256 characters long
        /// ```
        /// {
        ///    "myKey": "myValue",
        ///    "anotherKey": "anotherValue"
        /// }
        /// ```
        /// </summary>
        [JsonProperty("metadata")]
        public object Metadata 
        { 
            get 
            {
                return this.metadata; 
            } 
            set 
            {
                this.metadata = value;
                onPropertyChanged("Metadata");
            }
        }

        /// <summary>
        /// Scheduled delivery date time of the message
        /// </summary>
        [JsonConverter(typeof(IsoDateTimeConverter))]
        [JsonProperty("scheduled")]
        public DateTime? Scheduled 
        { 
            get 
            {
                return this.scheduled; 
            } 
            set 
            {
                this.scheduled = value;
                onPropertyChanged("Scheduled");
            }
        }

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("source_number")]
        public string SourceNumber 
        { 
            get 
            {
                return this.sourceNumber; 
            } 
            set 
            {
                this.sourceNumber = value;
                onPropertyChanged("SourceNumber");
            }
        }

        /// <summary>
        /// Type of source address specified, this can be INTERNATIONAL, ALPHANUMERIC or SHORTCODE
        /// </summary>
        [JsonProperty("source_number_type", ItemConverterType = typeof(StringValuedEnumConverter))]
        public Models.SourceNumberTypeEnum? SourceNumberType 
        { 
            get 
            {
                return this.sourceNumberType; 
            } 
            set 
            {
                this.sourceNumberType = value;
                onPropertyChanged("SourceNumberType");
            }
        }

        /// <summary>
        /// Unique ID of this message
        /// </summary>
        [JsonProperty("message_id")]
        public Guid? MessageId 
        { 
            get 
            {
                return this.messageId; 
            } 
            set 
            {
                this.messageId = value;
                onPropertyChanged("MessageId");
            }
        }

        /// <summary>
        /// The status of the message
        /// </summary>
        [JsonProperty("status", ItemConverterType = typeof(StringValuedEnumConverter))]
        public Models.StatusEnum? Status 
        { 
            get 
            {
                return this.status; 
            } 
            set 
            {
                this.status = value;
                onPropertyChanged("Status");
            }
        }

        /// <summary>
        /// The media is used to specify the url of the media file that you are trying to send. Supported file formats include png, jpeg and gif. format parameter must be set to MMS for this to work.
        /// </summary>
        [JsonProperty("media")]
        public List<string> Media 
        { 
            get 
            {
                return this.media; 
            } 
            set 
            {
                this.media = value;
                onPropertyChanged("Media");
            }
        }

        /// <summary>
        /// The subject field is used to denote subject of the MMS message and has a maximum size of 64 characters long
        /// </summary>
        [JsonProperty("subject")]
        public string Subject 
        { 
            get 
            {
                return this.subject; 
            } 
            set 
            {
                this.subject = value;
                onPropertyChanged("Subject");
            }
        }
    }
} 