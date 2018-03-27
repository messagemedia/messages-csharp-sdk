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
// Instantiate the client
MessageMediaMessagesClient client = new MessageMediaMessagesClient();
IRepliesController controller = client.Replies;

// Configure your credentials (Note, these can be pulled from the environment variables as well)
Configuration.BasicAuthUserName = "Your MessageMedia API Key here";
Configuration.BasicAuthPassword = "Your MessageMedia API Secret here";

// Perform API call
CheckRepliesResponse result = null;

try
{
    result = await controller.GetCheckRepliesAsync();
}
catch(APIException exception)
{
    Console.WriteLine("An error occured: " + exception.Message);
};
```

### Authentication
In order to setup authentication for the API client, you need the two of the following, depending on your preferred authentication method.

| Parameter | Description |
|-----------|-------------|
| basicAuthUserName | The username to use with basic authentication |
| basicAuthPassword | The password to use with basic authentication |
| hmacAuthUserName | The username to use with HMAC authentication |
| hmacAuthPassword | The password to use with HMAC authentication |

API client can be initialized using:

```csharp
// Configuration parameters and credentials
string hmacAuthUserName = "hmacAuthUserName"; // The username to use with HMAC authentication
string hmacAuthPassword = "hmacAuthPassword"; // The password to use with HMAC authentication
bool useHmacAuthentication = true;

MessageMediaMessagesClient client = new MessageMediaMessagesClient(basicAuthUserName, basicAuthPassword, useHmacAuthentication);
```
