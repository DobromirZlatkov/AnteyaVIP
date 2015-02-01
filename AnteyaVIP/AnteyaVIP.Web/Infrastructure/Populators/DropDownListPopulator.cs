namespace AnteyaVIP.Web.Infrastructure.Populators
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using AnteyaVIP.Data;
    using AnteyaVIP.Web.Infrastructure.Caching;

    public class DropDownListPopulator : IDropDownListPopulator
    {
        private IAnteyaVIPData data;
        private ICacheService cache;

        public DropDownListPopulator(IAnteyaVIPData data, ICacheService cache)
        {
            this.cache = cache;
            this.data = data;
        }

        public IEnumerable<SelectListItem> GetAllManufacturers()
        {
            return this.data.Manufacturers
                .All()
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                })
                .ToList();
        }

        public IEnumerable<SelectListItem> GetAllCategories()
        { 
            return this.data.Categories
                .All()
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                })
                .ToList();
        }
    }
}