namespace Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V01 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BlogComments",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(maxLength: 200),
                        Email = c.String(maxLength: 256),
                        Message = c.String(nullable: false),
                        Response = c.String(),
                        BlogId = c.Guid(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletionDate = c.DateTime(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Blogs", t => t.BlogId, cascadeDelete: true)
                .Index(t => t.BlogId);
            
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(),
                        Summery = c.String(),
                        ImageUrl = c.String(),
                        UrlParam = c.String(),
                        Visit = c.Int(nullable: false),
                        Body = c.String(storeType: "ntext"),
                        PageTitle = c.String(),
                        PageDescription = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletionDate = c.DateTime(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ContactUsForms",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 300),
                        Email = c.String(nullable: false, maxLength: 300),
                        Message = c.String(nullable: false, storeType: "ntext"),
                        Ip = c.String(nullable: false, maxLength: 50),
                        Phone = c.String(nullable: false, maxLength: 300),
                        Country = c.String(nullable: false, maxLength: 300),
                        IsActive = c.Boolean(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletionDate = c.DateTime(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductComments",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(maxLength: 200),
                        Email = c.String(maxLength: 256),
                        Message = c.String(nullable: false),
                        Response = c.String(),
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
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Order = c.Int(nullable: false),
                        Code = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 256),
                        PageTitle = c.String(maxLength: 500),
                        PageDescription = c.String(maxLength: 1000),
                        ImageUrl = c.String(maxLength: 500),
                        Summery = c.String(),
                        Body = c.String(storeType: "ntext"),
                        ProductGroupId = c.Guid(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletionDate = c.DateTime(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductGroups", t => t.ProductGroupId, cascadeDelete: true)
                .Index(t => t.ProductGroupId);
            
            CreateTable(
                "dbo.ProductFeatures",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Key = c.String(),
                        Value = c.String(),
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductGroups", t => t.ParentId)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(nullable: false),
                        Name = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletionDate = c.DateTime(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Username = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        LastLoginDate = c.DateTime(),
                        RoleId = c.Guid(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletionDate = c.DateTime(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Sliders",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(maxLength: 200),
                        Summary = c.String(maxLength: 600),
                        LinkTitle = c.String(maxLength: 200),
                        LinkAddress = c.String(maxLength: 200),
                        LinkTitle2 = c.String(maxLength: 200),
                        LinkAddress2 = c.String(maxLength: 200),
                        ImageUrl = c.String(maxLength: 200),
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
                "dbo.Teams",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FullName = c.String(),
                        Post = c.String(),
                        Summery = c.String(),
                        ImageUrl = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletionDate = c.DateTime(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TextTypeItems",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(maxLength: 200),
                        Body = c.String(storeType: "ntext"),
                        ImageUrl = c.String(maxLength: 200),
                        TextTypeId = c.Guid(nullable: false),
                        Name = c.String(maxLength: 100),
                        IsActive = c.Boolean(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletionDate = c.DateTime(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TextTypes", t => t.TextTypeId, cascadeDelete: true)
                .Index(t => t.TextTypeId);
            
            CreateTable(
                "dbo.TextTypes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(maxLength: 200),
                        IsActive = c.Boolean(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletionDate = c.DateTime(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TextTypeItems", "TextTypeId", "dbo.TextTypes");
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Products", "ProductGroupId", "dbo.ProductGroups");
            DropForeignKey("dbo.ProductGroups", "ParentId", "dbo.ProductGroups");
            DropForeignKey("dbo.ProductFeatures", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductComments", "ProductId", "dbo.Products");
            DropForeignKey("dbo.BlogComments", "BlogId", "dbo.Blogs");
            DropIndex("dbo.TextTypeItems", new[] { "TextTypeId" });
            DropIndex("dbo.Users", new[] { "RoleId" });
            DropIndex("dbo.ProductGroups", new[] { "ParentId" });
            DropIndex("dbo.ProductFeatures", new[] { "ProductId" });
            DropIndex("dbo.Products", new[] { "ProductGroupId" });
            DropIndex("dbo.ProductComments", new[] { "ProductId" });
            DropIndex("dbo.BlogComments", new[] { "BlogId" });
            DropTable("dbo.TextTypes");
            DropTable("dbo.TextTypeItems");
            DropTable("dbo.Teams");
            DropTable("dbo.Sliders");
            DropTable("dbo.Users");
            DropTable("dbo.Roles");
            DropTable("dbo.ProductGroups");
            DropTable("dbo.ProductFeatures");
            DropTable("dbo.Products");
            DropTable("dbo.ProductComments");
            DropTable("dbo.ContactUsForms");
            DropTable("dbo.Blogs");
            DropTable("dbo.BlogComments");
        }
    }
}
