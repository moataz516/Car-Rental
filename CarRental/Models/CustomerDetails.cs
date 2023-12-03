namespace CarRental.Models
{
    public class CustomerDetails
    {
        public string CustomerDetailsId { get; set; } = Guid.NewGuid().ToString();
        public string firstName {  get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string dateOfBirth { get; set; }

        public Reservation reservation { get; set; }
    }


}
