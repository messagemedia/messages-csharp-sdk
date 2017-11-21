/*
 * MessageMediaMessages.Tests
 *
 */
using APIMATIC.SDK.Http.Client;
using APIMATIC.SDK.Http.Request;
using APIMATIC.SDK.Http.Response;

namespace MessageMedia.Messages.Helpers
{
    public class HttpCallBackEventsHandler
    {
        public HttpRequest Request { get; private set; }

        public HttpResponse Response { get; private set; }

        public void OnBeforeHttpRequestEventHandler(IHttpClient source, HttpRequest request)
        {
            this.Request = request;
        }

        public void OnAfterHttpResponseEventHandler(IHttpClient source, HttpResponse response)
        {
            this.Response = response;
        }
    }
}
