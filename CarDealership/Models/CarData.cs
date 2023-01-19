namespace CarDealership.Models
{
    public class CarData
    {
        public IEnumerable<Car> Cars { get; set; }
        public IEnumerable<Type> Types { get; set; }
        public IEnumerable<CarType> CarTypes { get; set; }
    }
}
