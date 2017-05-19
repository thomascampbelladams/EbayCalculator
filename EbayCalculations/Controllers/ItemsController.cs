// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemsController.cs" company="Thomas Inc">
//   AH SHIET
// </copyright>
// <summary>
//   Defines the ItemsController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EbayCalculations.Controllers
{
    using System.Collections;
    using System.Data.Entity;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Web.Http.Description;

    using Models;

    /// <summary>
    /// The items controller.
    /// </summary>
    [Authorize]
    public class ItemsController : ApiController
    {
        /// <summary>
        /// The db.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        private EbayCalculationsModel db = new EbayCalculationsModel();

        /// GET api/Items
        /// <summary>
        /// Gets a list of items from the server.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [ResponseType(typeof(Item))]
        public async Task<IHttpActionResult> Get()
        {
            ICollection items = await (from i in this.db.Items select i).ToListAsync();

            if (items == null)
            {
                return this.NotFound();
            }

            return this.Ok(items);
        }

        // POST api/Items
        /// <summary>
        /// The post.
        /// </summary>
        /// <param name="ebayItem">
        /// The ebay item.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [ResponseType(typeof(Item))]
        public async Task<IHttpActionResult> Post(Item ebayItem)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            this.db.Items.Add(ebayItem);

            await this.db.SaveChangesAsync();

            return this.Ok();
        }

        /// <summary>
        /// The dispose.
        /// </summary>
        /// <param name="disposing">
        /// The disposing.
        /// </param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.db.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
