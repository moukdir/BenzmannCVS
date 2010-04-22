using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Benzmann.BuisnessLogic;
using Benzmann.Definitions;
using Benzmann.Definitions.Exceptions;
using Benzmann.Definitions.Services;
using Benzmann.BuisnessLogic.MyClub;

namespace MyClub.Controllers
{
    public class LadyController : BaseController
    {
        //
        // GET: /Lady/

        public ActionResult Index(int id)
        {
            this.Initialize();
            LadiesServices ladyService = this.appContext.GetService<LadiesServices>(new GetIServiceFromCacheDelegate(this.GetServiceFromCache));
            return View(ladyService.GetById(id));
        }

        public FileResult GetImage(int id, int width, int height, int filling, string red, string green, string blue)
        {
            this.Initialize();
            Regex regex = new Regex("^$|^[0-9a-z]{2}$", RegexOptions.IgnoreCase);
            if(!regex.IsMatch(red) || !regex.IsMatch(green) || !regex.IsMatch(blue))
                throw this.appContext.CreateException<MyClubException>("LadyController->FileResult() - Wasn't a color code: #" + red +green + blue);
            int redNumber = 0;
            if(red.Length == 2)
                redNumber = Convert.ToInt32("0x" + red, 16);
            int greenNumber = 0;
            if (green.Length == 2)
                greenNumber = Convert.ToInt32("0x" + green, 16);
            int blueNumber = 0;
            if (blue.Length == 2)
                blueNumber = Convert.ToInt32("0x" + blue, 16);
            LadiesServices ladyService = this.appContext.GetService<LadiesServices>(new GetIServiceFromCacheDelegate(this.GetServiceFromCache));
            return new FileStreamResult(ImageURIHelper.GetFromCache(this.appContext, ladyService.GetImageById(id), new ImageResolution((uint)width, (uint)height), filling == 1 ? true : false, redNumber, greenNumber, blueNumber), "image/jpeg");
        }
    }
}
