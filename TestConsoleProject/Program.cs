using System;
using MessageMedia.Messages;
using MessageMedia.Messages.Models;
using MessageMedia.Messages.Exceptions;
using MessageMedia.Messages.Controllers;
using System.Collections.Generic;

namespace TestConsoleProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Configuration.BaseUri = "https://api.messagemedia.com";

            Configuration.BasicAuthUserName = "Your basic auth key";
            Configuration.BasicAuthPassword = "You basic auth secret";

            MessageMediaMessagesClient client = new MessageMediaMessagesClient();

            MessagesController messages = client.Messages;


            SendMessagesRequest body = new SendMessagesRequest();
            body.Messages = new List<Message>();

            Message body_messages_0 = new Message();
            body_messages_0.Content = "Hello world!";
            body_messages_0.DestinationNumber = "+614<number>";
            body.Messages.Add(body_messages_0);


            try
            {
                dynamic result = messages.SendMessagesAsync(body).Result;
            }
            catch (APIException e) {
                Console.WriteLine(e.Message + e.ResponseCode + e.HttpContext.ToString());
            };
        }
    }
}
