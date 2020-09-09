namespace Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V15 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "HeaderImageUrl", c => c.String(maxLength: 500));
            AddColumn("dbo.Products", "HeaderImageUrl", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "HeaderImageUrl");
            DropColumn("dbo.Blogs", "HeaderImageUrl");
        }
    }
}
