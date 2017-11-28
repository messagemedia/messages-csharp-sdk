/*
 * MessageMediaMessages.PCL
 *
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