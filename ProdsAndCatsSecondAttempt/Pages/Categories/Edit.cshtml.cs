﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProdsAndCatsSecondAttempt.Data;
using ProductsAndCategories.Models;

namespace ProdsAndCatsSecondAttempt.Pages.Categories
{
    public class EditModel : PageModel
    {
        private readonly ProdsAndCatsSecondAttempt.Data.ProdsAndCatsSecondAttemptContext _context;

        public EditModel(ProdsAndCatsSecondAttempt.Data.ProdsAndCatsSecondAttemptContext context)
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

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Categorie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategorieExists(Categorie.CategorieID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CategorieExists(int id)
        {
            return _context.Categorie.Any(e => e.CategorieID == id);
        }
    }
}
