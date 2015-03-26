using StankinQuestionnaire.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StankinQuestionnaire.Data.Configuration
{
    public class ApplicationUserConfiguration : EntityTypeConfiguration<ApplicationUser>
    {
        public ApplicationUserConfiguration()
        {
            Property(c => c.Email).IsRequired().HasMaxLength(150);
            Property(c => c.Email).HasMaxLength(250);
            ToTable("Users");
        }
    }
}
