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
    public class DetailsModel : PageModel
    {
        private readonly CarDealership.Data.CarDealershipContext _context;

        public DetailsModel(CarDealership.Data.CarDealershipContext context)
        {
            _context = context;
        }

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
    }
}
