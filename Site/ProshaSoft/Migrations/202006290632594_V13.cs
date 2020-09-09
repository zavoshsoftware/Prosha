namespace Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V13 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Blogs", "TitleEn", c => c.String(maxLength: 200));
            AlterColumn("dbo.Blogs", "PageTitleEn", c => c.String(maxLength: 200));
            AlterColumn("dbo.Costumers", "TitleEn", c => c.String(maxLength: 200));
            AlterColumn("dbo.MapDetails", "TitleEn", c => c.String(maxLength: 200));
            AlterColumn("dbo.MapDetails", "FirstLineEn", c => c.String(maxLength: 200));
            AlterColumn("dbo.MapDetails", "SecondtLineEn", c => c.String(maxLength: 200));
            AlterColumn("dbo.MiniSliders", "TitleEn", c => c.String(maxLength: 200));
            AlterColumn("dbo.Products", "TitleEn", c => c.String(maxLength: 200));
            AlterColumn("dbo.Products", "PageTitleEn", c => c.String(maxLength: 200));
            AlterColumn("dbo.ProductFeatures", "KeyEn", c => c.String(maxLength: 200));
            AlterColumn("dbo.Sliders", "TitleEn", c => c.String(maxLength: 200));
            AlterColumn("dbo.Sliders", "LinkTitleEn", c => c.String(maxLength: 200));
            AlterColumn("dbo.Sliders", "LinkTitle2En", c => c.String(maxLength: 200));
            AlterColumn("dbo.TextTypeItems", "TitleEn", c => c.String(maxLength: 200));
            AlterColumn("dbo.TextTypes", "TitleEn", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TextTypes", "TitleEn", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.TextTypeItems", "TitleEn", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Sliders", "LinkTitle2En", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Sliders", "LinkTitleEn", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Sliders", "TitleEn", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.ProductFeatures", "KeyEn", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Products", "PageTitleEn", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Products", "TitleEn", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.MiniSliders", "TitleEn", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.MapDetails", "SecondtLineEn", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.MapDetails", "FirstLineEn", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.MapDetails", "TitleEn", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Costumers", "TitleEn", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Blogs", "PageTitleEn", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Blogs", "TitleEn", c => c.String(nullable: false, maxLength: 200));
        }
    }
}
