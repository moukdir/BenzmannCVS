using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Benzmann.BuisnessLogic;
using Benzmann.Definitions;
using Benzmann.Definitions.Services;
using Benzmann.BuisnessLogic.MyClub;


namespace MyClub.Controllers
{
    public class GalleryController : BaseController
    {
        //
        // GET: /Gallery/

        public ActionResult Index()
        {
            this.Initialize();
            LadiesServices ladyService = this.appContext.GetService<LadiesServices>(new GetIServiceFromCacheDelegate(this.GetServiceFromCache));
            return View(ladyService.GetAllLadies());
        }
    }
}
