// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Configuration.cs" company="Thomas Inc">
//   AH SHIET
// </copyright>
// <summary>
//   Defines the Configuration type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EbayCalculations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    using Models;

    /// <summary>
    /// The configuration.
    /// </summary>
    internal sealed class Configuration : DbMigrationsConfiguration<EbayCalculationsModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Configuration"/> class.
        /// </summary>
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
        }

        /// <summary>
        /// The seed.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        protected override void Seed(EbayCalculationsModel context)
        {
            // This method will be called after migrating to the latest version.

            // You can use the DbSet<T>.AddOrUpdate() helper extension method 
            // to avoid creating duplicate seed data. E.g.
            // 
            // context.People.AddOrUpdate(
            // p => p.FullName,
            // new Person { FullName = "Andrew Peters" },
            // new Person { FullName = "Brice Lambson" },
            // new Person { FullName = "Rowan Miller" }
            // );
            context.Peoples.AddOrUpdate(
                p => p.Id,
                new People { Id = 1, DeliveryAddress = "123 what st", UserName = "what" },
                new People { Id = 2, DeliveryAddress = "456 who st", UserName = "who" },
                new People { Id = 3, DeliveryAddress = "789 where st", UserName = "where" });

            context.Items.AddOrUpdate(
                i => i.Id,
                new Item
                    {
                        Id = 1,
                        Delivered = true,
                        EbayFee = Convert.ToDecimal(0.40),
                        PaypalFee = Convert.ToDecimal(0.50),
                        Name = "Test",
                        Price = 1,
                        ShippingContainerPrice = 2,
                        ShippingPaidByBuyer = 3,
                        ShippingPaidBySeller = 4,
                        PersonSoldToId = 1
                    },
                new Item
                    {
                        Id = 2,
                        Delivered = true,
                        EbayFee = Convert.ToDecimal(.2),
                        PaypalFee = Convert.ToDecimal(0.52),
                        Name = "Test",
                        Price = 5,
                        ShippingContainerPrice = 6,
                        ShippingPaidByBuyer = 7,
                        ShippingPaidBySeller = 8,
                        PersonSoldToId = 2
                    },
                new Item
                    {
                        Id = 3,
                        Delivered = true,
                        EbayFee = Convert.ToDecimal(.21),
                        PaypalFee = Convert.ToDecimal(0.53),
                        Name = "Test",
                        Price = 9,
                        ShippingContainerPrice = 10,
                        ShippingPaidByBuyer = 11,
                        ShippingPaidBySeller = 12,
                        PersonSoldToId = 3
                    });
        }
    }
}
