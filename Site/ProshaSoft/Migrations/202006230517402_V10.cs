namespace Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V10 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MiniSliders", "Type", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MiniSliders", "Type");
        }
    }
}
