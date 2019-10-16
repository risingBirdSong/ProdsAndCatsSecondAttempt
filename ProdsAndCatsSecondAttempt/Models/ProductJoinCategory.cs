using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsAndCategories.Models
{
    public class ProductJoinCategory
    {
        [Key]
        public int ProductJoinCategoryID { get; set; }
        public int ProductID { get; set; }

        public Product Product { get; set; }

        public int CategoryID { get; set; }

        public Categorie Categorie { get; set; }

    }
}
