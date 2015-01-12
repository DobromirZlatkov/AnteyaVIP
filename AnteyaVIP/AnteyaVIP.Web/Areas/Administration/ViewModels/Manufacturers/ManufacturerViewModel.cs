namespace AnteyaVIP.Web.Areas.Administration.ViewModels.Manufacturers
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using AnteyaVIP.Models;
    using AnteyaVIP.Web.Areas.Administration.ViewModels.Base;
    using AnteyaVIP.Web.Infrastructure.Mapping;

    public class ManufacturerViewModel : AdministrationViewModel, IMapFrom<Manufacturer>
    {
        [HiddenInput(DisplayValue = false)]
        public int? Id { get; set; }

        [Required]
        [UIHint("String")]
        [StringLength(100, ErrorMessage = "{0} must be between 2 and 100 symbols", MinimumLength = 2)]
        [Display(Name = "Manufacturer")]
        public string Name { get; set; }
    }
}