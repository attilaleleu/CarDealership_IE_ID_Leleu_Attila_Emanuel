using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarDealership.Models
{
    public class Car
    {
        public int ID { get; set; }
        [Required, StringLength(150, MinimumLength = 2)]
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }

        [Column(TypeName = "decimal(7, 1)")]
        public decimal Price { get; set; }
        public ICollection<CarType> CarTypes { get; set; }

        public int DealershipID { get; set; }
        public Dealership Dealership { get; set; }
    }
}
