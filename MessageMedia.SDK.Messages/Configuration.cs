using MessageMedia.Messages.Models;
namespace MessageMedia.Messages
{
    public partial class Configuration
    {
        //The base Uri for API calls
        public static string BaseUri = "https://api.messagemedia.com";

        //The username to use with basic authentication
        //TODO: Replace the BasicAuthUserName with an appropriate value
        public static string BasicAuthUserName = "TODO: Replace";

        //The password to use with basic authentication
        //TODO: Replace the BasicAuthPassword with an appropriate value
        public static string BasicAuthPassword = "TODO: Replace";

		//The username to use with HMAC authentication. Leave empty to disable HMAC authentication.
		public static string HmacAuthUserName = "";

		//The password to use with HMAC authentication encryption. Leave empty to disable HMAC authentication.
		public static string HmacAuthPassword = "";

	}
}