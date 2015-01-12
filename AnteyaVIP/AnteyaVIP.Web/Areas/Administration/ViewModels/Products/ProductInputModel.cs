namespace AnteyaVIP.Web.Areas.Administration.ViewModels.Products
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using AnteyaVIP.Models;
    using AnteyaVIP.Web.Areas.Administration.ViewModels.Base;
    using AnteyaVIP.Web.Infrastructure.Mapping;

    public class ProductInputModel : AdministrationViewModel, IMapFrom<Product>
    {

        [HiddenInput(DisplayValue = false)]
        public int? Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "{0} must be between 2 and 100 symbols", MinimumLength = 2)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [UIHint("MultiLineText")]
        [StringLength(2000, ErrorMessage = "{0} must be between 5 and 2000 symbols", MinimumLength = 5)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [UIHint("Currency")]
        [Range(0.01, 10000.00,
         ErrorMessage = "Price must be between 0 and 10 000")]
        public decimal Price { get; set; }

        // public double ProductWeigth { get; set; }
         //TO DO add product sizes for shipping info
        [UIHint("ManufacturerId")]
        public int ManufacturerId { get; set; }

        [Required(ErrorMessage = "Category is required")]
        [UIHint("CategoryId")]
        public int CategoryId { get; set; }

        //public ICollection<PictureViewModel> Images { get; set; }

        //public void CreateMappings(IConfiguration configuration)
        //{
        //    configuration.CreateMap<Product, ProductInputModel>()
        //        .ForMember(m => m.Images, opt => opt.MapFrom(t => t.Pictures))
        //        .ReverseMap();
        //}
    }
}