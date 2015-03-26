using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StankinQuestionnaire.Data.Infrastructure;
using StankinQuestionnaire.Model;

namespace StankinQuestionnaire.Data.Repository
{
    public interface IIndicatorGroupRepository : IRepository<IndicatorGroup>
    {

    }
    public class IndicatorGroupRepository : RepositoryBase<IndicatorGroup>, IIndicatorGroupRepository
    {
        public IndicatorGroupRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }
    }
}
