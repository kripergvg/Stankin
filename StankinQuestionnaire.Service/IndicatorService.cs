using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StankinQuestionnaire.Data.Repository;
using StankinQuestionnaire.Model;
using System.Linq.Expressions;
using StankinQuestionnaire.Data.Infrastructure;

namespace StankinQuestionnaire.Service
{
    public interface IIndicatorService
    {
        Indicator GetIndicator(long indicatorID);
        IEnumerable<Indicator> GetIndicators(Expression<Func<Indicator, bool>> where = null);
        void CreateIndicator(Indicator indicator);
        void EditIndicator(Indicator indicator);
        void DeleteIndicator(Indicator indicator);
        IEnumerable<CalculationType> GetAllowCalculationType();
        void DeleteCalculationTypes(Indicator indicator);
    }

    public class IndicatorService : IIndicatorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IIndicatorRepository _indicatorRepository;
        private readonly ICalculationTypeRepository _calcuclationTypeRepository;
        public IndicatorService(IIndicatorRepository indicatorRepository, ICalculationTypeRepository calculationTypeRepository, IUnitOfWork unitOfWork)
        {
            this._indicatorRepository = indicatorRepository;
            this._unitOfWork = unitOfWork;
            this._calcuclationTypeRepository = calculationTypeRepository;
        }

        public IEnumerable<Indicator> GetIndicators(Expression<Func<Indicator, bool>> where = null)
        {
            return _indicatorRepository.GetMany(where);
        }

        public Indicator GetIndicator(long indicatorID)
        {
            return _indicatorRepository.GetById(indicatorID);
        }

        public void CreateIndicator(Indicator indicator)
        {
            _indicatorRepository.Add(indicator);
            SaveIndicator();
        }

        public void EditIndicator(Indicator indicator)
        {
            indicator.DateChanged = DateTime.Now;
            _indicatorRepository.Update(indicator);
            SaveIndicator();
        }

        public void DeleteIndicator(Indicator indicator)
        {
            //for (int i = 0; i < indicator.CalculationTypes.Count; i++)
            //{
            //    indicator.CalculationTypes.Remove(indicator.CalculationTypes[i]);
            //    i--;
            //}
            //_indicatorRepository.Delete(indicator);
            //SaveIndicator();
        }

        public IEnumerable<CalculationType> GetAllowCalculationType()
        {
            return _calcuclationTypeRepository.GetMany(ct => ct.Indicator == null);
        }

        public void DeleteCalculationTypes(Indicator indicator)
        {
            //for (int i = 0; i < indicator.CalculationTypes.Count; i++)
            //{
            //    indicator.CalculationTypes.Remove(indicator.CalculationTypes[i]);
            //    i--;
            //}
            //SaveIndicator();
        }

        private void SaveIndicator()
        {
            _unitOfWork.Commit();
        }
    }
}
