/*
 * MessageMediaMessages.PCL
 *
 */
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Converters;
using APIMATIC.SDK.Common;
using APIMATIC.SDK.Http.Request;
using APIMATIC.SDK.Http.Response;
using APIMATIC.SDK.Http.Client;

namespace MessageMedia.Messages.Controllers
{
    public partial class MessagesController: BaseController, IMessagesController
    {
        #region Singleton Pattern

        //private static variables for the singleton pattern
        private static object syncObject = new object();
        private static MessagesController instance = null;

        /// <summary>
        /// Singleton pattern implementation
        /// </summary>
        internal static MessagesController Instance
        {
            get
            {
                lock (syncObject)
                {
                    if (null == instance)
                    {
                        instance = new MessagesController();
                    }
                }
                return instance;
            }
        }

        #endregion Singleton Pattern

        /// <summary>
        /// Cancel a scheduled message that has not yet been delivered.
        /// A scheduled message can be cancelled by updating the status of a message from ```scheduled```
        /// to ```cancelled```. This is done by submitting a PUT request to the messages endpoint using
        /// the message ID as a parameter (the same endpoint used above to retrieve the status of a message).
        /// The body of the request simply needs to contain a ```status``` property with the value set
        /// to ```cancelled```.
        /// ```json
        /// {
        ///     "status": "cancelled"
        /// }
        /// ```
        /// *Note: Only messages with a status of scheduled can be cancelled. If an invalid or non existent
        /// message ID parameter is specified in the request, then a HTTP 404 Not Found response will be 
        /// returned*
        /// </summary>
        /// <param name="messageId">Required parameter: Example: </param>
        /// <param name="body">Required parameter: Example: </param>
        /// <return>Returns the dynamic response from the API call</return>
        public dynamic UpdateCancelScheduledMessage(string messageId, Models.CancelScheduledMessageRequest body, string accountHeaderValue = null)
        {
            Task<dynamic> t = UpdateCancelScheduledMessageAsync(messageId, body);
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Cancel a scheduled message that has not yet been delivered.
        /// A scheduled message can be cancelled by updating the status of a message from ```scheduled```
        /// to ```cancelled```. This is done by submitting a PUT request to the messages endpoint using
        /// the message ID as a parameter (the same endpoint used above to retrieve the status of a message).
        /// The body of the request simply needs to contain a ```status``` property with the value set
        /// to ```cancelled```.
        /// ```json
        /// {
        ///     "status": "cancelled"
        /// }
        /// ```
        /// *Note: Only messages with a status of scheduled can be cancelled. If an invalid or non existent
        /// message ID parameter is specified in the request, then a HTTP 404 Not Found response will be 
        /// returned*
        /// </summary>
        /// <param name="messageId">Required parameter: Example: </param>
        /// <param name="body">Required parameter: Example: </param>
        /// <return>Returns the dynamic response from the API call</return>
        public async Task<dynamic> UpdateCancelScheduledMessageAsync(string messageId, Models.CancelScheduledMessageRequest body, string accountHeaderValue = null)
        {
            //the base uri for api requests
            string _baseUri = Configuration.BaseUri;

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v1/messages/{messageId}");

            //process optional template parameters
            APIHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "messageId", messageId }
            });

            //validate and preprocess url
            string _queryUrl = APIHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string,string>()
            {
                { "user-agent", "messagemedia-messages-csharp-sdk-1.0.0" },
                { "accept", "application/json" },
                { "content-type", "application/json; charset=utf-8" }
            };

			AddAccountHeaderTo(_headers, accountHeaderValue);

			//append body params
			var _body = APIHelper.JsonSerialize(body);

            //prepare the API call request to fetch the response
            HttpRequest _request = ClientInstance.PutBody(_queryUrl, _headers, _body, Configuration.BasicAuthUserName, Configuration.BasicAuthPassword);

