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
    public class DeliveryReport : BaseModel 
    {
        // These fields hold the values for the public properties.
        private string callbackUrl;
        private DateTime? dateReceived;
        private int? delay;
        private Guid? deliveryReportId;
        private Guid? messageId;
        private object metadata;
        private string originalText;
        private string sourceNumber;
        private Models.Status2Enum? status;
        private DateTime? submittedDate;
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
        /// The date and time at which this delivery report was generated in UTC.
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
        /// Deprecated, no longer in use
        /// </summary>
        [JsonProperty("delay")]
        public int? Delay 
        { 
            get 
            {
                return this.delay; 
            } 
            set 
            {
                this.delay = value;
                onPropertyChanged("Delay");
            }
        }

        /// <summary>
        /// Unique ID for this delivery report
        /// </summary>
        [JsonProperty("delivery_report_id")]
        public Guid? DeliveryReportId 
        { 
            get 
            {
                return this.deliveryReportId; 
            } 
            set 
            {
                this.deliveryReportId = value;
                onPropertyChanged("DeliveryReportId");
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
        /// Text of the original message.
        /// </summary>
        [JsonProperty("original_text")]
        public string OriginalText 
        { 
            get 
            {
                return this.originalText; 
            } 
            set 
            {
                this.originalText = value;
                onPropertyChanged("OriginalText");
            }
        }

        /// <summary>
        /// Address from which this delivery report was received
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
        /// The status of the message as per the delivery report
        /// </summary>
        [JsonProperty("status", ItemConverterType = typeof(StringValuedEnumConverter))]
        public Models.Status2Enum? Status 
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
        /// The date and time when the message status changed in UTC. For a delivered DR this may indicate the time at which the message was received on the handset.
        /// </summary>
        [JsonConverter(typeof(IsoDateTimeConverter))]
        [JsonProperty("submitted_date")]
        public DateTime? SubmittedDate 
        { 
            get 
            {
                return this.submittedDate; 
            } 
            set 
            {
                this.submittedDate = value;
                onPropertyChanged("SubmittedDate");
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