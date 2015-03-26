using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StankinQuestionnaire.Data.Infrastructure;
using StankinQuestionnaire.Model;
using System.Linq.Expressions;
using System.Data.Entity;

namespace StankinQuestionnaire.Data.Repository
{
    public interface ICalculationTypeRepository : IRepository<CalculationType>
    {
        IEnumerable<CalculationType> GetManyWithIndicator(Expression<Func<CalculationType, bool>> where = null);
        void UpdateIndicator(IEnumerable<long> calculationTypeIds, long indicatorID);
    }

    public class CalculationTypeRepository : RepositoryBase<CalculationType>, ICalculationTypeRepository
    {

        public CalculationTypeRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }

        public IEnumerable<CalculationType> GetManyWithIndicator(Expression<Func<CalculationType, bool>> where = null)
        {
            if (where == null)
            {
                return DataContext.CalculationTypes.Include(ct => ct.Indicator).ToList();
            }
            return DataContext.CalculationTypes.Include(ct => ct.Indicator).ToList();
        }

        public void UpdateIndicator(IEnumerable<long> calculationTypeIds, long indicatorID)
        {
            //var proxy = DataContext.Configuration.ProxyCreationEnabled;
            //var 
            var indicator = DataContext.Indicators.FirstOrDefault(i => i.ID == indicatorID);
            var test = DataContext.CalculationTypes.FirstOrDefault();




















            //var indicatorCalcTypes = indicator.CalculationTypes;
            //foreach (var indCalcType in indicatorCalcTypes)
            //{
            //    if (!calculationTypeIds.Contains(indCalcType.ID))
            //    {
            //        indicator.CalculationTypes.Remove(indCalcType);
            //    }
            //}
            //foreach (var calcType in calculationTypeIds)
            //{
            //    if (!indicatorCalcTypes.Select(indCalcType => indCalcType.ID).Contains(calcType))
            //    {
            //        var currentCalcType = DataContext.CalculationTypes.Find(calcType);
            //        indicator.CalculationTypes.Add(currentCalcType);
            //    }
            //}
        }
    }
}
