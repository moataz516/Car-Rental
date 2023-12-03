namespace CarRental.Models.Dtos
{
    public class UserProfileDto
    {
    }

    public class UserProfileImgDto
    {
        public string Id { get; set; }
        public IFormFile fileImg { get; set; }
    }
}
