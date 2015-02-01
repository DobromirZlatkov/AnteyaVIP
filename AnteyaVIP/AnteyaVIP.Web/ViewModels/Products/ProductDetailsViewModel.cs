namespace AnteyaVIP.Web.ViewModels.Products
{
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;

    using AnteyaVIP.Models;
    using AnteyaVIP.Web.ViewModels.Products.Base;
    using AnteyaVIP.Web.Infrastructure.Mapping;
    using AnteyaVIP.Web.ViewModels.Pictures;

    public class ProductDetailsViewModel : ProductCommon, IHaveCustomMappings
    {
        public IList<PictureViewModel> PictureIds { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string Manufacturer { get; set; }

        public string Category { get; set; }

        public ICollection<Characteristic> Characteristics { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Product, ProductDetailsViewModel>()
                .ForMember(m => m.Manufacturer, opt => opt.MapFrom(c => c.Manufacturer.Name))
                .ForMember(m => m.Category, opt => opt.MapFrom(c => c.Category.Name))
                .ForMember(m => m.PictureIds, opt => opt.MapFrom(t => t.Pictures.Select(p => new PictureViewModel { Id = p.Id})));
        }
    }
}