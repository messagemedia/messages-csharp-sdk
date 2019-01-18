# MessageMedia Messages C# SDK
[![Pull Requests Welcome](https://img.shields.io/badge/PRs-welcome-brightgreen.svg?style=flat)](http://makeapullrequest.com)

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

###

API client can be initialized as following.

```csharp

MessageMediaMessagesClient client = new MessageMediaMessagesClient();
```

# Class Reference

## <a name="list_of_controllers"></a>List of Controllers

* [MessagesController](#messages_controller)
* [DeliveryReportsController](#delivery_reports_controller)
* [RepliesController](#replies_controller)

## <a name="messages_controller"></a>![Class: ](https://apidocs.io/img/class.png "MessageMedia.Messages.Controllers.MessagesController") MessagesController

### Get singleton instance

The singleton instance of the ``` MessagesController ``` class can be accessed from the API Client.

```csharp
MessagesController messages = client.Messages;
```
### Send an SMS
Destination numbers (`destination_number`) should be in the [E.164](http://en.wikipedia.org/wiki/E.164) format. For example, `+61491570156`.

var body = new Models.SendMessagesRequest();

Models.SendMessagesResponse result = await messages.SendMessages(body);

### Send an MMS
Destination numbers (`destination_number`) should be in the [E.164](http://en.wikipedia.org/wiki/E.164) format. For example, `+61491570156`.

### Get Status of a Message
You can get a messsage ID from a sent message by looking at the `message_id` from the response of the above example.

string messageId = "messageId";

Models.GetMessageStatusResponse result = await messages.GetMessageStatus(messageId);

### Get replies to a message
You can check for replies that are sent to your messages


The singleton instance of the ``` RepliesController ``` class can be accessed from the API Client.

```csharp
RepliesController replies = client.Replies;
```


Models.CheckRepliesResponse result = await replies.CheckReplies();

### Check Delivery Reports
This endpoint allows you to check for delivery reports to inbound and outbound messages.

DeliveryReportsController deliveryReports = client.DeliveryReports;

Models.CheckDeliveryReportsResponse result = await deliveryReports.CheckDeliveryReports();


## :closed_book: API Reference Documentation
Check out the [full API documentation](https://developers.messagemedia.com/code/messages-api-documentation/) for more detailed information.

## :confused: Need help?
Please contact developer support at developers@messagemedia.com or check out the developer portal at [developers.messagemedia.com](https://developers.messagemedia.com/)

## :page_with_curl: License
Apache License. See the [LICENSE](LICENSE) file.
