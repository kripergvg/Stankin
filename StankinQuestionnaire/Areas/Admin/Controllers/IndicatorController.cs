using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StankinQuestionnaire.Service;
using StankinQuestionnaire.Areas.Admin.Models;
using AutoMapper;
using StankinQuestionnaire.Models;
using StankinQuestionnaire.Model;
using StankinQuestionnaire.Web.Core.Status;

namespace StankinQuestionnaire.Areas.Admin.Controllers
{
    public class IndicatorController : Controller
    {
        private IIndicatorService _indicatorService;
        private ICalculationTypeService _calculationTypeService;
        public IndicatorController(IIndicatorService indicatorService, ICalculationTypeService calculationTypeService)
        {
            this._indicatorService = indicatorService;
            this._calculationTypeService = calculationTypeService;
        }

        public ActionResult Index()
        {
            var indicatorViewModel = new IndicatorViewModel();
            var indicators = _indicatorService.GetIndicators();
            var indicatorsDetails = Mapper.Map<IEnumerable<Indicator>, IEnumerable<IndicatorFormModel>>(indicators);
            var calculationTypes = _calculationTypeService.GetCalculationsTypeWithIndicator();
            foreach (var indicator in indicatorsDetails)
            {
                indicator.CalculationTypes = calculationTypes.Where(ct => ct.Indicator != null
                    && ct.Indicator.ID == indicator.ID)
                    .Select(ct => new SelectListItem
                {
                    Value = ct.ID.ToString(),
                    Text = ct.UnitName,
                    Selected = ct.Indicator == null ? false : ct.Indicator.ID == indicator.ID
                });
            }
            indicatorViewModel.Indicators = indicatorsDetails;
            indicatorViewModel.CalculationTypeSelect = Mapper.Map<IEnumerable<CalculationType>, IEnumerable<CalculationTypeSelect>>
                (calculationTypes.Where(ct => ct.Indicator == null)).ToList();
            return View(indicatorViewModel);
        }

        [HttpPost]
        public ActionResult Add(IndicatorAddModel addIndicator)
        {
            var indicator = Mapper.Map<IndicatorAddModel, Indicator>(addIndicator);
            indicator.CalculationTypes = _calculationTypeService.GetCalculationTypes(ct => addIndicator.CalculationTypeSelect.Contains(ct.ID)).ToList();
            if (ModelState.IsValid)
            {
                _indicatorService.CreateIndicator(indicator);
                this.AddStatus("Успешно добавлен!");
                return RedirectToAction("Index");
            }
            return null;
        }

        [HttpPost]
        public JsonResult Edit(IndicatorEditModel editIndicator)
        {
            var indicator = Mapper.Map<IndicatorEditModel, Indicator>(editIndicator);
            //  _indicatorService.GetIndicator(editIndicator.ID);
            if (ModelState.IsValid)
            {
                _indicatorService.EditIndicator(indicator);
                if (editIndicator.CalculationTypes == null)
                {
                    _indicatorService.DeleteCalculationTypes(indicator);
                }
                else
                {
                    _calculationTypeService.UpdateIndicator(editIndicator.CalculationTypes, indicator.ID);
                }

                editIndicator.DateChanged = indicator.DateChanged.ToString();
                editIndicator.DateCreated = indicator.DateCreated.ToString();
                return Json(new EntityJson { Entity = editIndicator, Text = "Успешно изменен!", Status = EntityStatus.SUCCESS });
            }
            return Json(new EntityJson { Entity = editIndicator, Text = "Вы ввели не правильные данные!", Status = EntityStatus.ERROR });
        }

        [HttpPost]
        public JsonResult Delete(long ID)
        {
            var indicator = _indicatorService.GetIndicator(ID);
            if (indicator != null)
            {
                _indicatorService.DeleteIndicator(indicator);
                return Json(new IDJson<long> { ID = ID, Text = "Успешно удален!", Status = EntityStatus.SUCCESS });
            }
            return Json(new IDJson<long> { ID = ID, Text = "Вы ввели не правильные данные!", Status = EntityStatus.ERROR });
        }
    }
}