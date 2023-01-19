using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CarDealership.Models;

namespace CarDealership.Data
{
    public class CarDealershipContext : DbContext
    {
        public CarDealershipContext (DbContextOptions<CarDealershipContext> options)
            : base(options)
        {
        }

        public DbSet<CarDealership.Models.Car> Car { get; set; } = default!;

        public DbSet<CarDealership.Models.Dealership> Dealership { get; set; }

        public DbSet<CarDealership.Models.Type> Type { get; set; }
    }
}
