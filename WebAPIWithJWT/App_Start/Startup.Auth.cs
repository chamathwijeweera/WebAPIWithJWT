using Microsoft.Owin.Security.OAuth;
using Owin;
using WebAPIWithJWT.App_Start;
using WebAPIWithJWT.Models;

namespace WebAPIWithJWT
{
    public partial class Startup
    {
        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }

        public static string PublicClientId { get; private set; }

        // For more information on configuring authentication, please visit https://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            // Configure the db context and user manager to use a single instance per request
            app.CreatePerOwinContext(ApplicationDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);

            app.UseJwtBearerAuthentication(new JWTConfig());
            app.UseOAuthAuthorizationServer(new AuthServerConfig());
        }
    }
}
