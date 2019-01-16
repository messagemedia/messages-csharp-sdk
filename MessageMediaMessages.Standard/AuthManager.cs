
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Security.Cryptography;
using MessageMedia.Messages.Controllers;
using MessageMedia.Messages.Exceptions;
using MessageMedia.Messages.Models;

namespace MessageMedia.Messages
{
    public class AuthManager
    {
        #region Singleton Pattern

        //private static variables for the singleton pattern
        private static object syncObject = new object();
        private static AuthManager instance = null;

        /// <summary>
        /// Singleton pattern implementation
        /// </summary>
        internal static AuthManager Instance
        {
            get
            {
                lock (syncObject)
                {
                    if (null == instance)
                    {
                        instance = new AuthManager();
                    }
                }
                return instance;
            }
        }

        #endregion Singleton Pattern

        public Dictionary<string, string> GetAuthHeaders(string url, string baseUrl, string body = null)
        {
            Dictionary<string, string> headers = new Dictionary<string, string>();
            if(!HmacIsConfigured())
            {
                headers.Add("Authorization", BuildBasicAuthheader(Configuration.BasicAuthUserName, Configuration.BasicAuthPassword));
                return headers;
            }
            var dateHeader = DateTime.UtcNow.ToString("r");
            string contentHash = string.Empty;
            string contentSignature = string.Empty;

            if (body != null)
            {
                contentHash = GetMd5HashFor(body);
                contentSignature = $"x-Content-MD5: {contentHash}\n";
            }

            headers.Add("date", dateHeader);

            if (!string.IsNullOrEmpty(contentHash))
            {
                headers.Add("x-Content-MD5", contentHash);
                headers.Add("content-length", body.Length.ToString());
            }

            var signature = GetHmacEncodingFor(dateHeader, contentSignature, body, url, headers, baseUrl);
            var authorizationHeader = $"hmac username=\"{Configuration.HmacAuthUserName}\", algorithm=\"hmac-sha1\", headers=\"date{(body != null ? " x-Content-MD5" : "")} request-line\", signature=\"{signature}\"";
            headers.Add("Authorization", authorizationHeader);
            return headers;
        }

        private string GetHmacEncodingFor(string dateHeader, string contentSignature, string body, string url, Dictionary<string, string> headers, string baseUrl)
        {
            var signingString = $"date: {dateHeader}\n{contentSignature}{(string.IsNullOrEmpty(body) ? "GET" : "POST")} {url.Replace(baseUrl, "")} HTTP/1.1";
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

        private string BuildBasicAuthheader(string username, string password)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(username + ':' + password);
            return "Basic " + Convert.ToBase64String(plainTextBytes);
        }

        private string GetMd5HashFor(string input)
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

        private bool HmacIsConfigured()
        {
            return !string.IsNullOrEmpty(Configuration.HmacAuthUserName) && !string.IsNullOrEmpty(Configuration.HmacAuthPassword);
        }
    }
}