using Microsoft.AspNetCore.Identity;

namespace CarRental.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public ICollection<Car> Cars { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
        public ICollection<Payment> Payments { get; set; }
        public UserPayment UserPayment { get; set; }
        public UserDetails UserDetails { get; set; }
        public ICollection<ContactUs> ContactUs { get; set; }


    }
}
 