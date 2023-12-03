namespace CarRental.Models
{
    public class Brand
    {
        public string BrandId { get; set; }
        public string name { get; set; }
        public string country { get; set; }
        public ICollection<Car> Cars { get; set; }
    }
}
