namespace AnteyaVIP.Web.ViewModels.Products
{
    using System.Linq;

    using AnteyaVIP.Models;
    using AnteyaVIP.Web.Infrastructure.Mapping;
    using AnteyaVIP.Web.ViewModels.Products.Base;
    using AutoMapper;

    public class ProductPromotionViewModel : ProductList, IHaveCustomMappings
    {
        public string Description { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Product, ProductPromotionViewModel>()
               .ForMember(m => m.PictureId, opt => opt.MapFrom(t => t.Pictures.FirstOrDefault().Id));
        }
    }
}