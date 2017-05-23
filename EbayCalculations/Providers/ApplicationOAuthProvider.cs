// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApplicationOAuthProvider.cs" company="Thomas Inc">
//   AH SHIET
// </copyright>
// <summary>
//   Defines the ApplicationOAuthProvider type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EbayCalculations.Providers
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using Microsoft.Owin.Security.OAuth;

    /// <summary>
    /// The application o auth provider.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        /// <summary>
        /// The _public client id.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1309:FieldNamesMustNotBeginWithUnderscore", Justification = "Reviewed. Suppression is OK here.")]
        // ReSharper disable once InconsistentNaming
        private readonly string _publicClientId;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationOAuthProvider"/> class.
        /// </summary>
        /// <param name="publicClientId">
        /// The public client id.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// </exception>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1627:DocumentationTextMustNotBeEmpty", Justification = "Reviewed. Suppression is OK here.")]
        public ApplicationOAuthProvider(string publicClientId)
        {
            if (publicClientId == null)
            {
                throw new ArgumentNullException("publicClientId");
            }

            this._publicClientId = publicClientId;
        }

        /// <summary>
        /// The validate client redirect uri.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public override Task ValidateClientRedirectUri(OAuthValidateClientRedirectUriContext context)
        {
            if (context.ClientId == this._publicClientId)
            {
                Uri expectedRootUri = new Uri(context.Request.Uri, "/");

                if (expectedRootUri.AbsoluteUri == context.RedirectUri)
                {
                    context.Validated();
                }
                else if (context.ClientId == "web")
                {
                    var expectedUri = new Uri(context.Request.Uri, "/");
                    context.Validated(expectedUri.AbsoluteUri);
                }
            }

            return Task.FromResult<object>(null);
        }
    }
}