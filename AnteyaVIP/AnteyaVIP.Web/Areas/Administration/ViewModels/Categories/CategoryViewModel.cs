namespace AnteyaVIP.Web.Areas.Administration.ViewModels.Categories
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using AnteyaVIP.Models;
    using AnteyaVIP.Web.Infrastructure.Mapping;
    using AnteyaVIP.Web.Areas.Administration.ViewModels.Base;

    using AutoMapper;

    public class CategoryViewModel : AdministrationViewModel, IMapFrom<Category>
    {
        [HiddenInput(DisplayValue = false)]
        public int? Id { get; set; }

        [UIHint("String")]
        [StringLength(100, ErrorMessage = "{0} must be between 2 and 100 symbols", MinimumLength = 2)]
        [Display(Name = "Category")]
        public string Name { get; set; }

        [Display(Name = "Parent Category Id")]
       // [UIHint("ParentCategoryId")]
        public int? ParentCategoryId { get; set; }

    }
}