using CarDealership.Models;
using System.Security.Policy;

namespace CarDealership.Models.ViewModels
{
    public class DealershipIndexData
    {
        public IEnumerable<Dealership> Dealerships { get; set; }
        public IEnumerable<Car> Cars { get; set; }

    }
}
