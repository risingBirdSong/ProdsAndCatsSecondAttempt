﻿using System;
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
    public class DeleteModel : PageModel
    {
        private readonly ProdsAndCatsSecondAttempt.Data.ProdsAndCatsSecondAttemptContext _context;

        public DeleteModel(ProdsAndCatsSecondAttempt.Data.ProdsAndCatsSecondAttemptContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Categorie = await _context.Categorie.FindAsync(id);

            if (Categorie != null)
            {
                _context.Categorie.Remove(Categorie);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
