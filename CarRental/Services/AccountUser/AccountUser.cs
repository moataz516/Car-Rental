using AutoMapper;
using CarRental.Models;
using CarRental.Models.Data;
using CarRental.Models.Dtos;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Drawing2D;

namespace CarRental.Services.AccountUser
{
    public class AccountUser : IAccountUser
    {

        private readonly CarRentingDbContext _context;
        private readonly IMapper _mapper;
        private readonly string filePathUrl = @"P:\Angular and .Net\CarRental\wwwroot\Images\userProfileImg"; 

        public AccountUser(CarRentingDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UserDto> GetUserDetails(string id)
        {
            var getUser = await  _context.ApplicationUsers.Include(user => user.UserDetails).FirstOrDefaultAsync(x=>x.Id == id);
            var userDetails = _mapper.Map<UserDto>(getUser);
            if (getUser.UserDetails != null)
            {
                if (getUser?.UserDetails.photo != null)
                {
                    string fullPath = Path.Combine(filePathUrl, userDetails.UserDetails.photo);
                    byte[] photoBytes = System.IO.File.ReadAllBytes(fullPath);
                    string base64String = Convert.ToBase64String(photoBytes);
                    userDetails.UserDetails.photo = base64String;
                }
            }

            return userDetails;
        }

        public async Task<bool> UpdateUserProfileImg(IFormFile fileImg, string id)
        {
            var updateprofileImg = await _context.UserDetails.FirstOrDefaultAsync(x=>x.UserId == id);
            if (updateprofileImg == null)
            {
                UserDetails userDetails = new UserDetails()
                {
                    UserDetailsId = Guid.NewGuid().ToString(),
                    UserId = id,
                    photo = await this.SaveImageFile(fileImg)

                };
                _context.UserDetails.Add(userDetails);
                 await _context.SaveChangesAsync();
                return true;
            }
            var imageName = await this.SaveImageFile(fileImg);

            if(imageName is not null)
            {
                updateprofileImg.photo = imageName;                
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }




        public async Task<string> SaveImageFile(IFormFile file)
        {
            string imageName = Guid.NewGuid().ToString() + ".jpg";
            string path = Path.Combine(filePathUrl, imageName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            };
            return imageName;
        }

        public async Task<bool> UpdateUserProfile(UserDto model)
        {
            var data = await _context.ApplicationUsers.Include(x=>x.UserDetails).FirstOrDefaultAsync(x=>x.Id == model.Id);
            if(data is null) 
            { 
                return false;
            }
            model.UserDetails.photo = data.UserDetails.photo;
            var d = _mapper.Map(model, data);
           
            _context.Entry(d).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
