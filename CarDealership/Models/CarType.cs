namespace CarDealership.Models
{
    public class CarType
    {
        public int ID { get; set; }
        public int CarID { get; set; }
        public Car Car { get; set; }
        public int TypeID { get; set; }
        public Type Type { get; set; }
    }
}
