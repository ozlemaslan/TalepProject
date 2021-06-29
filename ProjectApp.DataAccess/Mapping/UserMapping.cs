using ProjectApp.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectApp.DataAccess.Mapping
{
    public class UserMapping: EntityTypeConfiguration<User>
    {
        public UserMapping()
        {
            
            Property(a => a.Email)
               .HasMaxLength(100)
               .IsRequired();


        }
    }
}
