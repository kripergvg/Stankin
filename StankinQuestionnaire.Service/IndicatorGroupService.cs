using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StankinQuestionnaire.Model;
using System.Linq.Expressions;
using StankinQuestionnaire.Data.Repository;

namespace StankinQuestionnaire.Service
{
    public interface IIndicatorGroupService
    {
        IEnumerable<IndicatorGroup> GetIndicators(Expression<Func<IndicatorGroup, bool>> where = null);
    }

    public class IndicatorGroupService : IIndicatorGroupService
    {
        private readonly IIndicatorGroupRepository _indicatorGroupRepository;
        public IndicatorGroupService(IIndicatorGroupRepository indicatorGroupRepository)
        {
            this._indicatorGroupRepository = indicatorGroupRepository;
        }

        public IEnumerable<IndicatorGroup> GetIndicators(Expression<Func<IndicatorGroup, bool>> where = null)
        {
            return _indicatorGroupRepository.GetMany(where);
        }
    }
}
