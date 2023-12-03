namespace CarRental.Models
{
    public class ContactUs
    {
        public string ContactUsId { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string message { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
