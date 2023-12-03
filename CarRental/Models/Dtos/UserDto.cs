namespace CarRental.Models.Dtos
{
    public class UserDto
    {
        public string Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string username { get; set; }
        public UserDetailsDto UserDetails { get; set; }
    }
}