            //invoke request and get response
            HttpStringResponse _response = (HttpStringResponse) await ClientInstance.ExecuteAsStringAsync(_request).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request,_response);

            //Error handling using HTTP status codes
            if (_response.StatusCode == 400)
                throw new APIException(@"", _context);

            if (_response.StatusCode == 404)
                throw new APIException(@"", _context);

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

            try
            {
                return APIHelper.JsonDeserialize<dynamic>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

        /// <summary>
        /// Retrieve the current status of a message using the message ID returned in the send messages end point.
        /// A successful request to the get message status endpoint will return a response body as follows:
        /// ```json
        /// {
        ///     "format": "SMS",
        ///     "content": "My first message!",
        ///     "metadata": {
        ///         "key1": "value1",
        ///         "key2": "value2"
        ///     },
        ///     "message_id": "877c19ef-fa2e-4cec-827a-e1df9b5509f7",
        ///     "callback_url": "https://my.callback.url.com",
        ///     "delivery_report": true,
        ///     "destination_number": "+61401760575",
        ///     "scheduled": "2016-11-03T11:49:02.807Z",
        ///     "source_number": "+61491570157",
        ///     "source_number_type": "INTERNATIONAL"
        ///     "message_expiry_timestamp": "2016-11-03T11:49:02.807Z",
        ///     "status": "enroute"
        /// }
        /// ```
        /// The status property of the response indicates the current status of the message. See the Delivery
        /// Reports section of this documentation for more information on message statues.
        /// *Note: If an invalid or non existent message ID parameter is specified in the request, then
        /// a HTTP 404 Not Found response will be returned*
        /// </summary>
        /// <param name="messageId">Required parameter: Example: </param>
        /// <return>Returns the dynamic response from the API call</return>
        public dynamic GetMessageStatus(string messageId, string accountHeaderValue = null)
        {
            Task<dynamic> t = GetMessageStatusAsync(messageId);
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Retrieve the current status of a message using the message ID returned in the send messages end point.
        /// A successful request to the get message status endpoint will return a response body as follows:
        /// ```json
        /// {
        ///     "format": "SMS",
        ///     "content": "My first message!",
        ///     "metadata": {
        ///         "key1": "value1",
        ///         "key2": "value2"
        ///     },
        ///     "message_id": "877c19ef-fa2e-4cec-827a-e1df9b5509f7",
        ///     "callback_url": "https://my.callback.url.com",
        ///     "delivery_report": true,
        ///     "destination_number": "+61401760575",
        ///     "scheduled": "2016-11-03T11:49:02.807Z",
        ///     "source_number": "+61491570157",
        ///     "source_number_type": "INTERNATIONAL"
        ///     "message_expiry_timestamp": "2016-11-03T11:49:02.807Z",
        ///     "status": "enroute"
        /// }
        /// ```
        /// The status property of the response indicates the current status of the message. See the Delivery
        /// Reports section of this documentation for more information on message statues.
        /// *Note: If an invalid or non existent message ID parameter is specified in the request, then
        /// a HTTP 404 Not Found response will be returned*
        /// </summary>
        /// <param name="messageId">Required parameter: Example: </param>
        /// <return>Returns the dynamic response from the API call</return>
        public async Task<dynamic> GetMessageStatusAsync(string messageId, string accountHeaderValue = null)
        {
            //the base uri for api requests
            string _baseUri = Configuration.BaseUri;
			string _methodUri = $@"/v1/messages/{messageId}";

			//prepare query string for API call
			StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v1/messages/{messageId}");

            //process optional template parameters
            APIHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "messageId", messageId }
            });

            //validate and preprocess url
            string _queryUrl = APIHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string,string>()
            {
                { "user-agent", "messagemedia-messages-csharp-sdk-1.0.0" },
                { "accept", "application/json" }
            };

			AddAccountHeaderTo(_headers, accountHeaderValue);

			//prepare the API call request to fetch the response
			HttpRequest _request = GetHttpRequest(_queryUrl, _headers);

            //invoke request and get response
            HttpStringResponse _response = (HttpStringResponse) await ClientInstance.ExecuteAsStringAsync(_request).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request,_response);

            //Error handling using HTTP status codes
            if (_response.StatusCode == 404)
                throw new APIException(@"", _context);

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

            try
            {
                return APIHelper.JsonDeserialize<dynamic>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

        /// <summary>
        /// Submit one or more (up to 100 per request) SMS or text to voice messages for delivery.
        /// The most basic message has the following structure:
        /// ```json
        /// {
        ///     "messages": [
        ///         {
        ///             "content": "My first message!",
        ///             "destination_number": "+61491570156"
        ///         }
        ///     ]
        /// }
        /// ```
        /// More advanced delivery features can be specified by setting the following properties in a message:
        /// - ```callback_url``` A URL can be included with each message to which Webhooks will be pushed to
        ///   via a HTTP POST request. Webhooks will be sent if and when the status of the message changes as
        ///   it is processed (if the delivery report property of the request is set to ```true```) and when replies
        ///   are received. Specifying a callback URL is optional.
        /// - ```content``` The content of the message. This can be a Unicode string, up to 5,000 characters long.
        ///   Message content is required.
        /// - ```delivery_report``` Delivery reports can be requested with each message. If delivery reports are requested, a webhook
        ///   will be submitted to the ```callback_url``` property specified for the message (or to the webhooks)
        ///   specified for the account every time the status of the message changes as it is processed. The
        ///   current status of the message can also be retrieved via the Delivery Reports endpoint of the
        ///   Messages API. Delivery reports are optional and by default will not be requested.
        /// - ```destination_number``` The destination number the message should be delivered to. This should be specified in E.164
        ///   international format. For information on E.164, please refer to http://en.wikipedia.org/wiki/E.164.
        ///   A destination number is required.
        /// - ```format``` The format specifies which format the message will be sent as, ```SMS``` (text message)
        ///   or ```TTS``` (text to speech). With ```TTS``` format, we will call the destination number and read out the
        ///   message using a computer generated voice. Specifying a format is optional, by default ```SMS``` will be used.
        /// - ```source_number``` A source number may be specified for the message, this will be the number that
        ///   the message appears from on the handset. By default this feature is _not_ available and will be ignored
        ///   in the request. Please contact <support@messagemeda.com> for more information. Specifying a source
        ///   number is optional and a by default a source number will be assigned to the message.
        /// - ```source_number_type``` If a source number is specified, the type of source number may also be
        ///   specified. This is recommended when using a source address type that is not an internationally
        ///   formatted number, available options are ```INTERNATIONAL```, ```ALPHANUMERIC``` or ```SHORTCODE```. Specifying a
        ///   source number type is only valid when the ```source_number``` parameter is specified and is optional.
        ///   If a source number is specified and no source number type is specified, the source number type will be
        ///   inferred from the source number, however this may be inaccurate.
        /// - ```scheduled``` A message can be scheduled for delivery in the future by setting the scheduled property.
        ///   The scheduled property expects a date time specified in ISO 8601 format. The scheduled time must be
        ///   provided in UTC and is optional. If no scheduled property is set, the message will be delivered immediately.
        /// - ```message_expiry_timestamp``` A message expiry timestamp can be provided to specify the latest time
        ///   at which the message should be delivered. If the message cannot be delivered before the specified
        ///   message expiry timestamp elapses, the message will be discarded. Specifying a message expiry 
        ///   timestamp is optional.
        /// - ```metadata``` Metadata can be included with the message which will then be included with any delivery
        ///   reports or replies matched to the message. This can be used to create powerful two-way messaging
        ///   applications without having to store persistent data in the application. Up to 10 key / value metadata data
        ///   pairs can be specified in a message. Each key can be up to 100 characters long, and each value up to 
        ///   256 characters long. Specifying metadata for a message is optional.
        /// The response body of a successful POST request to the messages endpoint will include a ```messages```
        /// property which contains a list of all messages submitted. The list of messages submitted will
        /// reflect the list of messages included in the request, but each message will also contain two new
        /// properties, ```message_id``` and ```status```. The returned message ID will be a 36 character UUID
        /// which can be used to check the status of the message via the Get Message Status endpoint. The status
        /// of the message which reflect the status of the message at submission time which will always be
        /// ```queued```. See the Delivery Reports section of this documentation for more information on message
        /// statues.
        /// *Note: when sending multiple messages in a request, all messages must be valid for the request to be successful.
        /// If any messages in the request are invalid, no messages will be sent.*
        /// </summary>
        /// <param name="body">Required parameter: Example: </param>
        /// <return>Returns the Models.SendMessagesResponse response from the API call</return>
        public Models.SendMessagesResponse CreateSendMessages(Models.SendMessagesRequest body, string accountHeaderValue = null)
        {
            Task<Models.SendMessagesResponse> t = CreateSendMessagesAsync(body, accountHeaderValue);
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Submit one or more (up to 100 per request) SMS or text to voice messages for delivery.
        /// The most basic message has the following structure:
        /// ```json
        /// {
        ///     "messages": [
        ///         {
        ///             "content": "My first message!",
        ///             "destination_number": "+61491570156"
        ///         }
        ///     ]
        /// }
        /// ```
        /// More advanced delivery features can be specified by setting the following properties in a message:
        /// - ```callback_url``` A URL can be included with each message to which Webhooks will be pushed to
        ///   via a HTTP POST request. Webhooks will be sent if and when the status of the message changes as
        ///   it is processed (if the delivery report property of the request is set to ```true```) and when replies
        ///   are received. Specifying a callback URL is optional.
        /// - ```content``` The content of the message. This can be a Unicode string, up to 5,000 characters long.
        ///   Message content is required.
        /// - ```delivery_report``` Delivery reports can be requested with each message. If delivery reports are requested, a webhook
        ///   will be submitted to the ```callback_url``` property specified for the message (or to the webhooks)
        ///   specified for the account every time the status of the message changes as it is processed. The
        ///   current status of the message can also be retrieved via the Delivery Reports endpoint of the
        ///   Messages API. Delivery reports are optional and by default will not be requested.
        /// - ```destination_number``` The destination number the message should be delivered to. This should be specified in E.164
        ///   international format. For information on E.164, please refer to http://en.wikipedia.org/wiki/E.164.
        ///   A destination number is required.
        /// - ```format``` The format specifies which format the message will be sent as, ```SMS``` (text message)
        ///   or ```TTS``` (text to speech). With ```TTS``` format, we will call the destination number and read out the
        ///   message using a computer generated voice. Specifying a format is optional, by default ```SMS``` will be used.
        /// - ```source_number``` A source number may be specified for the message, this will be the number that
        ///   the message appears from on the handset. By default this feature is _not_ available and will be ignored
        ///   in the request. Please contact <support@messagemeda.com> for more information. Specifying a source
        ///   number is optional and a by default a source number will be assigned to the message.
        /// - ```source_number_type``` If a source number is specified, the type of source number may also be
        ///   specified. This is recommended when using a source address type that is not an internationally
        ///   formatted number, available options are ```INTERNATIONAL```, ```ALPHANUMERIC``` or ```SHORTCODE```. Specifying a
        ///   source number type is only valid when the ```source_number``` parameter is specified and is optional.
        ///   If a source number is specified and no source number type is specified, the source number type will be
        ///   inferred from the source number, however this may be inaccurate.
        /// - ```scheduled``` A message can be scheduled for delivery in the future by setting the scheduled property.
        ///   The scheduled property expects a date time specified in ISO 8601 format. The scheduled time must be
        ///   provided in UTC and is optional. If no scheduled property is set, the message will be delivered immediately.
        /// - ```message_expiry_timestamp``` A message expiry timestamp can be provided to specify the latest time
        ///   at which the message should be delivered. If the message cannot be delivered before the specified
        ///   message expiry timestamp elapses, the message will be discarded. Specifying a message expiry 
        ///   timestamp is optional.
        /// - ```metadata``` Metadata can be included with the message which will then be included with any delivery
        ///   reports or replies matched to the message. This can be used to create powerful two-way messaging
        ///   applications without having to store persistent data in the application. Up to 10 key / value metadata data
        ///   pairs can be specified in a message. Each key can be up to 100 characters long, and each value up to 
        ///   256 characters long. Specifying metadata for a message is optional.
        /// The response body of a successful POST request to the messages endpoint will include a ```messages```
        /// property which contains a list of all messages submitted. The list of messages submitted will
        /// reflect the list of messages included in the request, but each message will also contain two new
        /// properties, ```message_id``` and ```status```. The returned message ID will be a 36 character UUID
        /// which can be used to check the status of the message via the Get Message Status endpoint. The status
        /// of the message which reflect the status of the message at submission time which will always be
        /// ```queued```. See the Delivery Reports section of this documentation for more information on message
        /// statues.
        /// *Note: when sending multiple messages in a request, all messages must be valid for the request to be successful.
        /// If any messages in the request are invalid, no messages will be sent.*
        /// </summary>
        /// <param name="body">Required parameter: Example: </param>
        /// <return>Returns the Models.SendMessagesResponse response from the API call</return>
        public async Task<Models.SendMessagesResponse> CreateSendMessagesAsync(Models.SendMessagesRequest body, string accountHeaderValue = null)
        {
            //the base uri for api requests
            string _baseUri = Configuration.BaseUri;
			string _methodUri = "/v1/messages";

			//prepare query string for API call
			StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append(_methodUri);


            //validate and preprocess url
            string _queryUrl = APIHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string,string>()
            {
                { "user-agent", "messagemedia-messages-csharp-sdk-1.0.0" },
                { "accept", "application/json" },
                { "content-type", "application/json; charset=utf-8" }
            };

            //append body params
            var _body = APIHelper.JsonSerialize(body);

			AddAccountHeaderTo(_headers, accountHeaderValue);

			//prepare the API call request to fetch the response
			HttpRequest _request = PostHttpRequest(_queryUrl, _headers, _body);

            //invoke request and get response
            HttpStringResponse _response = (HttpStringResponse) await ClientInstance.ExecuteAsStringAsync(_request).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request,_response);

            //Error handling using HTTP status codes
            if (_response.StatusCode == 400)
                throw new APIException(@"", _context);

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

            try
            {
                return APIHelper.JsonDeserialize<Models.SendMessagesResponse>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

    }
} 