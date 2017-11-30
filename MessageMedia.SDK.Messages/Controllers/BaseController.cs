/*
 * MessageMediaMessages.PCL
 *
 */
using System;
using APIMATIC.SDK.Common;
using APIMATIC.SDK.Http.Client;
using APIMATIC.SDK.Http.Response;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using System.Linq;
using System.Net;
using APIMATIC.SDK.Http.Request;

namespace MessageMedia.Messages.Controllers
{
    public partial class BaseController
    {
        #region shared http client instance
        private static object syncObject = new object();
        private static IHttpClient clientInstance = null;

        public static IHttpClient ClientInstance
        {
            get
            {
                lock(syncObject)
                {
                    if(null == clientInstance)
                    {
                        clientInstance = new HTTPClient()
;
                    }
                    return clientInstance;
                }
            }
            set
            {
                lock (syncObject)
                {
                    if (value is IHttpClient)
                    {
                        clientInstance = value;
                    }
                }
            }
        }
        #endregion shared http client instance

        internal ArrayDeserialization ArrayDeserializationFormat = ArrayDeserialization.Indexed;
        internal static char ParameterSeparator = '&';

		internal HttpRequest GetHttpRequest(string url, Dictionary<string, string> headers)
		{
			HttpRequest request;

			if(HmacIsConfigured())
			{
				AddHmacHeaderTo(headers, url);
				request = ClientInstance.Get(url, headers);
			}
			else
			{
				request = ClientInstance.Get(url, headers, Configuration.BasicAuthUserName, Configuration.BasicAuthPassword);
			}

			return request;
		}

		internal HttpRequest PostHttpRequest(string url, Dictionary<string, string> headers, string body)
		{
			HttpRequest request;

			if(HmacIsConfigured())
			{
				AddHmacHeaderTo(headers, url);
				request = ClientInstance.PostBody(url, headers, body);
			}
			else
			{
				request = ClientInstance.PostBody(url, headers, body, Configuration.BasicAuthUserName, Configuration.BasicAuthPassword);
			}

			return request;
		}

		/// <summary>
		/// Validates the response against HTTP errors defined at the API level
		/// </summary>
		/// <param name="_response">The response recieved</param>
		/// <param name="_context">Context of the request and the recieved response</param>
		internal void ValidateResponse(HttpResponse _response, HttpContext _context)
        {
            if ((_response.StatusCode < 200) || (_response.StatusCode > 208)) //[200,208] = HTTP OK
                throw new APIException(@"HTTP Response Not OK", _context);
        }
		
		internal void AddHmacHeaderTo(Dictionary<string, string> headers, string url, string body = null)
		{
			// Only add headers when configured for it.
			if(!HmacIsConfigured())
			{
				return;
			}

			var dateHeader = DateTime.UtcNow.ToString("r");
			string contentHash = string.Empty;
			string contentSignature = string.Empty;

			if(body != null)
			{
				contentHash = GetMd5HashFor(body);
				contentSignature = $"Content-MD5:{contentHash}\n";
			}

			var signature = GetHmacEncodingFor(dateHeader, contentSignature, body, url);

			headers.Add("Date", dateHeader);

			if(!string.IsNullOrEmpty(contentHash))
			{
				headers.Add("Content-MD5", contentHash);
				headers.Add("Content-Length", body.Length.ToString());
			}

			headers.Add("Authorization", $@"hmac username=""{Configuration.HmacAuthUserName}"", algorithm=""hmac-sha1"", headers=""Date{(body != null ? " Content-MD5" : "")} request-line"", signature=""{signature}""");
		}

		internal string GetHmacEncodingFor(string dateHeader, string contentSignature, string body, string url)
		{
			var signingString = $@"Date: {dateHeader}\n{contentSignature}{(string.IsNullOrEmpty(body) ? "GET" : "POST")} {url} HTTP/1.1";

			var pass = Configuration.HmacAuthPassword;
			var encoding = Encoding.UTF8;
			byte[] keyBytes = encoding.GetBytes(pass);
			byte[] messageBytes = encoding.GetBytes(signingString);

			using(var hmacsha1 = new HMACSHA1(keyBytes))
			{
				byte[] hashmessage = hmacsha1.ComputeHash(messageBytes);
				var signingString2 = hashmessage.Aggregate("", (s, e) => s + String.Format("{0:x2}", e), s => s);
				var encoded = Base64Encode(signingString2);
				return encoded;
			}
		}

		internal string CreateToken(string message)
		{
			var pass = Configuration.HmacAuthPassword;
			var encoding = Encoding.UTF8;
			byte[] keyBytes = encoding.GetBytes(pass);
			byte[] messageBytes = encoding.GetBytes(message);

			using(var hmacsha256 = new HMACSHA1(keyBytes))
			{
				byte[] hashmessage = hmacsha256.ComputeHash(messageBytes);
				return Convert.ToBase64String(hashmessage);
			}
		}

		internal static string Base64Encode(string plainText)
		{
			var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
			return Convert.ToBase64String(plainTextBytes);
		}

		internal string GetMd5HashFor(string body)
		{
			if(string.IsNullOrEmpty(body))
			{
				return null;
			}

			using(MD5 md5Hash = MD5.Create())
			{
				var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(body));
				var signingString = data.Aggregate("", (s, e) => s + String.Format("{0:x2}", e), s => s);

				return signingString;
			}
		}

		internal bool HmacIsConfigured()
		{
			return !string.IsNullOrEmpty(Configuration.HmacAuthUserName) && !string.IsNullOrEmpty(Configuration.HmacAuthPassword);
		}
	}
} 