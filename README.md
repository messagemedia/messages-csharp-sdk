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
            // Configure your credentials (Note, these can be pulled from the environment variables as well)
            String basicAuthUserName = "YOUR_API_KEY";
            String basicAuthPassword = "YOUR_API_SECRET";
            bool useHmacAuthentication = false; //Change this to true if you are using HMAC keys
            
            // Instantiate the client
            MessageMediaMessagesClient client = new MessageMediaMessagesClient(basicAuthUserName, basicAuthPassword, useHmacAuthentication);
            IMessagesController messages = client.Messages;

            // Perform API call
            string bodyValue = @"{
                                   ""messages"":[
                                      {
                                         ""content"":""Greetings from MessageMedia!"",
                                         ""destination_number"":""YOUR_MOBILE_NUMBER""
                                      }
                                   ]
                                }";

            var body = Newtonsoft.Json.JsonConvert.DeserializeObject<MessageMedia.Messages.Models.SendMessagesRequest>(bodyValue);

            MessageMedia.Messages.Models.SendMessagesResponse result = messages.CreateSendMessages(body);
            Console.WriteLine(result.Messages);
            Console.ReadKey();
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
            // Configure your credentials (Note, these can be pulled from the environment variables as well)
            String basicAuthUserName = "YOUR_API_KEY";
            String basicAuthPassword = "YOUR_API_SECRET";
            bool useHmacAuthentication = false; //Change this to true if you are using HMAC keys
            
            // Instantiate the client
            MessageMediaMessagesClient client = new MessageMediaMessagesClient(basicAuthUserName, basicAuthPassword, useHmacAuthentication);
            IMessagesController messages = client.Messages;

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
            // Configure your credentials (Note, these can be pulled from the environment variables as well)
            String basicAuthUserName = "YOUR_API_KEY";
            String basicAuthPassword = "YOUR_API_SECRET";
            bool useHmacAuthentication = false; //Change this to true if you are using HMAC keys
            
            // Instantiate the client
            MessageMediaMessagesClient client = new MessageMediaMessagesClient(basicAuthUserName, basicAuthPassword, useHmacAuthentication);
            IRepliesController replies = client.Replies;

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
            // Configure your credentials (Note, these can be pulled from the environment variables as well)
            String basicAuthUserName = "YOUR_API_KEY";
            String basicAuthPassword = "YOUR_API_SECRET";
            bool useHmacAuthentication = false; //Change this to true if you are using HMAC keys
            
            // Instantiate the client
            MessageMediaMessagesClient client = new MessageMediaMessagesClient(basicAuthUserName, basicAuthPassword, useHmacAuthentication);
            IDeliveryReportsController deliveryReports = client.DeliveryReports;

            MessageMedia.Messages.Models.CheckDeliveryReportsResponse result = deliveryReports.GetCheckDeliveryReports();

            string msg = Newtonsoft.Json.JsonConvert.SerializeObject(result);
            Console.WriteLine(msg);
        }
    }
}
```

## 📕 Documentation
Check out the [full API documentation](DOCUMENTATION.md) for more detailed information.

## 😕 Need help?
Please contact developer support at developers@messagemedia.com or check out the developer portal at [developers.messagemedia.com](https://developers.messagemedia.com/)

## 📃 License
Apache License. See the [LICENSE](LICENSE) file.
