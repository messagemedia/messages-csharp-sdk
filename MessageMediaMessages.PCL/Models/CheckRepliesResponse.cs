/*
 * MessageMediaMessages.PCL
 *
 * This file was automatically generated for MessageMedia by APIMATIC v2.0 ( https://apimatic.io )
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
using APIMATIC.SDK.Common;


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