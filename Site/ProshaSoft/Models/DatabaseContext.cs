using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace Models
{
   public class DatabaseContext:DbContext
    {
        static DatabaseContext()
        {
             System.Data.Entity.Database.SetInitializer(new MigrateDatabaseToLatestVersion<DatabaseContext, Migrations.Configuration>());
        }

        public DbSet<Slider> Sliders { get; set; }
        public DbSet<TextType> TextTypes { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<TextTypeItem> TextTypeItems { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ContactUsForm> ContactUsForms { get; set; }
        public DbSet<ProductComment> ProductComments { get; set; }
        public DbSet<BlogComment> BlogComments { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }
        public DbSet<MapDetail> MapDetails { get; set; }
        public DbSet<MiniSlider> MiniSliders { get; set; }
        public DbSet<Costumer> Costumers { get; set; }
        public DbSet<BlogGroup> BlogGroups { get; set; }
        public DbSet<ProductCounter> ProductCounters { get; set; }
        public DbSet<PageGroup> PageGroups { get; set; }
        public DbSet<Page> Pages { get; set; }


    }
}
