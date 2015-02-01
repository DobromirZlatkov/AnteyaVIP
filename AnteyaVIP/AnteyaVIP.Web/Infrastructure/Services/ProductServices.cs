namespace AnteyaVIP.Web.Infrastructure.Services
{
    using System.Linq;

    using AnteyaVIP.Data;
    using AnteyaVIP.Models;
    using AnteyaVIP.Web.Controllers.Base;
    using AnteyaVIP.Web.Infrastructure.Services.Contracts;
    using AnteyaVIP.Web.ViewModels.Products;

    using AutoMapper.QueryableExtensions;
    using System.Collections.Generic;

    public class ProductServices : BaseController, IProductServices
    {
        public ProductServices(IAnteyaVIPData data)
            : base(data)
        {
        }

        public IQueryable<ProductAutoCompleteViewModel> GetProductsByMatchWord(string text)
        {
            var products = this.Data.Products.All()
                .Where(p => p.Name.ToLower().Contains(text.ToLower()) || p.Description.ToLower().Contains(text.ToLower()))
                .Project()
                .To<ProductAutoCompleteViewModel>();
            return products;
        }

        public IQueryable<ProductListViewModel> GetLatestProducts(int productCount)
        {
            var products = this.Data.Products.All()
                .OrderByDescending(p => p.CreatedOn)
                .Take(productCount)
                .Project()
                .To<ProductListViewModel>();

            return products;
        }

        public IQueryable<ProductListViewModel> GetAllProductsByCategory(int? id)
        {
            IQueryable<ProductListViewModel> categoryProducts;
            if (id == null)
            {
                categoryProducts = this.Data.Products
                                        .All()
                                        .Project()
                                        .To<ProductListViewModel>();
            }
            else
            {
                categoryProducts = this.Data.Products
                                        .All()
                                        .Where(p => p.CategoryId == id)
                                        .Project()
                                        .To<ProductListViewModel>();
            }

            return categoryProducts;
        }


        public IQueryable<ProductPromotionViewModel> GetProductPromotions(int productCount)
        {
            var products = this.Data.Products.All()
                .Where(p => p.ProductStatus == ProductStatus.Promotion)
                .OrderBy(p => p.ModifiedOn)
                .Project()
                .To<ProductPromotionViewModel>();

            return products;
        }
    }
}