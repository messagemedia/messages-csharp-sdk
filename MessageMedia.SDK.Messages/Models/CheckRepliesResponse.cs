/*
 * MessageMediaMessages.PCL
 *
 */
using Newtonsoft.Json;

namespace MessageMedia.Messages.Models
{
	public class CheckRepliesResponse : BaseModel 
    {
        // These fields hold the values for the public properties.
        private object replies;

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("replies")]
        public object Replies 
        { 
            get 
            {
                return this.replies; 
            } 
            set 
            {
                this.replies = value;
                onPropertyChanged("Replies");
            }
        }
    }
} 