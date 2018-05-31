# MessageMedia Messages C# SDK
[![Travis Build Status](https://api.travis-ci.org/messagemedia/messages-csharp-sdk.svg?branch=master)](https://travis-ci.org/messagemedia/messages-csharp-sdk)
[![NuGet](https://img.shields.io/nuget/dt/MessageMedia.SDK.Messages.svg)](https://www.nuget.org/packages/MessageMedia.SDK.Messages/)

The MessageMedia Messages API provides a number of endpoints for building powerful two-way messaging applications.

![picture](http://i63.tinypic.com/33tox83.jpg)

## Getting Started

Make sure you install the NuGet package into your solution:

PM> Install-Package MessageMedia.SDK.Messages

Alternatively, right-click on your solution and click "Manage NuGet Packages...", then click browse and search for MessageMedia.

Next, register on [developers.messagemedia.com](https://developers.messagemedia.com/register/) to get your API credentials.

## Example Usage

Once you've installed the NuGet package, you need to configure your credentials.

```csharp
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
```
