namespace Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V17 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductCounters", "Value", c => c.String());
            AddColumn("dbo.ProductCounters", "ValueEN", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductCounters", "ValueEN");
            DropColumn("dbo.ProductCounters", "Value");
        }
    }
}
