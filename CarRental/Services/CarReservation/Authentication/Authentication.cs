using CarRental.Models;
using CarRental.Models.AccountDto;
using CarRental.Models.Data;
using CarRental.Models.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CarRental.Services.Authentication
{
    public class Authentication : IAuthentication
    {
        private readonly CarRentingDbContext _context;
        private readonly IConfiguration _config;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public Authentication(CarRentingDbContext context, IConfiguration config,
            UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _config = config;
            _userManager = userManager;
            _roleManager = roleManager;
        }


        public async Task<AuthDto> Register(SignUpDto model)
        {

            var checkUserEmail = await _userManager.FindByEmailAsync(model.email);
            if (checkUserEmail != null)
            {
                return new AuthDto { Message = "Email is already registered" };
            }
            var checkByUsername = await _userManager.FindByNameAsync(model.userName);
            if (checkByUsername != null)
            {
                return new AuthDto { Message = "Username is already registered" };
            }
            var user = new ApplicationUser
            {
                firstName = model.firstName,
                lastName = model.lastName,
                UserName = model.userName,
                Email = model.email,
                //PhoneNumber = model.phone
            };

            var result = await _userManager.CreateAsync(user, model.password);
            if (!result.Succeeded)
            {
                var errors = string.Empty;
                foreach (var error in result.Errors)
                {
                    errors += $"{error.Description},";
                }
                return new AuthDto { Message = errors };
            }
            await _userManager.AddToRoleAsync(user, EnumRoles.User);

            var jwtSecurityToken = await CreateJwtToken(user);

            return new AuthDto
            {
                Message = "User Registered Successfully",
                Email = user.Email,
                Expiration = DateTime.Now.AddMinutes(100),
                IsAuthenticated = true,
                Roles = new List<string> { EnumRoles.User },
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                UserName = user.UserName
            };
        }

        public async Task<AuthDto> Login(SignInDto model)
        {
            var authDto = new AuthDto();
            var user = await _userManager.FindByEmailAsync(model.username);

            if (user == null || !await _userManager.CheckPasswordAsync(user, model.password))
            {
                user = await _userManager.FindByNameAsync(model.username);
                if (user == null)
                {
                    authDto.Message = "Email or Password is incorrect!";
                    return authDto;
                }
            }
            var jwtSecurityToken = await CreateJwtToken(user);
            var roleList = await _userManager.GetRolesAsync(user);
            authDto.Message = "User Logged in Successfully";
            authDto.IsAuthenticated = true;
            authDto.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            authDto.Email = user.Email;
            authDto.UserName = user.UserName;
            authDto.Expiration = jwtSecurityToken.ValidTo;
            authDto.Roles = roleList.ToList();

            return authDto;
        }

        private async Task<JwtSecurityToken> CreateJwtToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = new List<Claim>();
            foreach (var role in roles)
            {
                roleClaims.Add(new Claim("roles", role));
            }
            var claims = new[]
            {
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim("Uid",user.Id)
            }.Union(userClaims).Union(roleClaims);
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Key"]));
            var signinCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(_config["JWT:Issuer"], _config["JWT:Audience"],
                claims, expires: DateTime.Now.AddDays(1), signingCredentials: signinCredentials);

            return jwtSecurityToken;

        }






    }
}
