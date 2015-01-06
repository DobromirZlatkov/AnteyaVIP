namespace AnteyaVIP.Web.Areas.Administration.ViewModels.Manufacturers
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using AnteyaVIP.Models;
    using AnteyaVIP.Web.Infrastructure.Mapping;
    using AnteyaVIP.Web.Areas.Administration.ViewModels.Base;

    public class ManufacturerViewModel :AdministrationViewModel, IMapFrom<Manufacturer>
    {
        [HiddenInput(DisplayValue = false)]
        public int? Id { get; set; }

        [Required]
        [UIHint("String")]
        [StringLength(100, ErrorMessage = "{0}ят трябва да е между 2 и 100 символа.", MinimumLength = 2)]
        [Display(Name = "Производител")]
        public string Name { get; set; }
    }
}