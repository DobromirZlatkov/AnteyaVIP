namespace AnteyaVIP.Web.Infrastructure.Populators
{
    using System.Collections.Generic;

    using AnteyaVIP.Web.Areas.Administration.ViewModels.Categories;
    using AnteyaVIP.Web.Areas.Administration.ViewModels.Manufacturers;

    public class KendoDropDownListPopulator : IKendoDropDownListPopulator
    {
        public IEnumerable<ManufacturerViewModel> Manufacturers { get; set; }

        public IEnumerable<CategoryViewModel> Categories { get; set; }   
    }
}