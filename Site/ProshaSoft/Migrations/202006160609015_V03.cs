namespace Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V03 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductFeatures", "Code", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductFeatures", "Code");
        }
    }
}
