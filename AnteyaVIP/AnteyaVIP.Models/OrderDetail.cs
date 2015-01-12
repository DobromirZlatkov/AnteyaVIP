namespace AnteyaVIP.Models
{
    using System.ComponentModel.DataAnnotations;

    using AnteyaVIP.Contracts;

    public class OrderDetail : DeletableEntity
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
