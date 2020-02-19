namespace Pocos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class startofTuesday7 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Subscriptions", new[] { "coffee_Id" });
            DropIndex("dbo.Subscriptions", new[] { "user_Id" });
            CreateIndex("dbo.Subscriptions", "Coffee_Id");
            CreateIndex("dbo.Subscriptions", "User_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Subscriptions", new[] { "User_Id" });
            DropIndex("dbo.Subscriptions", new[] { "Coffee_Id" });
            CreateIndex("dbo.Subscriptions", "user_Id");
            CreateIndex("dbo.Subscriptions", "coffee_Id");
        }
    }
}
