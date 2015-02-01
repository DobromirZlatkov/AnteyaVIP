namespace AnteyaVIP.Web.Controllers
{
    using System.Web.Mvc;
    using System.Linq;

    using AnteyaVIP.Data;
    using AnteyaVIP.Web.Controllers.Base;
    using AnteyaVIP.Web.Infrastructure.Services.Contracts;
    using AnteyaVIP.Web.Infrastructure.Services;

    public class CategoriesController : BaseController
    {
        ICategoryServices categoryServices;

        public CategoriesController(IAnteyaVIPData data, CategoryServices categoryServices)
            : base(data)
        {
            this.categoryServices = categoryServices;
        }

        public JsonResult GetCategories(int? id)
        {
            var categories = categoryServices.GetAllCategories(id);
            return Json(categories, JsonRequestBehavior.AllowGet);
        }
     
    }
}