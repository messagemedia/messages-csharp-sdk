/*
 * MessageMediaMessages.PCL
 *
 * This file was automatically generated for MessageMedia by APIMATIC v2.0 ( https://apimatic.io )
 */
using System;
using MessageMedia.Messages.Controllers;

namespace MessageMedia.Messages
{
    public partial interface IMessageMediaMessagesClient
    {

        /// <summary>
        /// Singleton access to Messages controller
        /// </summary>
        IMessagesController Messages { get;}

        /// <summary>
        /// Singleton access to DeliveryReports controller
        /// </summary>
        IDeliveryReportsController DeliveryReports { get;}

        /// <summary>
        /// Singleton access to Replies controller
        /// </summary>
        IRepliesController Replies { get;}

    }
}