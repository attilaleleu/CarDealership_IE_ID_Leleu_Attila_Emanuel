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

namespace CarDealership.Pages.Cars
{
    //public class EditModel : PageModel
    public class EditModel : CarTypePageModel
    {
        private readonly CarDealership.Data.CarDealershipContext _context;

        public EditModel(CarDealership.Data.CarDealershipContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Car Car { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Car == null)
            {
                return NotFound();
            }

            // Mine added
            Car = await _context.Car
                .Include(b => b.Dealership)
                .Include(b => b.CarTypes).ThenInclude(b => b.Type)
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.ID == id);
            //
            // another await async added by default
            //var car =  await _context.Car.FirstOrDefaultAsync(m => m.ID == id);
            if (Car == null)
            {
                return NotFound();
            }
            //Car = car;
            PopulateAssignedTypeData(_context, Car);
            ViewData["DealershipID"] = new SelectList(_context.Set<Dealership>(), "ID", "DealershipName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        //public async Task<IActionResult> OnPostAsync()
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedTypes)
        {
            if (id == null)
            {
                return NotFound(id);
            }
            var carToUpdate = await _context.Car
                .Include(i => i.Dealership)
                .Include(i => i.CarTypes)
                .ThenInclude(i => i.Type)
                .FirstOrDefaultAsync(s => s.ID == id);
            if (carToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Car>(
                carToUpdate,
                "Car",
                i => i.Make, i => i.Model, i => i.Price, i => i.Year, i => i.Dealership))
            {
                UpdateCarTypes(_context, selectedTypes, carToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            UpdateCarTypes(_context, selectedTypes, carToUpdate);
            PopulateAssignedTypeData(_context, carToUpdate);
            return Page();
        }
            
            
            
         // Original **** 
            /* {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Car).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarExists(Car.ID))
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

        private bool CarExists(int id)
        {
          return _context.Car.Any(e => e.ID == id);
        }*/
        // ****
    }
}
