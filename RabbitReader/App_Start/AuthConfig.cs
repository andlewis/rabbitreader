using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Web.WebPages.OAuth;
using RabbitReader.Models;

namespace RabbitReader
{
    public static class AuthConfig
    {
        public static void RegisterAuth()
        {
            // To let users of this site log in using their accounts from other sites such as Microsoft, Facebook, and Twitter,
            // you must update this site. For more information visit http://go.microsoft.com/fwlink/?LinkID=252166

            //OAuthWebSecurity.RegisterMicrosoftClient(
            //    clientId: "",
            //    clientSecret: "");
            OAuthWebSecurity.RegisterTwitterClient(
                       consumerKey: "STS2IEAEMp51jLCIi2Fxw",
                       consumerSecret: "ofhWTIppzVLaSzVvbYdPUocQvLuNq03789y3f7Mgn8g");

            OAuthWebSecurity.RegisterFacebookClient(
                appId: "208007329333781",
                appSecret: "c901fd27cc174ec700f0f38544748ecc");

            OAuthWebSecurity.RegisterLinkedInClient(consumerKey: "6io2dkugvk31", consumerSecret: "lqR3YPZkNHu0HSYb");

            OAuthWebSecurity.RegisterGoogleClient();
        }
    }
}
