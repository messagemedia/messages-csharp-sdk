/*
 * MessageMediaMessages.PCL
 *
 */
using System;
using MessageMedia.Messages.Controllers;
using APIMATIC.SDK.Http.Client;
using APIMATIC.SDK.Common;

namespace MessageMedia.Messages
{
    public partial class MessageMediaMessagesClient: IMessageMediaMessagesClient
    {

        /// <summary>
        /// Singleton access to Messages controller
        /// </summary>
        public IMessagesController Messages
        {
            get
            {
                return MessagesController.Instance;
            }
        }

        /// <summary>
        /// Singleton access to DeliveryReports controller
        /// </summary>
        public IDeliveryReportsController DeliveryReports
        {
            get
            {
                return DeliveryReportsController.Instance;
            }
        }

        /// <summary>
        /// Singleton access to Replies controller
        /// </summary>
        public IRepliesController Replies
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
        public MessageMediaMessagesClient(string basicAuthUserName, string basicAuthPassword, bool hmacAuthentication = false)
        {
			if(!hmacAuthentication)
			{
				Configuration.BasicAuthUserName = basicAuthUserName;
				Configuration.BasicAuthPassword = basicAuthPassword;
			}
			else
			{
				Configuration.HmacAuthUserName = basicAuthUserName;
				Configuration.HmacAuthPassword = basicAuthPassword;
			}
		}

		#endregion

	}
}