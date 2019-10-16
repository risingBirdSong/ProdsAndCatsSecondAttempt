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
    public class DetailsModel : PageModel
    {
        private readonly ProdsAndCatsSecondAttempt.Data.ProdsAndCatsSecondAttemptContext _context;

        public DetailsModel(ProdsAndCatsSecondAttempt.Data.ProdsAndCatsSecondAttemptContext context)
        {
            _context = context;
        }

        public Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _context.Product.FirstOrDefaultAsync(m => m.ProductID == id);

            if (Product == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
