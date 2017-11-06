/*
 * MessageMediaMessages.PCL
 *
 * This file was automatically generated for MessageMedia by APIMATIC v2.0 ( https://apimatic.io )
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
using APIMATIC.SDK.Common;


namespace MessageMedia.Messages.Models
{
    public class ConfirmDeliveryReportsAsReceivedRequest11 : BaseModel 
    {
        // These fields hold the values for the public properties.
        private List<Guid> deliveryReportIds;

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("delivery_report_ids")]
        public List<Guid> DeliveryReportIds 
        { 
            get 
            {
                return this.deliveryReportIds; 
            } 
            set 
            {
                this.deliveryReportIds = value;
                onPropertyChanged("DeliveryReportIds");
            }
        }
    }
} 