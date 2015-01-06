namespace AnteyaVIP.Web.Infrastructure.Populators
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    public interface IDropDownListPopulator
    {
        IEnumerable<SelectListItem> GetAllManufacturers();

        IEnumerable<SelectListItem> GetAllCategories();
    }
}