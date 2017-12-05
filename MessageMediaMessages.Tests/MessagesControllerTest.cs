/*
 * MessageMediaMessages.Tests
 *
 */
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using APIMATIC.SDK.Common;
using MessageMedia.Messages.Helpers;
using NUnit.Framework;
using MessageMedia.Messages.Controllers;
using MessageMedia.Messages.Models;

namespace MessageMedia.Messages
{
	[TestFixture]
    public class MessagesControllerTest : ControllerTestBase
    {
        /// <summary>
        /// Controller instance (for all tests)
        /// </summary>
        private static IMessagesController controller;

        /// <summary>
        /// Setup test class
        /// </summary>
        [SetUp]
        public static void SetUpClass()
        {
            controller = GetClient().Messages;
        }

        /// <summary>
        /// Submit one or more (up to 100 per request) SMS or text to voice messages for delivery.
        ///The most basic message has the following structure:
        ///```json
        ///{
        ///    "messages": [
        ///        {
        ///            "content": "My first message!",
        ///            "destination_number": "+61491570156"
        ///        }
        ///    ]
        ///}
        ///```
        ///More advanced delivery features can be specified by setting the following properties in a message:
        ///- ```callback_url``` A URL can be included with each message to which Webhooks will be pushed to
        ///  via a HTTP POST request. Webhooks will be sent if and when the status of the message changes as
        ///  it is processed (if the delivery report property of the request is set to ```true```) and when replies
        ///  are received. Specifying a callback URL is optional.
        ///- ```content``` The content of the message. This can be a Unicode string, up to 5,000 characters long.
        ///  Message content is required.
        ///- ```delivery_report``` Delivery reports can be requested with each message. If delivery reports are requested, a webhook
        ///  will be submitted to the ```callback_url``` property specified for the message (or to the webhooks)
        ///  specified for the account every time the status of the message changes as it is processed. The
        ///  current status of the message can also be retrieved via the Delivery Reports endpoint of the
        ///  Messages API. Delivery reports are optional and by default will not be requested.
        ///- ```destination_number``` The destination number the message should be delivered to. This should be specified in E.164
        ///  international format. For information on E.164, please refer to http://en.wikipedia.org/wiki/E.164.
        ///  A destination number is required.
        ///- ```format``` The format specifies which format the message will be sent as, ```SMS``` (text message)
        ///  or ```TTS``` (text to speech). With ```TTS``` format, we will call the destination number and read out the
        ///  message using a computer generated voice. Specifying a format is optional, by default ```SMS``` will be used.
        ///- ```source_number``` A source number may be specified for the message, this will be the number that
        ///  the message appears from on the handset. By default this feature is _not_ available and will be ignored
        ///  in the request. Please contact <support@messagemeda.com> for more information. Specifying a source
        ///  number is optional and a by default a source number will be assigned to the message.
        ///- ```source_number_type``` If a source number is specified, the type of source number may also be
        ///  specified. This is recommended when using a source address type that is not an internationally
        ///  formatted number, available options are ```INTERNATIONAL```, ```ALPHANUMERIC``` or ```SHORTCODE```. Specifying a
        ///  source number type is only valid when the ```source_number``` parameter is specified and is optional.
        ///  If a source number is specified and no source number type is specified, the source number type will be
        ///  inferred from the source number, however this may be inaccurate.
        ///- ```scheduled``` A message can be scheduled for delivery in the future by setting the scheduled property.
        ///  The scheduled property expects a date time specified in ISO 8601 format. The scheduled time must be
        ///  provided in UTC and is optional. If no scheduled property is set, the message will be delivered immediately.
        ///- ```message_expiry_timestamp``` A message expiry timestamp can be provided to specify the latest time
        ///  at which the message should be delivered. If the message cannot be delivered before the specified
        ///  message expiry timestamp elapses, the message will be discarded. Specifying a message expiry 
        ///  timestamp is optional.
        ///- ```metadata``` Metadata can be included with the message which will then be included with any delivery
        ///  reports or replies matched to the message. This can be used to create powerful two-way messaging
        ///  applications without having to store persistent data in the application. Up to 10 key / value metadata data
        ///  pairs can be specified in a message. Each key can be up to 100 characters long, and each value up to 
        ///  256 characters long. Specifying metadata for a message is optional.
        ///The response body of a successful POST request to the messages endpoint will include a ```messages```
        ///property which contains a list of all messages submitted. The list of messages submitted will
        ///reflect the list of messages included in the request, but each message will also contain two new
        ///properties, ```message_id``` and ```status```. The returned message ID will be a 36 character UUID
        ///which can be used to check the status of the message via the Get Message Status endpoint. The status
        ///of the message which reflect the status of the message at submission time which will always be
        ///```queued```. See the Delivery Reports section of this documentation for more information on message
        ///statues.
        ///*Note: when sending multiple messages in a request, all messages must be valid for the request to be successful.
        ///If any messages in the request are invalid, no messages will be sent.* 
        /// </summary>
        [Test]
        public async Task TestSendMessages1() 
        {
            // Parameters for the API call
            SendMessagesRequest body = APIHelper.JsonDeserialize<Models.SendMessagesRequest>("{    \"messages\": [        {            \"callback_url\": \"https://my.callback.url.com\",            \"content\": \"My first message\",            \"destination_number\": \"+61491570156\",            \"delivery_report\": true,            \"format\": \"SMS\",            \"message_expiry_timestamp\": \"2016-11-03T11:49:02.807Z\",            \"metadata\": {                \"key1\": \"value1\",                \"key2\": \"value2\"            },            \"scheduled\": \"2016-11-03T11:49:02.807Z\",            \"source_number\": \"+61491570157\",            \"source_number_type\": \"INTERNATIONAL\"        },        {            \"callback_url\": \"https://my.callback.url.com\",            \"content\": \"My second message\",            \"destination_number\": \"+61491570158\",            \"delivery_report\": true,            \"format\": \"SMS\",            \"message_expiry_timestamp\": \"2016-11-03T11:49:02.807Z\",            \"metadata\": {                \"key1\": \"value1\",                \"key2\": \"value2\"            },            \"scheduled\": \"2016-11-03T11:49:02.807Z\",            \"source_number\": \"+61491570159\",            \"source_number_type\": \"INTERNATIONAL\"        }    ]}");

            // Perform API call
            SendMessagesResponse result = null;

            try
            {
                result = await controller.CreateSendMessagesAsync(body);
            }
            catch(APIException) {};

            // Test response code
            Assert.AreEqual(202, httpCallBackHandler.Response.StatusCode, "Status should be 202");

            // Test headers
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Content-Type", null);

            Assert.IsTrue(TestHelper.AreHeadersProperSubsetOf(headers, httpCallBackHandler.Response.Headers), "Headers should match");

            // Test whether the captured response is as we expected
            Assert.IsNotNull(result, "Result should exist");

			dynamic messages  = result.Messages;//JObject.Parse(TestHelper.ConvertStreamToString(httpCallBackHandler.Response.RawBody));
			int count = (int)messages.Count;

			Assert.AreEqual(count, 2);

			dynamic firstMessage = messages[0];
			dynamic secondMessage = messages[1];

			AssertSendMessageResponseValid(firstMessage, "SMS", "My first message", "https://my.callback.url.com", true, "+61491570156", "+61491570157", "queued");
			AssertSendMessageResponseValid(secondMessage, "SMS", "My second message", "https://my.callback.url.com", true, "+61491570158", "+61491570159", "queued");
		}

