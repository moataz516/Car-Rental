using System.ComponentModel.DataAnnotations;

namespace CarRental.Models.AccountDto
{
    public class SignInDto
    {
        //[Required(ErrorMessage = "Email is reguired")]
        //[EmailAddress(ErrorMessage = "Invalid email address")]
        public string username { get; set; }


        //[Required(ErrorMessage = "Pasword is required")]
        //[StringLength(50, MinimumLength = 2, ErrorMessage = "The password must be between 2 and 50 characters.")]
        //[DataType(DataType.Password)]
        public string password { get; set; }
    }
}
