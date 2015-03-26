using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StankinQuestionnaire.Model;
using System.Data.Entity.ModelConfiguration;

namespace StankinQuestionnaire.Data.Configuration
{
   public class CustomUserRoleConfiguration:EntityTypeConfiguration<CustomUserRole>
    {
       public CustomUserRoleConfiguration()
       {
           ToTable("UserRoles");
       }
    }
}
