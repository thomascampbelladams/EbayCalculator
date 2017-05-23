// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Startup.cs" company="Thomas Inc">
//   AH SHIET
// </copyright>
// <summary>
//   Defines the Startup type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(EbayCalculations.Startup))]

namespace EbayCalculations
{
    /// <summary>
    /// The startup.
    /// </summary>
    public partial class Startup
    {
        /// <summary>
        /// The configuration.
        /// </summary>
        /// <param name="app">
        /// The app.
        /// </param>
        public void Configuration(IAppBuilder app)
        {
            
            this.ConfigureAuth(app);
        }
    }
}
