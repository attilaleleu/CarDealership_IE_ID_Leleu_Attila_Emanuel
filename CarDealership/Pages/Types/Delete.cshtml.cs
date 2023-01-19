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
    public class DeleteModel : PageModel
    {
        private readonly CarDealership.Data.CarDealershipContext _context;

        public DeleteModel(CarDealership.Data.CarDealershipContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Type == null)
            {
                return NotFound();
            }
            var type = await _context.Type.FindAsync(id);

            if (type != null)
            {
                Type = type;
                _context.Type.Remove(Type);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
