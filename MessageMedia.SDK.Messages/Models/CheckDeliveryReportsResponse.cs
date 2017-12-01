/*
 * MessageMediaMessages.PCL
 *
 */
using Newtonsoft.Json;

namespace MessageMedia.Messages.Models
{
	public class CheckDeliveryReportsResponse : BaseModel 
    {
        // These fields hold the values for the public properties.
        private object deliveryReports;

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("delivery_reports")]
        public object DeliveryReports 
        { 
            get 
            {
                return this.deliveryReports; 
            } 
            set 
            {
                this.deliveryReports = value;
                onPropertyChanged("DeliveryReports");
            }
        }
    }
} 