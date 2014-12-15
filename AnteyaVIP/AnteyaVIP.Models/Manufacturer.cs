namespace AnteyaVIP.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AnteyaVIP.Contracts;

    public class Manufacturer : DeletableEntity
    {
        private ICollection<Product> products;

        public Manufacturer()
        {
            this.products = new HashSet<Product>();
        }

        [Key]
        public int ManufacturerId { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        public string Name { get; set; }

        public virtual ICollection<Product> Products
        {
            get { return this.products; }
            set { this.products = value; }
        }
    }
}
