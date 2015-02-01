namespace AnteyaVIP.Web.ViewModels.Products.Base
{
    using System.Linq;

    using AnteyaVIP.Models;
    using AnteyaVIP.Web.Infrastructure.Mapping;
    using AutoMapper;

    public class ProductList : ProductCommon, IHaveCustomMappings
    {
        public decimal Price { get; set; }

        public int? PictureId { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Product, ProductListViewModel>()
               .ForMember(m => m.PictureId, opt => opt.MapFrom(t => t.Pictures.FirstOrDefault().Id));
        }
    }
}