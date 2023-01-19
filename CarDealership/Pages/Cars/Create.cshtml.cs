using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CarDealership.Data;
using CarDealership.Models;

namespace CarDealership.Pages.Cars
{
    //public class CreateModel : PageModel
    public class CreateModel : CarTypePageModel
    {
        private readonly CarDealership.Data.CarDealershipContext _context;

        public CreateModel(CarDealership.Data.CarDealershipContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["DealershipID"] = new SelectList(_context.Set<Dealership>(), "ID", "DealershipName");

            // Mine ****
            var car = new Car();
            car.CarTypes = new List<CarType>();
            PopulateAssignedTypeData(_context, car);
            // ***

            return Page();
        }

        [BindProperty]
        public Car Car { get; set; }
        
        // Mine ***

        public async Task<IActionResult> OnPostAsync(string[] selectedTypes)
        {
            var newCar = new Car();
            if (selectedTypes != null)
            {
                newCar.CarTypes = new List<CarType>();
                foreach (var tp in selectedTypes)
                {
                    var tpToAdd = new CarType
                    {
                        TypeID = int.Parse(tp)
                    };
                    newCar.CarTypes.Add(tpToAdd);
                }
            }
            if (await TryUpdateModelAsync<Car>(
                newCar, 
                "Car", 
                i => i.Make, i => i.Model, i => i.Price, i => i.Year, i => i.DealershipID))
            {
                _context.Car.Add(newCar);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedTypeData(_context, newCar);
            return Page();
        }

        // ***


        // Original ***
        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
       /* public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Car.Add(Car);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }*/
        // ***
    }
}
