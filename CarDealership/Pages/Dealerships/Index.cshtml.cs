using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarDealership.Data;
using CarDealership.Models;
using System.Security.Policy;
using CarDealership.Models.ViewModels;

namespace CarDealership.Pages.Dealerships
{
    public class IndexModel : PageModel
    {
        private readonly CarDealership.Data.CarDealershipContext _context;

        public IndexModel(CarDealership.Data.CarDealershipContext context)
        {
            _context = context;
        }

        public IList<Dealership> Dealership { get; set; } = default!;

        // Mine ***

        public DealershipIndexData DealershipData { get; set; }
        public int DealershipID { get; set; }
        public int CarID { get; set; }
        public async Task OnGetAsync(int? id, int? carID)
        {
            DealershipData = new DealershipIndexData();
            DealershipData.Dealerships = await _context.Dealership
            .Include(i => i.Cars)
            //.ThenInclude(i => i.Make)
            .OrderBy(i => i.DealershipName)
            .ToListAsync();
            if (id != null)
            {
                DealershipID = id.Value;
                Dealership dealership = DealershipData.Dealerships
                .Where(i => i.ID == id.Value).Single();
                DealershipData.Cars = dealership.Cars;
            }


            // ***


            // Original ***
            /* public async Task OnGetAsync()
             {
                 if (_context.Dealership != null)
                 {
                     Dealership = await _context.Dealership.ToListAsync();
                 }
             }*/
            // ***
        }
    }
}