// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EbayCalculationsModel.cs" company="Thomas Inc">
//   AH SHIET
// </copyright>
// <summary>
//   Defines the EbayCalculationsModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EbayCalculations.Models
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The ebay calculations model.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
    public class EbayCalculationsModel : DbContext
    {
        // Your context has been configured to use a 'EbayCalculationsModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'EbayCalculations.Models.EbayCalculationsModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'EbayCalculationsModel' 
        // connection string in the application configuration file.

        /// <summary>
        /// Initializes a new instance of the <see cref="EbayCalculationsModel"/> class.
        /// </summary>
        public EbayCalculationsModel()
            : base("name=EbayCalculationsModel")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        public virtual DbSet<Item> Items { get; set; }

        /// <summary>
        /// Gets or sets the peoples.
        /// </summary>
        public virtual DbSet<People> Peoples { get; set; }
    }

    // public class MyEntity
    // {
    // public int Id { get; set; }
    // public string Name { get; set; }
    // }

    /// <summary>
    /// The items.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed. Suppression is OK here.")]
    [DisplayColumn("Name")]
    public class Item
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the person sold to id.
        /// </summary>
        [Required]
        public int PersonSoldToId { get; set; }

        /// <summary>
        /// Gets or sets the person sold to.
        /// </summary>
        [Required]
        [DisplayName("Person the item was sold to")]
        [ForeignKey("PersonSoldToId")]
        public virtual People PersonSoldTo { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        [Required]
        [Column(TypeName = "Money")]
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the shipping paid by buyer.
        /// </summary>
        [Required]
        [DisplayName("Shipping paid by buyer")]
        [Column(TypeName = "Money")]
        public decimal ShippingPaidByBuyer { get; set; }

        /// <summary>
        /// Gets or sets the shipping paid by seller.
        /// </summary>
        [Required]
        [DisplayName("Shipping paid by you")]
        [Column(TypeName = "Money")]
        public decimal ShippingPaidBySeller { get; set; }

        /// <summary>
        /// Gets or sets the shipping container price.
        /// </summary>
        [Required]
        [DisplayName("Shipping container price")]
        [Column(TypeName = "Money")]
        public decimal ShippingContainerPrice { get; set; }

        /// <summary>
        /// Gets or sets the paypal fee.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [Required]
        [DisplayName("Paypal fee")]
        [Column(TypeName = "Money")]
        public decimal PaypalFee { get; set; }

        /// <summary>
        /// Gets or sets the ebay fee.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [Required]
        [DisplayName("Ebay fee")]
        [Column(TypeName = "Money")]
        public decimal EbayFee { get; set; }

        /// <summary>
        /// Gets or sets the sold date.
        /// </summary>
        [DisplayName("Sold date")]
        [Column(TypeName = "Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime SoldDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the package was delivered.
        /// </summary>
        [Required]
        public bool Delivered { get; set; }
    }

    /// <summary>
    /// The people.
    /// </summary>
    public class People
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the user name.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the delivery address.
        /// </summary>
        [DisplayName("Delivery Address")]
        public string DeliveryAddress { get; set; }

        /// <summary>
        /// Gets or sets the item.
        /// </summary>
        public virtual Item Item { get; set; }
    }
}