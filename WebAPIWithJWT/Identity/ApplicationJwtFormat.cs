using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler.Encoder;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace WebAPIWithJWT.Identity
{
    public class ApplicationJwtFormat : ISecureDataFormat<AuthenticationTicket>
    {
        private static readonly byte[] _secret = TextEncodings.Base64Url.Decode(WebConfigurationManager.AppSettings["JwtSecurityKey"]);
        private readonly string _issuer;
        private readonly string _audience;

        public ApplicationJwtFormat()
        {
            _issuer = WebConfigurationManager.AppSettings["Issuer"];
            _audience = WebConfigurationManager.AppSettings["Audience"];
        }

        public string Protect(AuthenticationTicket data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            var issued = data.Properties.IssuedUtc;
            var expires = data.Properties.ExpiresUtc;
            var securityKey = new SymmetricSecurityKey(_secret);
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
            var securityToken = new JwtSecurityToken(_issuer, _audience, data.Identity.Claims, issued.Value.UtcDateTime, expires.Value.UtcDateTime, signingCredentials);
            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }

        public AuthenticationTicket Unprotect(string protectedText)
        {
            throw new NotImplementedException();
        }
    }
}