namespace Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V18 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PageGroups",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(nullable: false, maxLength: 256),
                        TitleEn = c.String(maxLength: 200),
                        UrlParam = c.String(nullable: false),
                        IsInHome = c.Boolean(nullable: false),
                        Order = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletionDate = c.DateTime(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pages",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(nullable: false, maxLength: 256),
                        TitleEn = c.String(maxLength: 200),
                        UrlParam = c.String(nullable: false),
                        IsInHome = c.Boolean(nullable: false),
                        Order = c.Int(nullable: false),
                        PageGroupId = c.Guid(nullable: false),
                        ImageUrl = c.String(maxLength: 500),
                        HeaderImageUrl = c.String(maxLength: 500),
                        Body = c.String(storeType: "ntext"),
                        BodyEn = c.String(storeType: "ntext"),
                        IsActive = c.Boolean(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletionDate = c.DateTime(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PageGroups", t => t.PageGroupId, cascadeDelete: true)
                .Index(t => t.PageGroupId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pages", "PageGroupId", "dbo.PageGroups");
            DropIndex("dbo.Pages", new[] { "PageGroupId" });
            DropTable("dbo.Pages");
            DropTable("dbo.PageGroups");
        }
    }
}
