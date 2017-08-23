using Domain.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ChenHuiDbContext : DbContext
    {
        public DbSet<UserInfo> UserInfo { set; get; }
        public DbSet<StockRecord> StockRecord { set; get; }
        public DbSet<SysFlowNo> SysFlowNo { set; get; }
         
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
