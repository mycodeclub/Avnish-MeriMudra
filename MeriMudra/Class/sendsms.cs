using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Web;

namespace MeriMudra.Class
{
    public static class sendsms
    {
        public static string run(string phonenumber, string msg)
        {
            String message = HttpUtility.UrlEncode(msg);
            using (var wb = new WebClient())
            {
                byte[] response = wb.UploadValues("https://api.textlocal.in/send/", new NameValueCollection()
                {
                {"apikey" , "<apikey>"},
                {"username" , "<username>"},
                {"password" , "<password>"},
                {"hash" , "<hash>"},
                {"numbers" , "<phonenumber>"},
                {"message" , "<message>"}
                });
                string result = System.Text.Encoding.UTF8.GetString(response);
                return result;
            }
        }
    }
}