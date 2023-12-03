using CarRental.Models.Dtos;

namespace CarRental.Services.PublicSer
{
    public interface IPublicService
    {
        Task<ContactDto> GetAllUserMessage(ContactDto model);
        Task<ContactDto> GetUserMessage(ContactDto model);
        Task<bool> PostUserMessageAsync(ContactDto model);
    }
}
