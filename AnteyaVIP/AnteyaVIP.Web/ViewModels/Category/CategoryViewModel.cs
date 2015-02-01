using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnteyaVIP.Web.ViewModels.Category
{
    public class CategoryViewModel
    {

        public CategoryViewModel()
        {
            ChildCategories = new HashSet<CategoryViewModel>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<CategoryViewModel> ChildCategories { get; set; }

    }
}