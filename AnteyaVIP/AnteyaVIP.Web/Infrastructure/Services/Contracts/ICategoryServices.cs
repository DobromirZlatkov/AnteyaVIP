using AnteyaVIP.Web.ViewModels.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnteyaVIP.Web.Infrastructure.Services.Contracts
{
    internal interface ICategoryServices
    {
        IQueryable<object> GetAllCategories(int? id);
    }
}
