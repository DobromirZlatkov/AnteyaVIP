namespace AnteyaVIP.Web.Areas.Administration.ViewModels.Products
{
    using System.Web;
    using System.Collections.Generic;

    using AnteyaVIP.Models;
    using AnteyaVIP.Web.Areas.Administration.ViewModels.Categories;
    using AnteyaVIP.Web.Areas.Administration.ViewModels.Manufacturers;

    public class ProductForeignKeyValues
    {
        public IEnumerable<ManufacturerViewModel> Manufacturers { get; set; }

        public IEnumerable<CategoryViewModel> Categories { get; set; }
    }
}