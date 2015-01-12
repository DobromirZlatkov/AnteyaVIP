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

    using Model = AnteyaVIP.Models.Category;
    using ViewModel = AnteyaVIP.Web.Areas.Administration.ViewModels.Categories.CategoryViewModel;
    using AnteyaVIP.Web.Areas.Administration.ViewModels.Categories;

    public class CategoriesController : KendoGridAdministrationController
    {
        private readonly ICacheService service;

        public CategoriesController(IAnteyaVIPData data, ICacheService service)
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
                .Categories
                .All()
                .Project()
                .To<ViewModel>();
        }

        protected override T GetById<T>(object id)
        {
            return this.Data.Categories.GetById(id) as T;
        }

        [HttpPost]
        public ActionResult Create([DataSourceRequest]DataSourceRequest request, ViewModel model)
        {      
            var dbModel = base.Create<Model>(model);
            if (dbModel != null) model.Id = dbModel.Id;
            this.ClearCategoryCache();       
            return this.GridOperation(model, request);
        }

        [HttpPost]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, ViewModel model)
        {
            base.Update<Model, ViewModel>(model, model.Id);
            this.ClearCategoryCache();
            return this.GridOperation(model, request);
        }

        [HttpPost]
        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, ViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var category = this.Data.Categories.GetById(model.Id.Value);

                foreach (var productId in category.Products.Select(t => t.Id).ToList())
                {
                    this.Data.Products.Delete(productId);
                }

                this.Data.SaveChanges();

                this.Data.Categories.Delete(category);
                this.Data.SaveChanges();
            }

            this.ClearCategoryCache();
            return this.GridOperation(model, request);
        }

        private void ClearCategoryCache()
        {
            this.service.Clear("categories");
        }
    }
}