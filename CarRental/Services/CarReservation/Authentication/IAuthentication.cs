using CarRental.Models.AccountDto;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Services.Authentication
{
    public interface IAuthentication
    {
        Task<AuthDto> Register(SignUpDto model);
        Task<AuthDto> Login(SignInDto model);
    }
}
