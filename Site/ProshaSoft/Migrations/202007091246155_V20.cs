namespace Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V20 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Blogs", "BlogGroupId", "dbo.BlogGroups");
            DropIndex("dbo.Blogs", new[] { "BlogGroupId" });
            AlterColumn("dbo.Blogs", "BlogGroupId", c => c.Guid());
            CreateIndex("dbo.Blogs", "BlogGroupId");
            AddForeignKey("dbo.Blogs", "BlogGroupId", "dbo.BlogGroups", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Blogs", "BlogGroupId", "dbo.BlogGroups");
            DropIndex("dbo.Blogs", new[] { "BlogGroupId" });
            AlterColumn("dbo.Blogs", "BlogGroupId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Blogs", "BlogGroupId");
            AddForeignKey("dbo.Blogs", "BlogGroupId", "dbo.BlogGroups", "Id", cascadeDelete: true);
        }
    }
}
