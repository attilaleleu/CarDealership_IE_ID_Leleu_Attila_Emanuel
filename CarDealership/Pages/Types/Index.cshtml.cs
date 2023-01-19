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
    public class IndexModel : PageModel
    {
        private readonly CarDealership.Data.CarDealershipContext _context;

        public IndexModel(CarDealership.Data.CarDealershipContext context)
        {
            _context = context;
        }

        public IList<Type> Type { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Type != null)
            {
                Type = await _context.Type.ToListAsync();
            }
        }
    }
}
