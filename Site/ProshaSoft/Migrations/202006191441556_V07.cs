namespace Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V07 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sliders", "IsVideoLink", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sliders", "IsVideoLink");
        }
    }
}
