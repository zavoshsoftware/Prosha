namespace Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V21 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "ImageUrlThumb", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Blogs", "ImageUrlThumb");
        }
    }
}
