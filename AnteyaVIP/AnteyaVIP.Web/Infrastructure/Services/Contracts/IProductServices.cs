using AnteyaVIP.Models;
using AnteyaVIP.Web.ViewModels.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnteyaVIP.Web.Infrastructure.Services.Contracts
{
    internal interface IProductServices
    {
        IQueryable<ProductAutoCompleteViewModel> GetProductsByMatchWord(string text);

        IQueryable<ProductListViewModel> GetLatestProducts(int productCount);

        IQueryable<ProductListViewModel> GetAllProductsByCategory(int? id);

        IQueryable<ProductPromotionViewModel> GetProductPromotions(int productCount);
    }
}
