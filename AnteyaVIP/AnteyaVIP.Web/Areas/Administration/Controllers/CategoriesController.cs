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
    using AnteyaVIP.Web.Areas.Administration.ViewModels.Products;
    using AnteyaVIP.Web.Infrastructure.Populators;

    public class CategoriesController : KendoGridAdministrationController
    {
        private readonly IKendoDropDownListPopulator populator;

        public CategoriesController(IAnteyaVIPData data, IKendoDropDownListPopulator populator)
            : base(data)
        {
            this.populator = populator;
        }

        public ActionResult Index()
        {
            var categories = this.Data.Categories.All().Project().To<ViewModel>();

            populator.Categories = categories;

            return View(populator);
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
                var category = this.Data.Categories.GetById(model.Id.Value);

                foreach (var productId in category.Products.Select(t => t.Id).ToList())
                {
                    this.Data.Products.Delete(productId);
                }

                this.Data.SaveChanges();

                this.Data.Categories.Delete(category);
                this.Data.SaveChanges();
            }

            return this.GridOperation(model, request);
        }
    }
}