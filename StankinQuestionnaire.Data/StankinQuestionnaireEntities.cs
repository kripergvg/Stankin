using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Microsoft.AspNet.Identity.EntityFramework;
using StankinQuestionnaire.Model;

namespace StankinQuestionnaire.Data
{
    public class StankinQuestionnaireEntities : IdentityDbContext<ApplicationUser, CustomRole, long, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public StankinQuestionnaireEntities()
        {
            this.Configuration.LazyLoadingEnabled = true;
            this.Configuration.ProxyCreationEnabled = true;
        }

        public DbSet<Сalculation> Calculations { get; set; }
        public DbSet<Indicator> Indicators { get; set; }
        public DbSet<IndicatorGroup> IndicatorGroups { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<CalculationType> CalculationTypes { get; set; }
        public DbSet<TestEntity> TestEntitys { get; set; }
        
        public virtual void Commit()
        {
            base.SaveChanges();
        }
    }
}
