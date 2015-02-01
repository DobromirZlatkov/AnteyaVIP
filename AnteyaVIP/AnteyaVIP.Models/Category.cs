namespace AnteyaVIP.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using AnteyaVIP.Contracts;

    public class Category : DeletableEntity
    {
        private ICollection<Product> products;
       // private ICollection<Category> categories;

        public Category()
        {
            this.products = new HashSet<Product>();
         //   this.categories = new HashSet<Category>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        public virtual ICollection<Product> Products 
        {
            get{ return this.products; }
            set { this.products = value; }
        }

        //public virtual ICollection<Category> ChildCategories
        //{
        //    get { return this.categories; }
        //    set { this.categories = value; }
        //}

        public int? ParentCategoryId { get; set; }
    }
}
