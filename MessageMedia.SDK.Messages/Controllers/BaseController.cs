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
using System.Linq;
using APIMATIC.SDK.Http.Request;

namespace MessageMedia.Messages.Controllers
{
	public partial class BaseController
	{
		#region shared http client instance
		private static object _syncObject = new object();
		private static IHttpClient _clientInstance = null;
		protected const string SdkVersion = "messagemedia-messages-csharp-sdk-1.1.0";

		public static IHttpClient ClientInstance
		{
			get
			{
				lock(_syncObject)
				{
					if(null == _clientInstance)
					{
						_clientInstance = new HTTPClient()
;
					}
					return _clientInstance;
				}
			}
			set
			{
				lock(_syncObject)
				{
					if(value is IHttpClient)
					{
						_clientInstance = value;
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
				AddHmacHeaderTo(headers, url, body);
				request = ClientInstance.PostBody(url, headers, body);
			}
			else
			{
				request = ClientInstance.PostBody(url, headers, body, Configuration.BasicAuthUserName, Configuration.BasicAuthPassword);
			}

			return request;
		}

		internal void AddAccountHeaderTo(Dictionary<string, string> headers, string accountHeaderValue)
		{
			if(headers != null && accountHeaderValue != null)
			{
				headers.Add("Account", accountHeaderValue);
			}
		}

		/// <summary>
		/// Validates the response against HTTP errors defined at the API level
		/// </summary>
		/// <param name="response">The response recieved</param>
		/// <param name="context">Context of the request and the recieved response</param>
		internal void ValidateResponse(HttpResponse response, HttpContext context)
        {
            if ((response.StatusCode < 200) || (response.StatusCode > 208)) //[200,208] = HTTP OK
                throw new APIException(@"HTTP Response Not OK. " + ((response as HttpStringResponse != null) ? ((HttpStringResponse)response).Body : ""), context);
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
				contentSignature = $"x-Content-MD5: {contentHash}\n";
			}

			headers.Add("date", dateHeader);

			if(!string.IsNullOrEmpty(contentHash))
			{
				headers.Add("x-Content-MD5", contentHash);
				headers.Add("content-length", body.Length.ToString());
			}

			var headerList = "";

			foreach(var header in headers)
			{
				headerList += header.Key + " ";
			}

			var signature = GetHmacEncodingFor(dateHeader, contentSignature, body, url, headers);
			var authorizationHeader = $"hmac username=\"{Configuration.HmacAuthUserName}\", algorithm=\"hmac-sha1\", headers=\"date{(body != null ? " x-Content-MD5" : "")} request-line\", signature=\"{signature}\"";
			headers.Add("Authorization", authorizationHeader);
		}

		internal string GetHmacEncodingFor(string dateHeader, string contentSignature, string body, string url, Dictionary<string, string> headers)
		{
			var signingString = $"date: {dateHeader}\n{contentSignature}{(string.IsNullOrEmpty(body) ? "GET" : "POST")} {url.Replace(Configuration.BaseUri, "")} HTTP/1.1";
			var key = Configuration.HmacAuthPassword;

			var encoding = new ASCIIEncoding();
			var keyBytes = encoding.GetBytes(key);

			using (var hmac = new HMACSHA1(keyBytes))
			{
				var messageBytes = encoding.GetBytes(signingString);
				var hashmessage = hmac.ComputeHash(messageBytes);

				return Convert.ToBase64String(hashmessage);
			}
		}

		public string GetMd5HashFor(string input)
		{
			MD5 md5 = System.Security.Cryptography.MD5.Create();
			byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
			byte[] hash = md5.ComputeHash(inputBytes);
			StringBuilder sb = new StringBuilder();

			for (int i = 0; i < hash.Length; i++)
			{
				sb.Append(hash[i].ToString("X2"));
			}

			return sb.ToString();

		}

		internal bool HmacIsConfigured()
		{
			return !string.IsNullOrEmpty(Configuration.HmacAuthUserName) && !string.IsNullOrEmpty(Configuration.HmacAuthPassword);
		}
	}
} 