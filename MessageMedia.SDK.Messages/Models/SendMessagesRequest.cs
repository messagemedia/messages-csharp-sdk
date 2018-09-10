/*
 * MessageMediaMessages.PCL
 *
 */

using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json;

namespace MessageMedia.Messages.Models
{
    public class SendMessagesRequest : BaseModel
    {
        // These fields hold the values for the public properties.
        private IList<Message> messages;

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("messages")]
        public IList<Message> Messages
        {
            get { return this.messages; }
            set
            {
                this.messages = value;
                onPropertyChanged("Messages");
            }
        }
    }
}