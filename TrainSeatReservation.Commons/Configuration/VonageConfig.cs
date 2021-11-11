using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vonage;
using Vonage.Request;

namespace TrainSeatReservation.Commons.Configuration
{
    public static class VonageConfig
    {
        public static VonageClient VonageClient;
        
        public static VonageClient Config()
        {
              var credentials = Credentials.FromApiKeyAndSecret(
                 "7afbd6dc",
                 "kix4Kzs0exV9EYsy"
                 );

            VonageClient = new VonageClient(credentials);
            return VonageClient;
        }
        public static void Send(string content, string phone)
        {
            Config();
            var response = VonageClient.SmsClient.SendAnSms(new Vonage.Messaging.SendSmsRequest()
            {
                To = phone,
                From = "Vonage APIs",
                Text = content
            });
        }
    }
}
