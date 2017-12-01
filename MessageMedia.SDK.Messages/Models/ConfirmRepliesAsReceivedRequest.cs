/*
 * MessageMediaMessages.PCL
 *
 */
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MessageMedia.Messages.Models
{
	public class ConfirmRepliesAsReceivedRequest : BaseModel 
    {
        // These fields hold the values for the public properties.
        private List<string> replyIds;

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("reply_ids")]
        public List<string> ReplyIds 
        { 
            get 
            {
                return this.replyIds; 
            } 
            set 
            {
                this.replyIds = value;
                onPropertyChanged("ReplyIds");
            }
        }
    }
} 