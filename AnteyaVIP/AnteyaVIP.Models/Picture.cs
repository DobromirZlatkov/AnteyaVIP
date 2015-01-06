namespace AnteyaVIP.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.IO;
    using System.Web;

    public class Picture
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public byte[] PictureAsByteArray { get; set; }

        public string FileExtension { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        [Display(Name = "Local file")]
        [NotMapped]
        public HttpPostedFileBase File
        {
            get
            {
                return null;
            }

            set
            {
                try
                {
                    MemoryStream target = new MemoryStream();

                    if (value.InputStream == null)
                        return;

                    value.InputStream.CopyTo(target);
                    this.PictureAsByteArray = target.ToArray();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
