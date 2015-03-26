using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StankinQuestionnaire.Service;

namespace StankinQuestionnaire.Areas.Admin.Controllers
{
    public class IndicatorGroupController : Controller
    {
        private IIndicatorGroupService _indicatorGroupService;
        public IndicatorGroupController(IIndicatorGroupService indicatorGroupService)
        {
            this._indicatorGroupService = indicatorGroupService;
        }

        // GET: Admin/IndicatorGroup
        public ActionResult Index()
        {
            return View(_indicatorGroupService.GetIndicators());
        }
    }
}