## 🚨 Repository Deprecated – No Longer Maintained

> **Important:** This SDK is no longer maintained.

This repository (`Messages C# SDK`) has not been actively maintained for several years and is now officially **deprecated**. No further updates, bug fixes, or support will be provided.

If you're building applications that integrate with the Sinch MessageMedia Messaging API, we recommend using direct REST API calls instead. You can find the complete and up-to-date API documentation here:  
👉 [MessageMedia Messaging REST API Docs](https://messagemedia.github.io/documentation/#tag/Messages)

The source code remains available under the [Apache 2.0 License](https://www.apache.org/licenses/LICENSE-2.0). Feel free to fork and update it to suit your needs.


# MessageMedia Messages C# SDK
[![Travis Build Status](https://api.travis-ci.org/messagemedia/messages-csharp-sdk.svg?branch=master)](https://travis-ci.org/messagemedia/messages-csharp-sdk)
[![Pull Requests Welcome](https://img.shields.io/badge/PRs-welcome-brightgreen.svg?style=flat)](http://makeapullrequest.com)
[![NuGet version](https://badge.fury.io/nu/MessageMediaDev.SDK.Messages.svg)](https://badge.fury.io/nu/MessageMediaDev.SDK.Messages)

The MessageMedia Messages API provides a number of endpoints for building powerful two-way messaging applications. In v 2.0, the SDK is now .NET compatible and available as a standard solution library.

![Isometric](https://i.imgur.com/jJeHwf5.png)

## Table of Contents
* [Authentication](#closed_lock_with_key-authentication)
* [Errors](#interrobang-errors)
* [Information](#newspaper-information)
  * [Slack and Mailing List](#slack-and-mailing-list)
  * [Bug Reports](#bug-reports)
  * [Contributing](#contributing)
* [Installation](#star-installation)
* [Get Started](#clapper-get-started)
* [API Documentation](#closed_book-api-documentation)
* [Need help?](#confused-need-help)
* [License](#page_with_curl-license)

## :closed_lock_with_key: Authentication

Authentication is done via API keys. Sign up at https://developers.messagemedia.com/register/ to get your API keys. Username is the key and password is the secret.

Requests are authenticated using HTTP Basic Auth or HMAC. Provide your API key as the auth_user_name and API secret as the auth_password.

If you set an HMAC username and password the controller will use HMAC authentication. Otherwise it will assume basic auth. The file to input these credentials into is the Configuration.cs file you will find in the main directory of the solution. 

## :interrobang: Errors

Our API returns standard HTTP success or error status codes. For errors, we will also include extra information about what went wrong encoded in the response as JSON. The most common status codes are listed below.

#### HTTP Status Codes

| Code      | Title       | Description |
|-----------|-------------|-------------|
| 400 | Invalid Request | The request was invalid |
| 401 | Unauthorized | Your API credentials are invalid |
| 403 | Disabled feature | Feature not enabled |
| 404 | Not Found |	The resource does not exist |
| 50X | Internal Server Error | An error occurred with our API |

## :newspaper: Information

#### Slack and Mailing List

If you have any questions, comments, or concerns, please join our Slack channel:
https://developers.messagemedia.com/collaborate/slack/

Alternatively you can email us at:
developers@messagemedia.com

#### Bug reports

If you discover a problem with the SDK, we would like to know about it. You can raise an [issue](https://github.com/messagemedia/signingkeys-nodejs-sdk/issues) or send an email to: developers@messagemedia.com

#### Contributing

We welcome your thoughts on how we could best provide you with SDKs that would simplify how you consume our services in your application. You can fork and create pull requests for any features you would like to see or raise an [issue](https://github.com/messagemedia/signingkeys-nodejs-sdk/issues)

## :star: Installation
The code provided uses the Newtonsoft Json.NET NuGet Package. If the automatic NuGet package restore
is enabled, these dependencies will be installed automatically. Therefore,
you will need internet access for build.

"This library requires Visual Studio 2017 for compilation."
1. Open the solution (MessageMediaMessages.sln) file.
2. Invoke the build process using `Ctrl+Shift+B` shortcut key or using the `Build` menu as shown below.

![Building SDK using Visual Studio](https://apidocs.io/illustration/cs?step=buildSDK&workspaceFolder=MessageMediaMessages-CSharp&workspaceName=MessageMediaMessages&projectName=MessageMediaMessages.Standard)

## :clapper: Get Started

The build process generates a portable class library, which can be used like a normal class library. The generated library is compatible with Windows Forms, Windows RT, Windows Phone 8,
Silverlight 5, Xamarin iOS, Xamarin Android and Mono. More information on how to use can be found at the [MSDN Portable Class Libraries documentation](http://msdn.microsoft.com/en-us/library/vstudio/gg597391%28v=vs.100%29.aspx).

The following section explains how to use the MessageMediaMessages library in a new console project.

### 1. Starting a new project

For starting a new project, right click on the current solution from the *solution explorer* and choose  ``` Add -> New Project ```.

![Add a new project in the existing solution using Visual Studio](https://apidocs.io/illustration/cs?step=addProject&workspaceFolder=MessageMediaMessages-CSharp&workspaceName=MessageMediaMessages&projectName=MessageMediaMessages.Standard)

Next, choose "Console Application", provide a ``` TestConsoleProject ``` as the project name and click ``` OK ```.

![Create a new console project using Visual Studio](https://apidocs.io/illustration/cs?step=createProject&workspaceFolder=MessageMediaMessages-CSharp&workspaceName=MessageMediaMessages&projectName=MessageMediaMessages.Standard)

### 2. Set as startup project

The new console project is the entry point for the eventual execution. This requires us to set the ``` TestConsoleProject ``` as the start-up project. To do this, right-click on the  ``` TestConsoleProject ``` and choose  ``` Set as StartUp Project ``` form the context menu.

![Set the new cosole project as the start up project](https://apidocs.io/illustration/cs?step=setStartup&workspaceFolder=MessageMediaMessages-CSharp&workspaceName=MessageMediaMessages&projectName=MessageMediaMessages.Standard)

### 3. Add reference of the library project

In order to use the MessageMediaMessages library in the new project, first we must add a projet reference to the ``` TestConsoleProject ```. First, right click on the ``` References ``` node in the *solution explorer* and click ``` Add Reference... ```.

![Open references of the TestConsoleProject](https://apidocs.io/illustration/cs?step=addReference&workspaceFolder=MessageMediaMessages-CSharp&workspaceName=MessageMediaMessages&projectName=MessageMediaMessages.Standard)

Next, a window will be displayed where we must set the ``` checkbox ``` on ``` MessageMediaMessages.Standard ``` and click ``` OK ```. By doing this, we have added a reference of the ```MessageMediaMessages.Standard``` project into the new ``` TestConsoleProject ```.

![Add a reference to the TestConsoleProject](https://apidocs.io/illustration/cs?step=createReference&workspaceFolder=MessageMediaMessages-CSharp&workspaceName=MessageMediaMessages&projectName=MessageMediaMessages.Standard)

### 4. Write sample code

Once the ``` TestConsoleProject ``` is created, a file named ``` Program.cs ``` will be visible in the *solution explorer* with an empty ``` Main ``` method. This is the entry point for the execution of the entire solution.
Here, you can add code to initialize the client library and acquire the instance of a *Controller* class. Sample code to initialize the client library and using controller methods is given in the subsequent sections.

![Add a reference to the TestConsoleProject](https://apidocs.io/illustration/cs?step=addCode&workspaceFolder=MessageMediaMessages-CSharp&workspaceName=MessageMediaMessages&projectName=MessageMediaMessages.Standard)

## Initialization

API client can be initialized as following.

```csharp

MessageMediaMessagesClient client = new MessageMediaMessagesClient();
```

### Singleton Controllers


* [MessagesController](#messages_controller)
* [DeliveryReportsController](#delivery_reports_controller)
* [RepliesController](#replies_controller)

In this version of the SDK there are three "controllers" which are invoked as singletons which control the various actions. For example: the singleton instance of the ``` MessagesController ``` class can be accessed from the API Client.

```csharp
MessagesController messages = client.Messages;
```
### Send an SMS
Destination numbers (`destination_number`) should be in the [E.164](http://en.wikipedia.org/wiki/E.164) format. For example, `+61491570156`.

```csharp
using System;
using MessageMedia.Messages;
using MessageMedia.Messages.Models;
using MessageMedia.Messages.Exceptions;
using MessageMedia.Messages.Controllers;
using System.Collections.Generic;

namespace TestConosleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            String API_KEY = "your api key";
            String API_SECRET = "your api secret";
            boolean HMAC = false;
            MessageMediaMessagesClient client = new MessageMediaMessagesClient(API_KEY, API_SECRET, HMAC);

            MessagesController messages = client.Messages;


            SendMessagesRequest body = new SendMessagesRequest();
            body.Messages = new List<Message>();

            Message body_messages_0 = new Message();
            body_messages_0.Content = "Hello world!";
            body_messages_0.DestinationNumber = "+614<number>";
            body.Messages.Add(body_messages_0);


            try
            {
                Models.SendMessagesResponse result = messages.SendMessagesAsync(body).Result;
                Console.WriteLine(result);
            }
            catch (APIException e)
            {
                Console.WriteLine(e.Message + e.ResponseCode + e.HttpContext.ToString());
            };
        }
    }
}
```

### Send an MMS
Destination numbers (`destination_number`) should be in the [E.164](http://en.wikipedia.org/wiki/E.164) format. For example, `+61491570156`.

```csharp
using System;
using MessageMedia.Messages;
using MessageMedia.Messages.Models;
using MessageMedia.Messages.Exceptions;
using MessageMedia.Messages.Controllers;
using System.Collections.Generic;

namespace TestConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            String API_KEY = "your api key";
            String API_SECRET = "your api secret";
            boolean HMAC = false;
            MessageMediaMessagesClient client = new MessageMediaMessagesClient(API_KEY, API_SECRET, HMAC);

            MessagesController messages = client.Messages;


            SendMessagesRequest body = new SendMessagesRequest();
            body.Messages = new List<Message>();

            Message body_messages_0 = new Message();
            body_messages_0.Content = "Hello world!";
            body_messages_0.DestinationNumber = "+614<number>";
            body_messages_0.Format = FormatEnum.MMS;
            body_messages_0.Subject = "This is an MMS message";
            body_messages_0.Media = new List<string>()
        {
            "https://upload.wikimedia.org/wikipedia/commons/6/6a/L80385-flash-superhero-logo-1544.png"
        };
            body.Messages.Add(body_messages_0);


            try
            {
                dynamic result = messages.SendMessagesAsync(body).Result;
                Console.WriteLine(result);
            }
            catch (APIException e)
            {
                Console.WriteLine(e.Message + e.ResponseCode + e.HttpContext.ToString());
            };
        }
    }
}
```

### Get Status of a Message
You can get a messsage ID from a sent message by looking at the `message_id` from the response of the above example.

string messageId = "messageId";

```csharp
using System;
using MessageMedia.Messages;
using MessageMedia.Messages.Models;
using MessageMedia.Messages.Exceptions;
using MessageMedia.Messages.Controllers;
using System.Collections.Generic;

namespace TestConosleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            String API_KEY = "your api key";
            String API_SECRET = "your api secret";
            boolean HMAC = false;
            MessageMediaMessagesClient client = new MessageMediaMessagesClient(API_KEY, API_SECRET, HMAC);

            MessagesController messages = client.Messages;


            SendMessagesRequest body = new SendMessagesRequest();
            body.Messages = new List<Message>();

            Message body_messages_0 = new Message();
            body_messages_0.Content = "Hello world!";
            body_messages_0.DestinationNumber = "+614<number>";
            body_messages_0.Format = FormatEnum.MMS;
            body_messages_0.Subject = "This is an MMS message";
            body_messages_0.Media = new List<string>()
        {
            "https://upload.wikimedia.org/wikipedia/commons/6/6a/L80385-flash-superhero-logo-1544.png"
        };
            body.Messages.Add(body_messages_0);


            try
            {
                dynamic result = messages.SendMessagesAsync(body).Result;

                string msgs = Newtonsoft.Json.JsonConvert.SerializeObject(result);
                Console.WriteLine(msgs);
               
                Guid messageId = result.Messages[0].MessageId;

                dynamic result2 = messages.GetMessageStatus(messageId + "");

                string msg = Newtonsoft.Json.JsonConvert.SerializeObject(result2);
                Console.WriteLine(msg);
            }
            catch (APIException e)
            {
                Console.WriteLine(e.Message + e.ResponseCode + e.HttpContext.ToString());
            };
        }
    }
}
```

### Get replies to a message
You can check for replies that are sent to your messages


The singleton instance of the ``` RepliesController ``` class can be accessed from the API Client.

```csharp
using System;
using MessageMedia.Messages;
using MessageMedia.Messages.Models;
using MessageMedia.Messages.Exceptions;
using MessageMedia.Messages.Controllers;
using System.Collections.Generic;

namespace TestConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            String API_KEY = "your api key";
            String API_SECRET = "your api secret";
            boolean HMAC = false;
            MessageMediaMessagesClient client = new MessageMediaMessagesClient(API_KEY, API_SECRET, HMAC);

            MessagesController messages = client.Messages;

            RepliesController replies = client.Replies;

            try
            {
                dynamic result = replies.CheckReplies();

                string msgs = Newtonsoft.Json.JsonConvert.SerializeObject(result);
                Console.WriteLine(msgs);


            }
            catch (APIException e)
            {
                Console.WriteLine(e.Message + e.ResponseCode + e.HttpContext.ToString());
            };

        }
    }
}
```

### Check Delivery Reports
This endpoint allows you to check for delivery reports to inbound and outbound messages.

```csharp
using System;
using MessageMedia.Messages;
using MessageMedia.Messages.Models;
using MessageMedia.Messages.Exceptions;
using MessageMedia.Messages.Controllers;
using System.Collections.Generic;

namespace TestConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            String API_KEY = "your api key";
            String API_SECRET = "your api secret";
            boolean HMAC = false;
            MessageMediaMessagesClient client = new MessageMediaMessagesClient(API_KEY, API_SECRET, HMAC);

            MessagesController messages = client.Messages;

            RepliesController replies = client.Replies;

            DeliveryReportsController deliveryReports = client.DeliveryReports;


            try
            {
                dynamic result = deliveryReports.CheckDeliveryReports();

                string msgs = Newtonsoft.Json.JsonConvert.SerializeObject(result);
                Console.WriteLine(msgs);

            }
            catch (APIException e)
            {
                Console.WriteLine(e.Message + e.ResponseCode + e.HttpContext.ToString());
            };

        }
    }
}
```

### Confirm Delivery Reports
This endpoint allows you to mark delivery reports as confirmed so they're no longer returned by the Check Delivery Reports function.

```csharp
using System;
using MessageMedia.Messages;
using MessageMedia.Messages.Models;
using MessageMedia.Messages.Exceptions;
using MessageMedia.Messages.Controllers;
using System.Collections.Generic;

namespace TestConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            String API_KEY = "your api key";
            String API_SECRET = "your api secret";
            boolean HMAC = false;
            MessageMediaMessagesClient client = new MessageMediaMessagesClient(API_KEY, API_SECRET, HMAC);
            DeliveryReportsController deliveryReports = client.DeliveryReports;
            
            ConfirmDeliveryReportsAsReceivedRequest body = new ConfirmDeliveryReportsAsReceivedRequest();
            body.DeliveryReportIds = new List<string>();
            body.DeliveryReportIds.Add("011dcead-6988-4ad6-a1c7-6b6c68ea628d");
            body.DeliveryReportIds.Add("3487b3fa-6586-4979-a233-2d1b095c7718");
            body.DeliveryReportIds.Add("ba28e94b-c83d-4759-98e7-ff9c7edb87a1");
            
            try 
            {
                dynamic result = deliveryReports.ConfirmDeliveryReportsAsReceivedAsync(body).Result;
            }
            catch (APIException e){};   
        }
    }
}
```

### Check credits remaining (Prepaid accounts only)
This endpoint allows you to check for credits remaining on your prepaid account.

```csharp
using System;
using MessageMedia.Messages;
using MessageMedia.Messages.Models;
using MessageMedia.Messages.Exceptions;
using MessageMedia.Messages.Controllers;
using System.Collections.Generic;

namespace TestConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            String API_KEY = "your api key";
            String API_SECRET = "your api secret";
            boolean HMAC = false;
            MessageMediaMessagesClient client = new MessageMediaMessagesClient(API_KEY, API_SECRET, HMAC);
            MessagesController messages = client.Messages;
            
            try 
            {
                dynamic result = messages.CheckCreditsRemainingAsync().Result;
            }
            catch (APIException e){};   
        }
    }
}
```

## :closed_book: API Reference Documentation
Check out the [full API documentation](https://developers.messagemedia.com/code/messages-api-documentation/) for more detailed information.

## :confused: Need help?
Please contact developer support at developers@messagemedia.com or check out the developer portal at [developers.messagemedia.com](https://developers.messagemedia.com/)

## :page_with_curl: License
Apache License. See the [LICENSE](LICENSE) file.
