/*
 * MessageMediaMessages.PCL
 *
 */
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MessageMedia.Messages.Models
{
	public class ConfirmDeliveryReportsAsReceivedRequest : BaseModel 
    {
        // These fields hold the values for the public properties.
        private List<string> deliveryReportIds;

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("delivery_report_ids")]
        public List<string> DeliveryReportIds 
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