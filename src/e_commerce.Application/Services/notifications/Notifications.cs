using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace e_commerce.Services.notifications
{

    public class Notification
    {


        public static void SendMessage(string cell, string msg)
        {
            //API keys
            string accountId = "ACcdd4389de60e42191082189a8ebbd617";
            string authToken = "94cf24cc6bf74092db1edbdd2b993ba0";

            TwilioClient.Init(accountId, authToken);//initialise the service in the code


            var message = MessageResource.Create(
                body: msg,
                from: new Twilio.Types.PhoneNumber("+18598007840"),
                to: new Twilio.Types.PhoneNumber(cell)
            );
        }
    }
    
}
