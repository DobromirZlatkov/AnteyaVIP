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

    using Model = AnteyaVIP.Models.Product;
    using ViewModel = AnteyaVIP.Web.Areas.Administration.ViewModels.Products.ProductInputModel;

    using AnteyaVIP.Web.Areas.Administration.ViewModels.Products;
    using AnteyaVIP.Web.Infrastructure.Populators;
    using AnteyaVIP.Web.Areas.Administration.ViewModels.Categories;
    using AnteyaVIP.Web.Areas.Administration.ViewModels.Manufacturers;

    public class ProductsController : KendoGridAdministrationController
    {
        private readonly IKendoDropDownListPopulator populator;

        public ProductsController(IAnteyaVIPData data, IKendoDropDownListPopulator populator)
            : base(data)
        {
            this.populator = populator;
        }


        public ActionResult Index()
        {

            var categories = this.Data.Categories.All().Project().To<CategoryViewModel>();
            var manufacturers = this.Data.Manufacturers.All().Project().To<ManufacturerViewModel>();

            populator.Categories = categories;
            populator.Manufacturers = manufacturers;

            return View(populator);
        }

        protected override IEnumerable GetData()
        { 
            return this.Data
             .Products
             .All()
             .Project()
             .To<ViewModel>();
        }

        protected override T GetById<T>(object id)
        {
            return this.Data.Products.GetById(id) as T;
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
            if (model.Id == null)
            {
                this.Create(request, model);
            }
            else
            {
                base.Update<Model, ViewModel>(model, model.Id);
            }

            return this.GridOperation(model, request);  
        }


        [HttpPost]
        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, ViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var product = this.Data.Products.GetById(model.Id.Value);

                foreach (var productId in product.Characteristics.Select(t => t.Id).ToList())
                {
                    this.Data.Characteristics.Delete(productId);
                }

                this.Data.SaveChanges();

                foreach (var pictureId in product.Pictures.Select(t => t.Id).ToList())
                {
                    this.Data.Pictures.Delete(pictureId);
                }

                this.Data.SaveChanges();

                this.Data.Products.Delete(product);

                this.Data.SaveChanges();
            }

            return this.GridOperation(model, request);
        }
    }
}