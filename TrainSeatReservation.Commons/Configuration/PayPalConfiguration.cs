//Program powstał na Wydziale Informatyki Politechniki Białostockiej
using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainSeatReservation.Commons.Configuration
{
    public static class PayPalConfiguration 
    {
        public static string ClientId { get; set; }
        public static string ClientSecret { get; set; }

        static PayPalConfiguration()
        {
            var config = GetConfig();
        }
        // getting properties from the web.config  
        public static Dictionary<string, string> GetConfig()
        {
            return PayPal.Api.ConfigManager.Instance.GetProperties();
        }
        private static string GetAccessToken()
        {
            // getting accesstocken from paypal  
            string accessToken = new OAuthTokenCredential(ClientId, ClientSecret, GetConfig()).GetAccessToken();
            return accessToken;
        }
        public static APIContext GetAPIContext(IPayPalConfiguration configuration)
        {
            ClientId = configuration.ClientId;
            ClientSecret = configuration.ClientSecret;
            // return apicontext object by invoking it with the accesstoken  
            APIContext apiContext = new APIContext(GetAccessToken());
            apiContext.Config = new Dictionary<string, string>();//GetConfig();
            apiContext.Config.Add("clientId", configuration.ClientId);
            apiContext.Config.Add("clientSecret", configuration.ClientSecret);
            apiContext.Config.Add("mode", "sandbox");
            apiContext.Config.Add("requestRetries", "1");
            apiContext.Config.Add("connectionTimeout", "360000");
            return apiContext;
        }
    }
}
