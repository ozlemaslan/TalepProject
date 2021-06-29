using ProjectApp.DataAccess.Mapping;
using ProjectApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
namespace ProjectApp.DataAccess
{
    public class TalepContext : DbContext
    {
        public TalepContext() : base("name=TalepConnStr")
        {
            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }



        public DbSet<User> Users { get; set; }
        public DbSet<Talep> Taleps { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.Add(new UserMapping()); 
            modelBuilder.Configurations.Add(new TalepMapping());

        }
    }
}
