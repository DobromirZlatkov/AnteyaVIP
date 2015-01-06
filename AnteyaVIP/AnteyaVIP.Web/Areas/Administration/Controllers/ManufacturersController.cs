namespace AnteyaVIP.Web.Areas.Administration.Controllers
{
    using System.Collections;
    using System.Web.Mvc;
    using System.Linq;

    using AnteyaVIP.Data;
    using AnteyaVIP.Web.Areas.Administration.Controllers.Base;
    using AnteyaVIP.Web.Infrastructure.Caching;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using Kendo.Mvc.UI;
    using Kendo.Mvc.Extensions;

    using Model = AnteyaVIP.Models.Manufacturer;
    using ViewModel = AnteyaVIP.Web.Areas.Administration.ViewModels.Manufacturers.ManufacturerViewModel;

    public class ManufacturersController : KendoGridAdministrationController
    {
        private readonly ICacheService service;

        public ManufacturersController(IAnteyaVIPData data, ICacheService service)
            : base(data)
        {
            this.service = service;
        }

        public ActionResult Index()
        {
            return View();
        }

        protected override IEnumerable GetData()
        {
            return this.Data
                .Manufacturers
                .All()
                .Project()
                .To<ViewModel>();
        }

        protected override T GetById<T>(object id)
        {
            return this.Data.Manufacturers.GetById(id) as T;
        }

        [HttpPost]
        public ActionResult Create([DataSourceRequest]DataSourceRequest request, ViewModel model)
        {
            if (this.Data.Manufacturers.All().Any(c => c.Name == model.Name))
            {
                this.ModelState.AddModelError("Unique", "Manufacturer already exists.");
            }
          
            var dbModel = base.Create<Model>(model);
            if (dbModel != null) model.Id = dbModel.Id;
   
            return this.GridOperation(model, request);
        }

        [HttpPost]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, ViewModel model)
        {
            base.Update<Model, ViewModel>(model, model.Id);
            return this.GridOperation(model, request);
        }

        [HttpPost]
        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, ViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var manufacturer = this.Data.Manufacturers.GetById(model.Id.Value);

                foreach (var productId in manufacturer.Products.Select(t => t.Id).ToList())
                {
                    this.Data.Products.Delete(productId);
                }

                this.Data.SaveChanges();

                this.Data.Manufacturers.Delete(manufacturer);
                this.Data.SaveChanges();
            }

            return this.GridOperation(model, request);
        }

        public JsonResult GetManufacturers()
        {
            var allManufacturers = this.GetData();
            return Json(allManufacturers, JsonRequestBehavior.AllowGet);
        }
    }
}