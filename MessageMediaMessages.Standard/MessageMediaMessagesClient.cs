/*
 * MessageMediaMessages.Standard
 *
 * This file was automatically generated for MessageMedia by APIMATIC v2.0 ( https://apimatic.io ).
 */
using System;
using MessageMedia.Messages.Controllers;
using MessageMedia.Messages.Http.Client;
using MessageMedia.Messages.Utilities;

namespace MessageMedia.Messages
{
    public partial class MessageMediaMessagesClient
    {

        /// <summary>
        /// Singleton access to Messages controller
        /// </summary>
        public MessagesController Messages
        {
            get
            {
                return MessagesController.Instance;
            }
        }

        /// <summary>
        /// Singleton access to DeliveryReports controller
        /// </summary>
        public DeliveryReportsController DeliveryReports
        {
            get
            {
                return DeliveryReportsController.Instance;
            }
        }

        /// <summary>
        /// Singleton access to Replies controller
        /// </summary>
        public RepliesController Replies
        {
            get
            {
                return RepliesController.Instance;
            }
        }
        /// <summary>
        /// The shared http client to use for all API calls
        /// </summary>
        public IHttpClient SharedHttpClient
        {
            get
            {
                return BaseController.ClientInstance;
            }
            set
            {
                BaseController.ClientInstance = value;
            }        
        }
        #region Constructors
        /// <summary>
        /// Default constructor
        /// </summary>
        public MessageMediaMessagesClient() { }
		/// <summary>
        /// Client initialization constructor
        /// </summary>
        public MessageMediaMessagesClient(string UserName, string Password, bool hmacAuthentication = false)
        {
            if (!hmacAuthentication)
            {
                Configuration.BasicAuthUserName = UserName;
                Configuration.BasicAuthPassword = Password;
            }
            else
            {
                Configuration.HmacAuthUserName = UserName;
                Configuration.HmacAuthPassword = Password;
            }
        }
        #endregion
    }
}