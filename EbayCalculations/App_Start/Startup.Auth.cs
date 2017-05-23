// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Startup.Auth.cs" company="Thomas Inc.">
//   AH SHIET
// </copyright>
// <summary>
//   Defines the Startup type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EbayCalculations
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;
    using Microsoft.Owin;
    using Microsoft.Owin.Security.Cookies;
    using Microsoft.Owin.Security.OAuth;

    using Models;

    using Owin;

    using Providers;

    /// <summary>
    /// The startup.
    /// </summary>
    public partial class Startup
    {
        // Enable the application to use OAuthAuthorization. You can then secure your Web APIs

        /// <summary>
        /// Initializes static members of the <see cref="Startup"/> class.
        /// </summary>
        static Startup()
        {
            PublicClientId = "web";

            OAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/Token"),
                AuthorizeEndpointPath = new PathString("/Account/Authorize"),
                Provider = new ApplicationOAuthProvider(PublicClientId),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(14),
                AllowInsecureHttp = true
            };
        }

        /// <summary>
        /// Gets the o auth options.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        public static OAuthAuthorizationServerOptions OAuthOptions { get; }

        /// <summary>
        /// Gets the public client id.
        /// </summary>
        public static string PublicClientId { get; }

        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864

        /// <summary>
        /// The configure auth.
        /// </summary>
        /// <param name="app">
        /// The app.
        /// </param>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        public void ConfigureAuth(IAppBuilder app)
        {
            // Configure the db context, user manager and signin manager to use a single instance per request
            app.CreatePerOwinContext(ApplicationDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);

            // Enable the application to use a cookie to store information for the signed in user
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                Provider = new CookieAuthenticationProvider
                {
                    // Enables the application to validate the security stamp when the user logs in.
                    // This is a security feature which is used when you change a password or add an external login to your account.  
                    OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser>(
                        TimeSpan.FromMinutes(20),
                        (manager, user) => user.GenerateUserIdentityAsync(manager))
                }
            });

            // Use a cookie to temporarily store information about a user logging in with a third party login provider
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Enables the application to temporarily store user information when they are verifying the second factor in the two-factor authentication process.
            app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5));

            // Enables the application to remember the second login verification factor such as phone or email.
            // Once you check this option, your second step of verification during the login process will be remembered on the device where you logged in from.
            // This is similar to the RememberMe option when you log in.
            app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);

            // Enable the application to use bearer tokens to authenticate users
            app.UseOAuthBearerTokens(OAuthOptions);

            // Uncomment the following lines to enable logging in with third party login providers
            // app.UseMicrosoftAccountAuthentication(
            // clientId: "",
            // clientSecret: "");

            // app.UseTwitterAuthentication(
            // consumerKey: "",
            // consumerSecret: "");

            // app.UseFacebookAuthentication(
            // appId: "",
            // appSecret: "");

            // app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
            // {
            // ClientId = "",
            // ClientSecret = ""
            // });
        }
    }
}
