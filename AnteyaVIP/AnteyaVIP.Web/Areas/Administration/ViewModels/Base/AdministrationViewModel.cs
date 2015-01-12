namespace AnteyaVIP.Web.Areas.Administration.ViewModels.Base
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web.Mvc;

    public abstract class AdministrationViewModel
    {
        [Display(Name = "Added on")]
        [HiddenInput(DisplayValue = false)]
        [Column(TypeName = "DateTime")]
        public DateTime? CreatedOn { get; set; }

        [Display(Name = "Changed on")]        
        [HiddenInput(DisplayValue = false)]
        [Column(TypeName = "DateTime")]
        public DateTime? ModifiedOn { get; set; }
    }
}