		/// <summary>
		/// Make sure our SDK fails when passed an invalid account id
		/// </summary>
		/// <returns></returns>
		[Test]
		public async Task TestConfirmDeliveryReportsAsReceivedWithInvalidAccount()
		{
			// Parameters for the API call
			SendMessagesRequest body = APIHelper.JsonDeserialize<SendMessagesRequest>("{    \"messages\": [        {            \"callback_url\": \"https://my.callback.url.com\",            \"content\": \"My first message\",            \"destination_number\": \"+61491570156\",            \"delivery_report\": true,            \"format\": \"SMS\",            \"message_expiry_timestamp\": \"2016-11-03T11:49:02.807Z\",            \"metadata\": {                \"key1\": \"value1\",                \"key2\": \"value2\"            },            \"scheduled\": \"2016-11-03T11:49:02.807Z\",            \"source_number\": \"+61491570157\",            \"source_number_type\": \"INTERNATIONAL\"        },        {            \"callback_url\": \"https://my.callback.url.com\",            \"content\": \"My second message\",            \"destination_number\": \"+61491570158\",            \"delivery_report\": true,            \"format\": \"SMS\",            \"message_expiry_timestamp\": \"2016-11-03T11:49:02.807Z\",            \"metadata\": {                \"key1\": \"value1\",                \"key2\": \"value2\"            },            \"scheduled\": \"2016-11-03T11:49:02.807Z\",            \"source_number\": \"+61491570159\",            \"source_number_type\": \"INTERNATIONAL\"        }    ]}");

			// Perform API call
			dynamic result = null;

			try
			{
				result = await controller.CreateSendMessagesAsync(body, "INVALID ACCOUNT");
			}
			catch (APIException apiException)
			{
				Assert.AreEqual("HTTP Response Not OK. {\"message\":\"Invalid account 'INVALID ACCOUNT' in header Account\"}\n", apiException.Message);
				Assert.AreEqual(403, httpCallBackHandler.Response.StatusCode, "Status should be 403");
			};
		}

