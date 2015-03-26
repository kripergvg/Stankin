using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StankinQuestionnaire.Data.Infrastructure;
using StankinQuestionnaire.Model;

namespace StankinQuestionnaire.Data.Repository
{
    public interface ICalculationRepository : IRepository<Сalculation>
    {

    }

    public class CalculationRepository : RepositoryBase<Сalculation>, ICalculationRepository
    {
        public CalculationRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }

    }
}
