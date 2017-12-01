/*
 * MessageMediaMessages.PCL
 *
 */
using Newtonsoft.Json;

namespace MessageMedia.Messages.Models
{
	public class CancelScheduledMessageRequest : BaseModel 
    {
        // These fields hold the values for the public properties.
        private string status;

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("status")]
        public string Status 
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
    }
} 