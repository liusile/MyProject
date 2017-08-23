using Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.PermanentAssets;

namespace Domain
{
   public class StarDbContext: DbContext
    {
        
        public DbSet<User> User { set; get; }
        public DbSet<ProductType> ProductType { set; get; }
        public DbSet<Product> Product { set; get; }
        public DbSet<Test> Test { set; get; }
        public DbSet<Activity> Activity { set; get; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
