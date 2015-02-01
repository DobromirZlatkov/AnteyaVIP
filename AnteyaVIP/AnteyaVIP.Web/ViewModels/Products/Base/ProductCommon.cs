namespace AnteyaVIP.Web.ViewModels.Products.Base
{
    using AnteyaVIP.Models;
    using AnteyaVIP.Web.Infrastructure.Mapping;

    public abstract class ProductCommon : IMapFrom<Product>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}