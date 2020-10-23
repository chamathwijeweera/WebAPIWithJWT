using Microsoft.Owin.Security.DataHandler.Encoder;
using Microsoft.Owin.Security.Jwt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace WebAPIWithJWT.App_Start
{
    public class JWTConfig : JwtBearerAuthenticationOptions
    {
        public JWTConfig()
        {
            var securityKey = WebConfigurationManager.AppSettings["JwtSecurityKey"];
            var issuer = WebConfigurationManager.AppSettings["Issuer"]; 
            var audience = WebConfigurationManager.AppSettings["Audience"];
            var key = TextEncodings.Base64Url.Decode(securityKey);

            AllowedAudiences = new[] { audience };
            IssuerSecurityKeyProviders = new[]
            {
                new SymmetricKeyIssuerSecurityKeyProvider(issuer, key)
            };
        }
    }
}