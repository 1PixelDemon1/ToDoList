using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using ToDoList.AuthService.Data;
using ToDoList.AuthService.Models;
using ToDoList.AuthService.Models.Dtos;
using ToDoList.AuthService.Service.IService;

namespace ToDoList.AuthService.Service
{
    // This class will manage all hard work for our controller.
    public class AuthenticationService : IAuthenticationService
    {
        private readonly AuthenticationDbContext _db;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthenticationService(AuthenticationDbContext db, UserManager<ApplicationUser> userManager, 
            RoleManager<IdentityRole> roleManager, IJwtTokenGenerator jwtTokenGenerator)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto)
        {
            var user = _db.ApplicationUsers.
                FirstOrDefault(u => u.Email.ToLower() == loginRequestDto.Email.ToLower());
            bool isValid = await _userManager.CheckPasswordAsync(user, loginRequestDto.Password);
            if(user is null || !isValid)
            {
                return new LoginResponseDto() { Token = "", User = null };
            }
            var roles = await _userManager.GetRolesAsync(user);
            string token = _jwtTokenGenerator.GenerateToken(user, roles);
            
            UserDto userDto = new()
            {
                Email = user.Email,
                Id = user.Id,
                FullName = user.UserName
            };

            LoginResponseDto loginResponseDto = new()
            {
                Token = token,
                User = userDto
            };

            return loginResponseDto;
        }

        public async Task<string> Register(RegistrationRequestDto registrationRequestDto)
        {
            ApplicationUser user = new()
            {
                UserName = registrationRequestDto.FullName,
                Email = registrationRequestDto.Email,
                NormalizedEmail = registrationRequestDto.Email.ToUpper(),
            };

            try
            {
                var result = await _userManager.CreateAsync(user, registrationRequestDto.Password);
                if(result.Succeeded)
                {
                    return "";
                }
                else
                {
                    return result.Errors.FirstOrDefault().Description;
                }
            }
            catch
            {
                return "Error encountered!";
            }
        }
        
        public async Task<bool> AssignRole(string email, string roleName)
        {
            var user = _db.ApplicationUsers.FirstOrDefault(u => u.UserName.ToLower() == email);
            if (user is not null)
            {
                if(!_roleManager.RoleExistsAsync(roleName).GetAwaiter().GetResult())
                {
                    // Create new role if this one does not exist.
                    await _roleManager.CreateAsync(new IdentityRole(roleName));
                }
                await _userManager.AddToRoleAsync(user, roleName);
                return true;
            }
            return false;
        }

    }
}
