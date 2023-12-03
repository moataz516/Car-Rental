using AutoMapper;
using CarRental.Models;
using CarRental.Models.Data;
using CarRental.Models.Dtos;

namespace CarRental.Services.PublicSer
{
    public class PublicService : IPublicService
    {

        private readonly CarRentingDbContext _context;
        private readonly IMapper _mapper;

        public PublicService(CarRentingDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Task<ContactDto> GetAllUserMessage(ContactDto model)
        {
            throw new NotImplementedException();
        }

        public Task<ContactDto> GetUserMessage(ContactDto model)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> PostUserMessageAsync(ContactDto model)
        {
            if(model.userId == null)
                return false;
            
            var result = _mapper.Map<ContactUs>(model);
            result.ContactUsId = Guid.NewGuid().ToString();

            _context.ContactUs.Add(result);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
