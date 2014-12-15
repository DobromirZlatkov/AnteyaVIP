namespace AnteyaVIP.Models
{
    using AnteyaVIP.Contracts;
    using System.ComponentModel.DataAnnotations;

    public class OrderDetail 
    {
        [Key]
        public int OrderDetailId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        [MinLength(0)]
        [MaxLength(50)]
        public string SKU { get; set; }

        public int Quantity { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        public int OrderId { get; set; }

        public virtual Order Order { get; set; }
    }
}
