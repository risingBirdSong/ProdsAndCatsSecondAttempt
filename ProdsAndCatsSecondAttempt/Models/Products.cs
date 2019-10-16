using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsAndCategories.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public virtual ICollection<ProductJoinCategory> ProductCategorys { get; set; }
    }
}
