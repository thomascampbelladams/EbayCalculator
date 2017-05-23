// --------------------------------------------------------------------------------------------------------------------
// <copyright file="201705192215174_InitialMigration.cs" company="Thomas Inc.">
//   AH SHIET
// </copyright>
// <summary>
//   Defines the InitialMigration type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EbayCalculations.Migrations
{
    using System.Data.Entity.Migrations;

    /// <summary>
    /// The initial migration.
    /// </summary>
    public partial class InitialMigration : DbMigration
    {
        /// <summary>
        /// The up.
        /// </summary>
        public override void Up()
        {
            this.CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(false, true),
                        PersonSoldToId = c.Int(false),
                        Name = c.String(false),
                        Price = c.Decimal(false, storeType: "money"),
                        ShippingPaidByBuyer = c.Decimal(false, storeType: "money"),
                        ShippingPaidBySeller = c.Decimal(false, storeType: "money"),
                        ShippingContainerPrice = c.Decimal(false, storeType: "money"),
                        PaypalFee = c.Decimal(false, storeType: "money"),
                        EbayFee = c.Decimal(false, storeType: "money"),
                        SoldDate = c.DateTime(false, storeType: "date"),
                        Delivered = c.Boolean(false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.PersonSoldToId, true)
                .Index(t => t.PersonSoldToId);

            this.CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(false, true),
                        UserName = c.String(),
                        DeliveryAddress = c.String(),
                    })
                .PrimaryKey(t => t.Id);
        }

        /// <summary>
        /// The down.
        /// </summary>
        public override void Down()
        {
            this.DropForeignKey("dbo.Items", "PersonSoldToId", "dbo.People");
            this.DropIndex("dbo.Items", new[] { "PersonSoldToId" });
            this.DropTable("dbo.People");
            this.DropTable("dbo.Items");
        }
    }
}
