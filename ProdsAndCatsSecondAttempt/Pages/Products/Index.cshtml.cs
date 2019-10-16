using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProdsAndCatsSecondAttempt.Data;
using ProductsAndCategories.Models;

namespace ProdsAndCatsSecondAttempt.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly ProdsAndCatsSecondAttempt.Data.ProdsAndCatsSecondAttemptContext _context;

        public IndexModel(ProdsAndCatsSecondAttempt.Data.ProdsAndCatsSecondAttemptContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; }

        public async Task OnGetAsync()
        {
            Product = await _context.Product.ToListAsync();
        }
    }
}
