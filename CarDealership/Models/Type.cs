namespace CarDealership.Models
{
    public class Type
    {
        public int ID { get; set; }
        public string TypeDescription { get; set; }
        public ICollection<CarType>? CarTypes { get; set; }
    }
}
