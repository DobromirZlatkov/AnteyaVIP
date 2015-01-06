//namespace AnteyaVIP.Web.Areas.Administration.Controllers
//{
//    using System.Collections.Generic;
//    using System.IO;
//    using System.Net;
//    using System.Web;
//    using System.Web.Mvc;
//    using System.Linq;

//    using AutoMapper;

//    using AnteyaVIP.Data;
//    using AnteyaVIP.Models;
//    using AnteyaVIP.Web.Areas.Administration.Controllers.Base;
//    using AnteyaVIP.Web.Areas.Administration.ViewModels.Products;
//    using AnteyaVIP.Web.Infrastructure.Populators;

//    public class ProductsController : AdminController
//    {
//        private const int ProductsListPageSize = 5;
//        private IDropDownListPopulator populator;


//        public ProductsController(IAnteyaVIPData data, DropDownListPopulator populator)
//            : base(data)
//        {
//            this.populator = populator;
//        }

//        // GET: Administration/Products
//        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
//        {
//            return View();
//        }

//        [HttpGet]
//        public ActionResult Create()
//        {
//            var productInputModel = new ProductInputModel
//            {
//                Manufacturers = this.populator.GetAllManufacturers(),
//                Categories = this.populator.GetAllCategories()
//            };

//            return View(productInputModel);
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create(ProductInputModel inputProduct)
//        {
//            if (inputProduct != null && ModelState.IsValid)
//            {
//                var newProduct = Mapper.Map<Product>(inputProduct);

//                if (inputProduct.UploadedImages != null)
//                {
//                    foreach (var image in inputProduct.UploadedImages)
//                    {
//                        var currentImage = new Picture 
//                        {
//                            File = image,
//                            FileExtension = image.FileName.Split(new[] { '.' }).Last()
//                        };
        
//                        newProduct.Pictures.Add(currentImage);
//                    }
//                }

//                this.Data.Products.Add(newProduct);
//                this.Data.SaveChanges();
//              //  return View("Update", newProduct.Id);
//                return RedirectToAction("Update/"+newProduct.Id);
//            }

//            inputProduct.Manufacturers = this.populator.GetAllManufacturers();
//            inputProduct.Categories = this.populator.GetAllCategories();
//            return View(inputProduct);
//        }

//        // GET: Products/Update/5
//        [HttpGet]
//        public ActionResult Update(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }

//            var product = this.Data.Products.GetById(id);

//            //to do add admin product view model

//            var newProduct = Mapper.Map<ProductUpdateModel>(product);
//            newProduct.Manufacturers = this.populator.GetAllManufacturers();
//            newProduct.Categories = this.populator.GetAllCategories();

//            if (product == null)
//            {
//                return HttpNotFound();
//            }

//            return View(newProduct);
//        }

//        [HttpPost]
//        public ActionResult Update(ProductUpdateModel updateProduct, int id)
//        {
  
//            var product = this.Data.Products.GetById(id);

//            //to do add admin product view model

//            if (product == null)
//            {
//                return HttpNotFound();
//            }

//            return View(product);
//        }
//    }
//}


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

        public ProductsController(IAnteyaVIPData data)
            : base(data)
        {
        }


        public ActionResult Index()
        {
            ProductForeignKeyValues Values = new ProductForeignKeyValues();

            var categories = this.Data.Categories.All().Project().To<CategoryViewModel>();
            var manufacturers = this.Data.Manufacturers.All().Project().To<ManufacturerViewModel>();
            //var pictures = this.Data.Pictures.All();

            //Values.Pictures = pictures;
            Values.Categories = categories;
            Values.Manufacturers = manufacturers;

            return View(Values);
        }

        protected override IEnumerable GetData()
        { 
            return this.Data
             .Products
             .All()
             .Project()
             .To<ViewModel>().ToList();
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
            base.Update<Model, ViewModel>(model, model.Id);
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