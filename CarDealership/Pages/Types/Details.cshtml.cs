using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarDealership.Data;
using CarDealership.Models;
using Type = CarDealership.Models.Type;

namespace CarDealership.Pages.Types
{
    public class DetailsModel : PageModel
    {
        private readonly CarDealership.Data.CarDealershipContext _context;

        public DetailsModel(CarDealership.Data.CarDealershipContext context)
        {
            _context = context;
        }

      public Type Type { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Type == null)
            {
                return NotFound();
            }

            var type = await _context.Type.FirstOrDefaultAsync(m => m.ID == id);
            if (type == null)
            {
                return NotFound();
            }
            else 
            {
                Type = type;
            }
            return Page();
        }
    }
}
