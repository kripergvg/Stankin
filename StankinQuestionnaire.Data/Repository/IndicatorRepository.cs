using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StankinQuestionnaire.Data.Infrastructure;
using StankinQuestionnaire.Model;

namespace StankinQuestionnaire.Data.Repository
{
    public interface IIndicatorRepository : IRepository<Indicator>
    {
    }

    public class IndicatorRepository : RepositoryBase<Indicator>, IIndicatorRepository
    {
        public IndicatorRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
            //var db = databaseFactory.Get();
            //var testInd = new Indicator();
            //testInd.CalculationTypes.re
        }

        public override void Update(Indicator entity)
        {
            DataContext.Indicators.Attach(entity);
            DataContext.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            DataContext.Entry(entity).Property(indicator => indicator.DateCreated).IsModified = false;
        }
    }
}
