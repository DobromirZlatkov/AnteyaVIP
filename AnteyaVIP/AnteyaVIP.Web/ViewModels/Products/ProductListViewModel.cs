namespace AnteyaVIP.Web.ViewModels.Products
{
    using AnteyaVIP.Models;
    using AnteyaVIP.Web.Infrastructure.Mapping;
    using AnteyaVIP.Web.ViewModels.Products.Base;
    using AutoMapper;

    public class ProductListViewModel : ProductList, IHaveCustomMappings
    {
        public ProductStatus ProductStatus { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Product, ProductListViewModel>()
               .ForMember(m => m.ProductStatus, opt => opt.MapFrom(t => t.ProductStatus));
        }
    }
}