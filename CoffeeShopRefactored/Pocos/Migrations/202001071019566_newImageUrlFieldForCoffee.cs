namespace Pocos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newImageUrlFieldForCoffee : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Imgurl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Imgurl");
        }
    }
}
