namespace AnteyaVIP.Web.Areas.Administration.ViewModels.Orders
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web.Mvc;

    using AnteyaVIP.Models;
    using AnteyaVIP.Web.Areas.Administration.ViewModels.Base;
    using AnteyaVIP.Web.Infrastructure.Mapping;
    using AnteyaVIP.Web.Areas.Administration.ViewModels.OrderDetails;

    public class OrderViewModel : AdministrationViewModel, IMapFrom<Order>
    {
      
        [HiddenInput(DisplayValue = false)]
        public int? Id { get; set; }

        [ScaffoldColumn(false)]
        public string Username { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [DisplayName("First Name")]
        [StringLength(160)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [DisplayName("Last Name")]
        [StringLength(160)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [StringLength(70)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Country is required")]
        [StringLength(40)]
        public string Country { get; set; }

        [Required(ErrorMessage = "City is required")]
        [StringLength(40)]
        public string City { get; set; }

        [Required(ErrorMessage = "Phone is required")]
        [StringLength(24)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Email Address is required")]
        [DisplayName("Email Address")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",
            ErrorMessage = "Email is is not valid.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        //[ScaffoldColumn(false)]
        public decimal Total { get; set; }
       

        [Display(Name = "Credit Card")]
        [DataType(DataType.CreditCard)]
        public string CreditCard { get; set; }

        [Display(Name = "Credit Card Type")]
        public string CcType { get; set; }

        [DisplayName("Order Status")]
        public OrderStatus OrderStatus { get; set; }
    }
}