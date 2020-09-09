namespace Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V02 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductGroups", "ParentId", "dbo.ProductGroups");
            DropForeignKey("dbo.Products", "ProductGroupId", "dbo.ProductGroups");
            DropIndex("dbo.Products", new[] { "ProductGroupId" });
            DropIndex("dbo.ProductGroups", new[] { "ParentId" });
            AddColumn("dbo.Products", "UrlParam", c => c.String(nullable: false));
            DropColumn("dbo.Products", "ProductGroupId");
            DropTable("dbo.ProductGroups");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ProductGroups",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Order = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 256),
                        UrlParam = c.String(nullable: false, maxLength: 500),
                        PageTitle = c.String(nullable: false, maxLength: 500),
                        PageDescription = c.String(maxLength: 1000),
                        ImageUrl = c.String(maxLength: 500),
                        Summery = c.String(),
                        Body = c.String(storeType: "ntext"),
                        ParentId = c.Guid(),
                        IsActive = c.Boolean(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletionDate = c.DateTime(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Products", "ProductGroupId", c => c.Guid(nullable: false));
            DropColumn("dbo.Products", "UrlParam");
            CreateIndex("dbo.ProductGroups", "ParentId");
            CreateIndex("dbo.Products", "ProductGroupId");
            AddForeignKey("dbo.Products", "ProductGroupId", "dbo.ProductGroups", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProductGroups", "ParentId", "dbo.ProductGroups", "Id");
        }
    }
}
