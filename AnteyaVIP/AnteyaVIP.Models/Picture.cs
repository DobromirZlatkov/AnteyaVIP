namespace AnteyaVIP.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Picture
    {
        [Key]
        public int PictureId { get; set; }

        [Required]
        public byte[] Picture { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
