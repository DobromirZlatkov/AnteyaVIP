namespace AnteyaVIP.Models
{
    using System.ComponentModel.DataAnnotations;

    using AnteyaVIP.Contracts;

    public class Characteristic : DeletableEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        public string Parameter { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        public string Value { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
