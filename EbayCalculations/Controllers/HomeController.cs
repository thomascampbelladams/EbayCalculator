// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HomeController.cs" company="Thomas Inc">
//   AH SHIET
// </copyright>
// <summary>
//   Defines the HomeController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EbayCalculations.Controllers
{
    using System.Diagnostics.CodeAnalysis;
    using System.Web.Mvc;

    /// <summary>
    /// The home controller.
    /// </summary>
    [Authorize]
    [SuppressMessage("ReSharper", "ArrangeThisQualifier", Justification = "Reviewed. Supression is OK here.")]
    public class HomeController : Controller
    {
        /// <summary>
        /// The index.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1126:PrefixCallsCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        public ActionResult Index()
        {
            return View();
        }
    }
}
