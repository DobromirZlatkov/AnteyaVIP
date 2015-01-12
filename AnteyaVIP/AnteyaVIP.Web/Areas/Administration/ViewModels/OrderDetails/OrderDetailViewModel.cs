namespace AnteyaVIP.Web.Areas.Administration.ViewModels.OrderDetails
{
    using System.Web.Mvc;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    using AutoMapper;

    using AnteyaVIP.Web.Infrastructure.Mapping;
    using AnteyaVIP.Web.Areas.Administration.ViewModels.Base;
    using AnteyaVIP.Models;
    using System.ComponentModel;

    public class OrderDetailViewModel : AdministrationViewModel, IMapFrom<OrderDetail>, IHaveCustomMappings
    {
        [HiddenInput(DisplayValue = false)]
        public int? Id { get; set; }

        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }

        public int ProductId { get; set; }

        public string ProductName { get; set; }

        [DisplayName("Product Picture")]
        public int? ProductPicture { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<OrderDetail, OrderDetailViewModel>()
                .ForMember(m => m.ProductName, opt => opt.MapFrom(t => t.Product.Name))
                .ForMember(m => m.ProductPicture, opt => opt.MapFrom(t => t.Product.Pictures.FirstOrDefault().Id))
                .ReverseMap();
        }
    }
}