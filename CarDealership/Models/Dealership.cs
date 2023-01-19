namespace CarDealership.Models
{
    public class Dealership
    {
        public int ID { get; set; }
        public string DealershipName { get; set; }
        public ICollection<Car>? Cars { get; set; }
    }
}