		private void AssertSendMessageResponseValid(dynamic message, string expectedFormat, string expectedContent, string expectedCallbackUrl, 
			bool expectedDeliveryReport, string expectedDestinationNumber, string expectedSourceNumber, string expectedStatus)
		{
			var format = (string)message.format;
			var content = (string)message.content;
			var callbackUrl = (string)message.callback_url;
			var deliveryReport = (bool)message.delivery_report;
			var destinationNumber = (string)message.destination_number;
			var sourceNumber = (string)message.source_number;
			var status = (string)message.status;
			var messageId = (string)message.message_id;
			var messageExpiry = (string)message.message_expiry_timestamp;
			var scheduled = (string)message.scheduled;

			Assert.AreEqual(format, expectedFormat, "Format should match exactly (string literal match)");
			Assert.AreEqual(content, expectedContent, "Content should match exactly (string literal match)");
			Assert.AreEqual(callbackUrl, expectedCallbackUrl, "Callback URL should match exactly (string literal match)");
			Assert.AreEqual(deliveryReport, expectedDeliveryReport, "Delivery Report should match exactly (boolean match)");
			Assert.AreEqual(destinationNumber, expectedDestinationNumber, "Destination Number should match exactly (string literal match)");
			Assert.AreEqual(sourceNumber, expectedSourceNumber, "Source Number should match exactly (string literal match)");
			Assert.AreEqual(status, expectedStatus, "Status should match exactly (string literal match)");

			// note, these are non-deterministic, so we only check for their existence.
			Assert.IsNotEmpty(messageId, "Message ID should not be empty.");
			Assert.IsNotEmpty(messageExpiry, "Message Expiry should not be empty.");
			Assert.IsNotEmpty(scheduled, "Scheduled time should not be empty.");

			DateTime date;
			bool canParse = DateTime.TryParse(messageExpiry, out date);

			Assert.IsTrue(canParse, "Message Expiry must be a valid DateTime");

			canParse = DateTime.TryParse(scheduled, out date);
			Assert.IsTrue(canParse, "Scheduled time must be a valid DateTime");

			JObject metadata = message.metadata as JObject;

			Assert.IsNotNull(metadata, "Metadata must not be null.");

			var metadataCount = metadata.Count;

			Assert.AreEqual(metadataCount, 2, "Metadata must have two children.");

			var firstKey = ((dynamic)metadata).key1;
			var secondKey = ((dynamic)metadata).key2;

			Assert.IsNotNull(firstKey, "Metadata must contain key1.");
			Assert.IsNotNull(secondKey, "Metadata must contain key2.");

			var firstKeyValue = (string)firstKey;
			var secondKeyValue = (string)secondKey;

			Assert.AreEqual(firstKeyValue, "value1", "key1 must equal value1.");
			Assert.AreEqual(secondKeyValue, "value2", "key2 must equal value1.");
		}
	}
}