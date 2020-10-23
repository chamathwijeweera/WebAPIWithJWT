using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPIWithJWT.Identity;
using WebAPIWithJWT.Providers;

namespace WebAPIWithJWT.App_Start
{
    public class AuthServerConfig : OAuthAuthorizationServerOptions
    {
        public AuthServerConfig()
        {
            AllowInsecureHttp = true;
            TokenEndpointPath = new PathString("/auth");
            AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(30);
            Provider = new ApplicationOAuthProvider();
            AccessTokenFormat = new ApplicationJwtFormat();
        }
    }
}