namespace AnteyaVIP.Web.Areas.Administration.ViewModels.Characteristics
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using AnteyaVIP.Models;
    using AnteyaVIP.Web.Infrastructure.Mapping;
    using AnteyaVIP.Web.Areas.Administration.ViewModels.Base;

    public class CharacteristicViewModel : AdministrationViewModel, IMapFrom<Characteristic>
    {
        [HiddenInput(DisplayValue = false)]
        public int? Id { get; set; }

        [Required]
        [UIHint("String")]
        [StringLength(100, ErrorMessage = "{0} must be between 2 and 100 symbols.", MinimumLength = 2)]
        [Display(Name = "Parameter")]
        public string Parameter { get; set; }

        [Required]
        [UIHint("String")]
        [StringLength(100, ErrorMessage = "{0} must be between 2 and 100 symbols.", MinimumLength = 2)]
        [Display(Name = "Value")]
        public string Value { get; set; }
    }
}