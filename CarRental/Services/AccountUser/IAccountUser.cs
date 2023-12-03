using CarRental.Models.Dtos;

namespace CarRental.Services.AccountUser
{
    public interface IAccountUser
    {
        Task<UserDto> GetUserDetails(string id);
        ///Task<UserDto> UpdateUserDetails(string id, UserDto userDto);
        Task<bool> UpdateUserProfileImg(IFormFile fileImg, string id);
        Task<bool> UpdateUserProfile(UserDto model);
    }
}
