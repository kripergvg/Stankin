using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using StankinQuestionnaire.Model;

namespace StankinQuestionnaire.Data.Configuration
{
    public class CustomRoleConfiguration : EntityTypeConfiguration<CustomRole>
    {
        public CustomRoleConfiguration()
        {
            ToTable("Roles");
        }
    }
}
