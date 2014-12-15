namespace AnteyaVIP.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AnteyaVIP.Contracts;

    public class Product : DeletableEntity
    {
        private ICollection<Characteristic> characteristics;

        private ICollection<Picture> pictures;

        private ICollection<OrderDetail> orderDetails;

        public Product()
        {
            this.characteristics = new HashSet<Characteristic>();
            this.pictures = new HashSet<Picture>();
            this.orderDetails = new HashSet<OrderDetail>();
        }

        [Key]
        public int ProductId { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(2000)]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

       // public double ProductWeigth { get; set; }

        //TO DO add product sizes for shipping info

        public int ProductStock { get; set; }

        public int ManufacturerId { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<Characteristic> Characteristics
        { 
            get{ return this.characteristics; }
            set { this.characteristics = value; }
        }

        public virtual ICollection<Picture> Pictures
        {
            get { return this.pictures; }
            set { this.pictures = value; }
        }

        public virtual ICollection<OrderDetail> OrderDetails
        {
            get { return this.orderDetails; }
            set { this.orderDetails = value; }
        }
    }
}
