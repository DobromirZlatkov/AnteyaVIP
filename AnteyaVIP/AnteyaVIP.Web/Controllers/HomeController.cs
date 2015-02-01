using AnteyaVIP.Data;
using AnteyaVIP.Web.Controllers.Base;
using AnteyaVIP.Web.Infrastructure.Services;
using AnteyaVIP.Web.Infrastructure.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnteyaVIP.Web.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IAnteyaVIPData data, ProductServices productServices)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            //var test = CultureInfo.GetCultures(CultureTypes.SpecificCultures)
            //           .Select(x => new RegionInfo(x.LCID).NativeName)
            //           .Distinct()
            //           .OrderBy(x => x);

            //var test22 = test.ToList();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}