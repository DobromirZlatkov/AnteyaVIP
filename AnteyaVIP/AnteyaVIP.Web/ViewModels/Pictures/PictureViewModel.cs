namespace AnteyaVIP.Web.ViewModels.Pictures
{
    using AnteyaVIP.Models;
    using AnteyaVIP.Web.Infrastructure.Mapping;

    public class PictureViewModel: IMapFrom<Picture>
    {
        public int Id { get; set; }
    }
}