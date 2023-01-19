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

namespace CarDealership.Pages.Dealerships
{
    public class EditModel : PageModel
    {
        private readonly CarDealership.Data.CarDealershipContext _context;

        public EditModel(CarDealership.Data.CarDealershipContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Dealership Dealership { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Dealership == null)
            {
                return NotFound();
            }

            var dealership =  await _context.Dealership.FirstOrDefaultAsync(m => m.ID == id);
            if (dealership == null)
            {
                return NotFound();
            }
            Dealership = dealership;
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

            _context.Attach(Dealership).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DealershipExists(Dealership.ID))
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

        private bool DealershipExists(int id)
        {
          return _context.Dealership.Any(e => e.ID == id);
        }
    }
}
