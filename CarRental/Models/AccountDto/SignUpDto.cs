using System.ComponentModel.DataAnnotations;

namespace CarRental.Models.AccountDto
{
    public class SignUpDto
    {
        //[Required(ErrorMessage ="First name is required")]
        //[StringLength(20, ErrorMessage = "First name must be at least 3 characters.", MinimumLength = 3)]
        public string firstName { get; set; }

        //[Required(ErrorMessage = "last name is required")]
        //[StringLength(20, ErrorMessage = "last name must be at least 3 characters.", MinimumLength = 3)]
        public string lastName { get; set; }

        //[Required(ErrorMessage = "Username is required")]
        //[StringLength(20, ErrorMessage = "Username must be 3-20 characters long", MinimumLength = 3)]
        //[RegularExpression(@"^[a-zA-Z0-9_]{3,20}$", ErrorMessage = " Username can only contain letters, numbers, and underscores")]
        public string userName => $"{firstName.ToLower()}_{lastName.ToLower()}";

        //[Required(ErrorMessage ="Email is reguired")]
        //[EmailAddress(ErrorMessage = "Invalid email address")]
        public string email { get; set; }
        
        //[Required(ErrorMessage ="Pasword is required")]
        //[StringLength(50, MinimumLength = 2, ErrorMessage = "The password must be between 2 and 50 characters.")]
        public string password { get; set; }

        //[Required(ErrorMessage ="Phone number is required")]
        //[RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Invalid phone number format.")]
       // public string phone { get; set; }
    }
}
