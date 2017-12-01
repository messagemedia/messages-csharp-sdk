/*
 * MessageMediaMessages.PCL
 *
 */
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

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