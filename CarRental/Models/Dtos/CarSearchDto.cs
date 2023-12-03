namespace CarRental.Models.Dtos
{
    public class CarSearchDto
    {
        //public string brandId { get; set; }
        public string carId { get; set; }
        public string location { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
    
    }

    public class CarSearchCheck
    {
        public string s { get; set; }
        public string e { get; set; }

    }
}
