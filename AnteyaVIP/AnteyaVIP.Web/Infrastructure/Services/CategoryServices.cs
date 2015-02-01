namespace AnteyaVIP.Web.Infrastructure.Services
{
    using System;
    using System.Linq;

    using AnteyaVIP.Data;
    using AnteyaVIP.Web.Controllers.Base;
    using AnteyaVIP.Web.Infrastructure.Services.Contracts;

    public class CategoryServices : BaseController, ICategoryServices
    {
        public CategoryServices(IAnteyaVIPData data)
            : base(data)
        {
        }

        public IQueryable<object> GetAllCategories(int? id)
        {
            var categories = this.Data.Categories.All().Where(c => c.ParentCategoryId == id.Value).ToList();
            var result = categories.Select(c => new
            {
                id = c.Id,
                Name = c.Name,
                hasChildren = this.Data.Categories.All().Where(r => r.ParentCategoryId == c.Id).Any(),
            }).AsQueryable();

            return result;
        }
    }
}