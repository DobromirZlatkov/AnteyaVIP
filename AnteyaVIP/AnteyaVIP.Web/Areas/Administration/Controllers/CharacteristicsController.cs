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

    using Model = AnteyaVIP.Models.Characteristic;
    using ViewModel = AnteyaVIP.Web.Areas.Administration.ViewModels.Characteristics.CharacteristicViewModel;


    public class CharacteristicsController : KendoGridAdministrationController
    {
        private readonly ICacheService service;

        public CharacteristicsController(IAnteyaVIPData data, ICacheService service)
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
               .Characteristics
               .All()
               .Project()
               .To<ViewModel>();
        }

        protected override T GetById<T>(object id)
        {
            return this.Data.Characteristics.GetById(id) as T;
        }

        [HttpPost]
        public ActionResult Read_ProductCharacteristics(int productId, [DataSourceRequest]DataSourceRequest request)
        {
            var ads = this.Data.Characteristics.All()
                .Where(c => c.ProductId == productId)
                .Project()
                .To<ViewModel>()
                .ToDataSourceResult(request);

            return this.Json(ads);
        }

        [HttpPost]
        public ActionResult Create(int productId, [DataSourceRequest]DataSourceRequest request, ViewModel model)
        {
            var currentProduct = this.Data.Products.GetById(productId);

            var dbModel = Mapper.Map<Model>(model);
            currentProduct.Characteristics.Add(dbModel);
            this.Data.SaveChanges();

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
                this.Data.Characteristics.Delete(model.Id.Value);
                this.Data.SaveChanges();
            }

            return this.GridOperation(model, request);
        }
    }
}