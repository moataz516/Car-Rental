namespace CarRental.Models
{
    public class UserDetails
    {
        public string UserDetailsId { get; set; }
        public string UserId { get; set; }
        public string country { get; set; }
        public string city { get; set; }
        public string address { get; set; }
        public string street { get; set; }
        public string phoneNumber { get; set; }
        public string gender { get; set; }
        public string photo { get; set; }

        public  ApplicationUser User { get; set; }


    }
}
