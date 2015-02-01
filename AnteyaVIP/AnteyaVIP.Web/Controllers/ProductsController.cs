namespace AnteyaVIP.Web.Controllers
{
    using System;
    using System.Web.Mvc;
    using System.Web;
    using System.Linq;

    using Kendo.Mvc.UI;
    using Kendo.Mvc.Extensions;

    using AutoMapper.QueryableExtensions;

    using AnteyaVIP.Models;
    using AnteyaVIP.Data;
    using AnteyaVIP.Web.Controllers.Base;
    using AnteyaVIP.Web.Infrastructure.Services.Contracts;
    using AnteyaVIP.Web.Infrastructure.Services;
    using AnteyaVIP.Web.ViewModels.Products;

    public class ProductsController : BaseController
    {
        private const int NumberOfProductsToShow = 10;

        IProductServices productServices;

        public ProductsController(IAnteyaVIPData data, ProductServices productServices)
            : base(data)
        {
            this.productServices = productServices;
        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                //TO DO;
            }
            var product = this.Data.Products.All()
                .Where(p => p.Id == id)
                .Project()
                .To<ProductDetailsViewModel>().FirstOrDefault();
            return View(product);
        }

        public JsonResult GetProductData(string text)
        {
            var products = this.productServices.GetProductsByMatchWord(text);
            return this.Json(products, JsonRequestBehavior.AllowGet);
        }

        public ActionResult LatestProducts()
        {
            var test = productServices.GetLatestProducts(NumberOfProductsToShow).ToList();
            return this.PartialView("_LatestProducts", productServices.GetLatestProducts(NumberOfProductsToShow));
        }

        public ActionResult ProductPromotions()
        {
            return this.PartialView("_ProductPromotions", productServices.GetProductPromotions(NumberOfProductsToShow));
        }

        public ActionResult GetProductsByCategory(int? id)
        {
            TempData["CategoryId"] = id;
            return this.PartialView("_ProductsByCategory", productServices.GetAllProductsByCategory(id));
        }

        [HttpPost]
        public ActionResult GetProductsByCategoryKendo(int? id, [DataSourceRequest]DataSourceRequest request)
        {
            if (request.Filters.Count == 0)
            {
                TempData["CategoryId"] = id;
                var products = productServices.GetAllProductsByCategory(id);  
           
                return Json(products.ToDataSourceResult(request));
            }
            else
            {
                var products = this.Data.Products.All().Project().To<ProductListViewModel>();
                return Json(products.ToDataSourceResult(request));
            }

        }

        public ActionResult Picture(int? id)
        {
            var image = this.Data.Pictures.GetById(id); // to handle and remove from this class


            if (image == null)
            {
                image = this.Data.Pictures.All().FirstOrDefault();
            }
           
            return File(image.PictureAsByteArray, "image/" + image.FileExtension);
        }
    }
}