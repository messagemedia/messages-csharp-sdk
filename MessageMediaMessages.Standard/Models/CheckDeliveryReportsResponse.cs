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
    public class CheckDeliveryReportsResponse : BaseModel 
    {
        // These fields hold the values for the public properties.
        private List<Models.DeliveryReport> deliveryReports;

        /// <summary>
        /// The oldest 100 unconfirmed delivery reports
        /// </summary>
        [JsonProperty("delivery_reports")]
        public List<Models.DeliveryReport> DeliveryReports 
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