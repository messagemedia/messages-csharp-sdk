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
    public class CheckRepliesResponse : BaseModel 
    {
        // These fields hold the values for the public properties.
        private List<Models.Reply> replies;

        /// <summary>
        /// The oldest 100 unconfirmed replies
        /// </summary>
        [JsonProperty("replies")]
        public List<Models.Reply> Replies 
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