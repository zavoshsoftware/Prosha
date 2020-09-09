namespace Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V05 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "IsRelated", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Blogs", "IsRelated");
        }
    }
}
