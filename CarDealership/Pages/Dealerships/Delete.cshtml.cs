using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarDealership.Data;
using CarDealership.Models;

namespace CarDealership.Pages.Dealerships
{
    public class DeleteModel : PageModel
    {
        private readonly CarDealership.Data.CarDealershipContext _context;

        public DeleteModel(CarDealership.Data.CarDealershipContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Dealership Dealership { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Dealership == null)
            {
                return NotFound();
            }

            var dealership = await _context.Dealership.FirstOrDefaultAsync(m => m.ID == id);

            if (dealership == null)
            {
                return NotFound();
            }
            else 
            {
                Dealership = dealership;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Dealership == null)
            {
                return NotFound();
            }
            var dealership = await _context.Dealership.FindAsync(id);

            if (dealership != null)
            {
                Dealership = dealership;
                _context.Dealership.Remove(Dealership);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
