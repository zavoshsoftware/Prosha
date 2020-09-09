namespace Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V04 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "ThumbImageUrl", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "ThumbImageUrl");
        }
    }
}
