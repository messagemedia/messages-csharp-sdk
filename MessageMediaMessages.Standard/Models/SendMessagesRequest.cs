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
    public class SendMessagesRequest : BaseModel 
    {
        // These fields hold the values for the public properties.
        private List<Models.Message> messages;

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>

        [JsonProperty("messages")]
        public List<Models.Message> Messages 
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