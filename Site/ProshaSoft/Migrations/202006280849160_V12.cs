namespace Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V12 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "TitleEn", c => c.String(nullable: false, maxLength: 200));
            AddColumn("dbo.Blogs", "SummeryEn", c => c.String(maxLength: 500));
            AddColumn("dbo.Blogs", "BodyEn", c => c.String(storeType: "ntext"));
            AddColumn("dbo.Blogs", "PageTitleEn", c => c.String(nullable: false, maxLength: 200));
            AddColumn("dbo.Blogs", "PageDescriptionEn", c => c.String(maxLength: 500));
            AddColumn("dbo.Costumers", "TitleEn", c => c.String(nullable: false, maxLength: 200));
            AddColumn("dbo.MapDetails", "TitleEn", c => c.String(nullable: false, maxLength: 200));
            AddColumn("dbo.MapDetails", "FirstLineEn", c => c.String(nullable: false, maxLength: 200));
            AddColumn("dbo.MapDetails", "SecondtLineEn", c => c.String(nullable: false, maxLength: 200));
            AddColumn("dbo.MiniSliders", "Title", c => c.String());
            AddColumn("dbo.MiniSliders", "TitleEn", c => c.String(nullable: false, maxLength: 200));
            AddColumn("dbo.Products", "TitleEn", c => c.String(nullable: false, maxLength: 200));
            AddColumn("dbo.Products", "PageTitleEn", c => c.String(nullable: false, maxLength: 200));
            AddColumn("dbo.Products", "PageDescriptionEn", c => c.String(maxLength: 500));
            AddColumn("dbo.Products", "SummeryEn", c => c.String(maxLength: 500));
            AddColumn("dbo.Products", "BodyEn", c => c.String(storeType: "ntext"));
            AddColumn("dbo.ProductFeatures", "KeyEn", c => c.String(nullable: false, maxLength: 200));
            AddColumn("dbo.ProductFeatures", "ValueEn", c => c.String());
            AddColumn("dbo.Sliders", "TitleEn", c => c.String(nullable: false, maxLength: 200));
            AddColumn("dbo.Sliders", "SummaryEn", c => c.String(maxLength: 500));
            AddColumn("dbo.Sliders", "LinkTitleEn", c => c.String(nullable: false, maxLength: 200));
            AddColumn("dbo.Sliders", "LinkTitle2En", c => c.String(nullable: false, maxLength: 200));
            AddColumn("dbo.TextTypeItems", "TitleEn", c => c.String(nullable: false, maxLength: 200));
            AddColumn("dbo.TextTypeItems", "SummeryEn", c => c.String(maxLength: 500));
            AddColumn("dbo.TextTypeItems", "BodyEn", c => c.String(storeType: "ntext"));
            AddColumn("dbo.TextTypes", "TitleEn", c => c.String(nullable: false, maxLength: 200));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TextTypes", "TitleEn");
            DropColumn("dbo.TextTypeItems", "BodyEn");
            DropColumn("dbo.TextTypeItems", "SummeryEn");
            DropColumn("dbo.TextTypeItems", "TitleEn");
            DropColumn("dbo.Sliders", "LinkTitle2En");
            DropColumn("dbo.Sliders", "LinkTitleEn");
            DropColumn("dbo.Sliders", "SummaryEn");
            DropColumn("dbo.Sliders", "TitleEn");
            DropColumn("dbo.ProductFeatures", "ValueEn");
            DropColumn("dbo.ProductFeatures", "KeyEn");
            DropColumn("dbo.Products", "BodyEn");
            DropColumn("dbo.Products", "SummeryEn");
            DropColumn("dbo.Products", "PageDescriptionEn");
            DropColumn("dbo.Products", "PageTitleEn");
            DropColumn("dbo.Products", "TitleEn");
            DropColumn("dbo.MiniSliders", "TitleEn");
            DropColumn("dbo.MiniSliders", "Title");
            DropColumn("dbo.MapDetails", "SecondtLineEn");
            DropColumn("dbo.MapDetails", "FirstLineEn");
            DropColumn("dbo.MapDetails", "TitleEn");
            DropColumn("dbo.Costumers", "TitleEn");
            DropColumn("dbo.Blogs", "PageDescriptionEn");
            DropColumn("dbo.Blogs", "PageTitleEn");
            DropColumn("dbo.Blogs", "BodyEn");
            DropColumn("dbo.Blogs", "SummeryEn");
            DropColumn("dbo.Blogs", "TitleEn");
        }
    }
}
