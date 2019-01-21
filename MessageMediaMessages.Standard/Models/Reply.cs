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
    public class Reply : BaseModel 
    {
        // These fields hold the values for the public properties.
        private string callbackUrl;
        private string content;
        private DateTime? dateReceived;
        private string destinationNumber;
        private Guid? messageId;
        private object metadata;
        private Guid? replyId;
        private string sourceNumber;
        private Models.VendorAccountId vendorAccountId;

        /// <summary>
        /// The URL specified as the callback URL in the original submit message request
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
                this.callbackUrl = value;
                onPropertyChanged("CallbackUrl");
            }
        }

        /// <summary>
        /// Content of the reply
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
        /// Date time when the reply was received
        /// </summary>
        [JsonConverter(typeof(IsoDateTimeConverter))]
        [JsonProperty("date_received")]
        public DateTime? DateReceived 
        { 
            get 
            {
                return this.dateReceived; 
            } 
            set 
            {
                this.dateReceived = value;
                onPropertyChanged("DateReceived");
            }
        }

        /// <summary>
        /// Address from which this reply was sent to
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
        /// Unique ID of the original message
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
        /// Any metadata that was included in the original submit message request
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
        /// Unique ID of this reply
        /// </summary>
        [JsonProperty("reply_id")]
        public Guid? ReplyId 
        { 
            get 
            {
                return this.replyId; 
            } 
            set 
            {
                this.replyId = value;
                onPropertyChanged("ReplyId");
            }
        }

        /// <summary>
        /// Address from which this reply was received from
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
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("vendor_account_id")]
        public Models.VendorAccountId VendorAccountId 
        { 
            get 
            {
                return this.vendorAccountId; 
            } 
            set 
            {
                this.vendorAccountId = value;
                onPropertyChanged("VendorAccountId");
            }
        }
    }
} 