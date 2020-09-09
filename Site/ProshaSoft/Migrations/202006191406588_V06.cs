namespace Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V06 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MapDetails",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(),
                        X = c.Int(nullable: false),
                        Y = c.Int(nullable: false),
                        FirstLine = c.String(),
                        SecondtLine = c.String(),
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
            DropTable("dbo.MapDetails");
        }
    }
}
