namespace Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V14 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BlogGroups",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(maxLength: 200),
                        TitleEn = c.String(maxLength: 200),
                        UrlParam = c.String(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletionDate = c.DateTime(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Blogs", "BlogGroupId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Blogs", "BlogGroupId");
            AddForeignKey("dbo.Blogs", "BlogGroupId", "dbo.BlogGroups", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Blogs", "BlogGroupId", "dbo.BlogGroups");
            DropIndex("dbo.Blogs", new[] { "BlogGroupId" });
            DropColumn("dbo.Blogs", "BlogGroupId");
            DropTable("dbo.BlogGroups");
        }
    }
}
