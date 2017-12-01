/*
 * MessageMediaMessages.PCL
 *
 */

using Newtonsoft.Json;

namespace MessageMedia.Messages.Models
{
	public class SendMessagesRequest : BaseModel 
    {
        // These fields hold the values for the public properties.
        private object messages;

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("messages")]
        public object Messages 
        { 
            get 
            {
                return this.messages; 
            } 
            set 
            {
                this.messages = value;
                onPropertyChanged("Messages");
            }
        }
    }
} 