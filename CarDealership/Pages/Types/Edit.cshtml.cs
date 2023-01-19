using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarDealership.Data;
using CarDealership.Models;
using Type = CarDealership.Models.Type;

namespace CarDealership.Pages.Types
{
    public class EditModel : PageModel
    {
        private readonly CarDealership.Data.CarDealershipContext _context;

        public EditModel(CarDealership.Data.CarDealershipContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Type Type { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Type == null)
            {
                return NotFound();
            }

            var type =  await _context.Type.FirstOrDefaultAsync(m => m.ID == id);
            if (type == null)
            {
                return NotFound();
            }
            Type = type;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Type).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeExists(Type.ID))
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

        private bool TypeExists(int id)
        {
          return _context.Type.Any(e => e.ID == id);
        }
    }
}
