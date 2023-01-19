using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarDealership.Data;
using CarDealership.Models;
using System.Net;

namespace CarDealership.Pages.Cars
{
    public class IndexModel : PageModel
    {
        private readonly CarDealership.Data.CarDealershipContext _context;

        public IndexModel(CarDealership.Data.CarDealershipContext context)
        {
            _context = context;
        }

        public IList<Car> Car { get;set; } = default!;
        // Mine ***
        public CarData CarD { get; set; }
        public int CarID { get; set; }
        public int TypeID { get; set; }

        public async Task OnGetAsync(int? id, int? typeID)
        {
            CarD = new CarData();

            CarD.Cars = await _context.Car
            .Include(b => b.Dealership)
            .Include(b => b.CarTypes)
            .ThenInclude(b => b.Type)
            .AsNoTracking()
            //.OrderBy(b => b.Make)
            .ToListAsync();
            if (id != null)
            {
                CarID = id.Value;
                Car car = CarD.Cars
                .Where(i => i.ID == id.Value).Single();
                CarD.Types = car.CarTypes.Select(s => s.Type);
            }
        }

        // ***


        // Original ***
        /*public async Task OnGetAsync()
        {
            if (_context.Car != null)
            {
                Car = await _context.Car
                .Include(c => c.Dealership).ToListAsync();
            }
        }*/
        // ***
    }
}
