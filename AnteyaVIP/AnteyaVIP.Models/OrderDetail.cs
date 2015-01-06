namespace AnteyaVIP.Models
{
    using AnteyaVIP.Contracts;
    using System.ComponentModel.DataAnnotations;

    public class OrderDetail 
    {
        [Key]
        public int Id { get; set; }

        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        public int OrderId { get; set; }

        public virtual Order Order { get; set; }
    }
}
