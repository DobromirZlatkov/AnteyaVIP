namespace AnteyaVIP.Web.Infrastructure.Populators
{
    using System.Collections.Generic;

    using AnteyaVIP.Web.Areas.Administration.ViewModels.Categories;
    using AnteyaVIP.Web.Areas.Administration.ViewModels.Manufacturers;

    public interface IKendoDropDownListPopulator
    {
        IEnumerable<ManufacturerViewModel> Manufacturers { get; set; }

        IEnumerable<CategoryViewModel> Categories { get; set; }
    }
}
