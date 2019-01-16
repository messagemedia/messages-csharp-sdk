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
    public class VendorAccountId : BaseModel 
    {
        // These fields hold the values for the public properties.
        private string vendorId;
        private string accountId;

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("vendor_id")]
        public string VendorId 
        { 
            get 
            {
                return this.vendorId; 
            } 
            set 
            {
                this.vendorId = value;
                onPropertyChanged("VendorId");
            }
        }

        /// <summary>
        /// The account used to submit the original message.
        /// </summary>
        [JsonProperty("account_id")]
        public string AccountId 
        { 
            get 
            {
                return this.accountId; 
            } 
            set 
            {
                this.accountId = value;
                onPropertyChanged("AccountId");
            }
        }
    }
} 