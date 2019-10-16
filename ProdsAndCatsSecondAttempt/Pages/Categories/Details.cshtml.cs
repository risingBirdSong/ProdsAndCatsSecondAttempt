using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProdsAndCatsSecondAttempt.Data;
using ProductsAndCategories.Models;

namespace ProdsAndCatsSecondAttempt.Pages.Categories
{
    public class DetailsModel : PageModel
    {
        private readonly ProdsAndCatsSecondAttempt.Data.ProdsAndCatsSecondAttemptContext _context;

        public DetailsModel(ProdsAndCatsSecondAttempt.Data.ProdsAndCatsSecondAttemptContext context)
        {
            _context = context;
        }

        public Categorie Categorie { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Categorie = await _context.Categorie.FirstOrDefaultAsync(m => m.CategorieID == id);

            if (Categorie == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
