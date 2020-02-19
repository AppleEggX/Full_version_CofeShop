namespace Pocos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tryagainnewdatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                 "dbo.BasketItems",
                 c => new
                 {
                     BasketItemId = c.Int(nullable: false, identity: true),
                     ProductType = c.Int(nullable: false),
                     Quantity = c.Int(nullable: false),
                     TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                     Basket_Id = c.Int(),
                     Product_Id = c.Int(),
                 })
                 .PrimaryKey(t => t.BasketItemId)
                 .ForeignKey("dbo.Baskets", t => t.Basket_Id)
                 .ForeignKey("dbo.Products", t => t.Product_Id)
                 .Index(t => t.Basket_Id)
                 .Index(t => t.Product_Id);

            CreateTable(
                "dbo.Baskets",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    SumPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Paid = c.Boolean(nullable: false),
                    User_Id = c.Int(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);

            CreateTable(
                "dbo.Users",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Username = c.String(),
                    Email = c.String(),
                    Password = c.String(),
                    Admin = c.Boolean(nullable: false),
                    AddressLn1 = c.String(),
                    AddressLn2 = c.String(),
                    Town = c.String(),
                    PostCode = c.String(),
                    Country = c.String(),
                    DeliveryPreferences = c.String(),
                    Discriminator = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Subscriptions",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    StartDate = c.DateTime(nullable: false),
                    EndDate = c.DateTime(nullable: false),
                    PercentDiscount = c.Double(nullable: false),
                    Quantity = c.Int(nullable: false),
                    Coffee_Id = c.Int(),
                    User_Id = c.Int(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Coffee_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.Coffee_Id)
                .Index(t => t.User_Id);

            CreateTable(
                "dbo.Products",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    Type = c.Int(nullable: false),
                    Rating = c.Double(nullable: false),
                    Description = c.String(),
                    Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Origin = c.Int(),
                    Stock = c.Int(),
                    CoffeeType = c.Int(),
                    Strength = c.Int(),
                    Length = c.String(),
                    Difficulty = c.Int(),
                    CourseType = c.Int(),
                    Discriminator = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.TestClasses",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                })
                .PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BasketItems", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.Subscriptions", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Subscriptions", "Coffee_Id", "dbo.Products");
            DropForeignKey("dbo.Baskets", "User_Id", "dbo.Users");
            DropForeignKey("dbo.BasketItems", "Basket_Id", "dbo.Baskets");
            DropIndex("dbo.Subscriptions", new[] { "User_Id" });
            DropIndex("dbo.Subscriptions", new[] { "Coffee_Id" });
            DropIndex("dbo.Baskets", new[] { "User_Id" });
            DropIndex("dbo.BasketItems", new[] { "Product_Id" });
            DropIndex("dbo.BasketItems", new[] { "Basket_Id" });
            DropTable("dbo.TestClasses");
            DropTable("dbo.Products");
            DropTable("dbo.Subscriptions");
            DropTable("dbo.Users");
            DropTable("dbo.Baskets");
            DropTable("dbo.BasketItems");
        }
    }
}

