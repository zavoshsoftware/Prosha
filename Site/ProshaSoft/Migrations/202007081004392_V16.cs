namespace Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V16 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductCounters",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Key = c.String(),
                        KeyEN = c.String(),
                        ProductId = c.Guid(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletionDate = c.DateTime(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductCounters", "ProductId", "dbo.Products");
            DropIndex("dbo.ProductCounters", new[] { "ProductId" });
            DropTable("dbo.ProductCounters");
        }
    }
}
