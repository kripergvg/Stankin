using StankinQuestionnaire.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StankinQuestionnaire.Areas.Admin.Controllers
{
    public class DocumentTypeController : AdminController
    {
        private IDocumentTypeService _documentTypeService;
        public DocumentTypeController(IDocumentTypeService documentTypeService)
        {
            this._documentTypeService = documentTypeService;
        }

        // GET: Admin/Document
        public ActionResult Index()
        {
            return View(_documentTypeService.GetDocumentTypes());
        }
    }
}