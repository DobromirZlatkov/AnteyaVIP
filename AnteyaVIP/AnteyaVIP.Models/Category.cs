namespace AnteyaVIP.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using AnteyaVIP.Contracts;

    public class Category : DeletableEntity
    {
        private ICollection<Product> products;

        public Category()
        {
            this.products = new HashSet<Product>();
        }

        [Key]
        public int CategoryId { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        public string Name { get; set; }

        public virtual ICollection<Product> Products 
        {
            get{ return this.products; }
            set { this.products = value; }
        }
    }
}
