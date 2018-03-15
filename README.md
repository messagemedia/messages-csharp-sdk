# MessageMedia Messages C# SDK
[![Travis Build Status](https://api.travis-ci.org/messagemedia/messages-csharp-sdk.svg?branch=master)](https://travis-ci.org/messagemedia/messages-csharp-sdk)
[![nuget](https://img.shields.io/badge/nuget-v1.1.1-blue.svg)](https://www.nuget.org/packages/MessageMedia.SDK.Messages/)

The MessageMedia Messages API provides a number of endpoints for building powerful two-way messaging applications.

## ⭐️ Installing via NuGet
Install via NuGet by:

PM> Install-Package MessageMedia.SDK.Messages

Alternatively, right-click on your solution and click "Manage NuGet Packages...", then click browse and search for MessageMedia.

Visual Studio Mac:
Project -> Add NuGet Packages -> Search for 'MessageMedia'

## 🎬 Get Started
It's easy to get started. Simply enter the API Key and secret you obtained from the [MessageMedia Developers Portal](https://developers.messagemedia.com) into the code snippet below and a mobile number you wish to send to.

### 🚀 Send an SMS
* Destination numbers (`destination_number`) should be in the [E.164](http://en.wikipedia.org/wiki/E.164) format. For example, `+61491570156`.
```csharp
using System;
using MessageMedia.Messages;
using MessageMedia.Messages.Controllers;
using MessageMedia.Messages.Models;

namespace TestCSharpSDK
{
    class Program
    {
        static void Main(string[] args)
        {
            // Instantiate the client
            MessageMediaMessagesClient client = new MessageMediaMessagesClient();
            IMessagesController messages = client.Messages;

            // Configure your credentials (Note, these can be pulled from the environment variables as well)
            Configuration.BasicAuthUserName = "YOUR_API_KEY";
            Configuration.BasicAuthPassword = "YOUR_API_SECRET";

            // Perform API call
            string bodyValue = @"{
                                   ""messages"":[
                                      {
                                         ""content"":""My first message"",
                                         ""destination_number"":""YOUR_MOBILE_NUMBER""
                                      }
                                   ]
                                }";

            var body = Newtonsoft.Json.JsonConvert.DeserializeObject<MessageMedia.Messages.Models.SendMessagesRequest>(bodyValue);

            MessageMedia.Messages.Models.SendMessagesResponse result = messages.CreateSendMessages(body);
        }
    }
}
```

### 🕓 Get Status of a Message
You can get a messsage ID from a sent message by looking at the `message_id` from the response of the above example.
```csharp
using System;
using MessageMedia.Messages;
using MessageMedia.Messages.Controllers;
using MessageMedia.Messages.Models;

namespace TestCSharpSDK
{
    class Program
    {
        static void Main(string[] args)
        {
            // Instantiate the client
            MessageMediaMessagesClient client = new MessageMediaMessagesClient();
            IMessagesController messages = client.Messages;


            // Configure your credentials (Note, these can be pulled from the environment variables as well)
            Configuration.BasicAuthUserName = "YOUR_API_KEY";
            Configuration.BasicAuthPassword = "YOUR_API_SECRET";

            string messageId = "YOUR_MESSAGE_ID";
            dynamic result = messages.GetMessageStatus(messageId);

            string msg = Newtonsoft.Json.JsonConvert.SerializeObject(result);
            Console.WriteLine(msg);
        }
    }
}
```

### 💬 Get replies to a message
You can check for replies that are sent to your messages
```csharp
using System;
using MessageMedia.Messages;
using MessageMedia.Messages.Controllers;
using MessageMedia.Messages.Models;

namespace TestCSharpSDK
{
    class Program
    {
        static void Main(string[] args)
        {
            // Instantiate the client
            MessageMediaMessagesClient client = new MessageMediaMessagesClient();
            IRepliesController replies = client.Replies;


            // Configure your credentials (Note, these can be pulled from the environment variables as well)
            Configuration.BasicAuthUserName = "YOUR_API_KEY";
            Configuration.BasicAuthPassword = "YOUR_API_SECRET";

            MessageMedia.Messages.Models.CheckRepliesResponse result = replies.GetCheckReplies();

            string msg = Newtonsoft.Json.JsonConvert.SerializeObject(result);
            Console.WriteLine(msg);
        }
    }
}
```

### ✅ Check Delivery Reports
This endpoint allows you to check for delivery reports to inbound and outbound messages.
```csharp
using System;
using MessageMedia.Messages;
using MessageMedia.Messages.Controllers;
using MessageMedia.Messages.Models;

namespace TestCSharpSDK
{
    class Program
    {
        static void Main(string[] args)
        {
            // Instantiate the client
            MessageMediaMessagesClient client = new MessageMediaMessagesClient();
            IDeliveryReportsController deliveryReports = client.DeliveryReports;


            // Configure your credentials (Note, these can be pulled from the environment variables as well)
            Configuration.BasicAuthUserName = "YOUR_API_KEY";
            Configuration.BasicAuthPassword = "YOUR_API_SECRET";

            MessageMedia.Messages.Models.CheckDeliveryReportsResponse result = deliveryReports.GetCheckDeliveryReports();

            string msg = Newtonsoft.Json.JsonConvert.SerializeObject(result);
            Console.WriteLine(msg);
        }
    }
}
```

## 📕 Documentation
The C# SDK Documentation can be viewed [here](DOCUMENTATION.md)

## 😕 Got Stuck?
Please contact developer support at developers@messagemedia.com or check out the developer portal at [developers.messagemedia.com](https://developers.messagemedia.com/)
