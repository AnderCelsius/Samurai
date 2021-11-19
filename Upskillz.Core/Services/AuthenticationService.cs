using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Upskillz.Models;
using Upskillz.Models.Dtos.Authentication;
using Upskillz.Utilities;
using Upskillz.Core.Interfaces;
using AutoMapper;
using System.Linq;

namespace Upskillz.Core.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IMapper _mapper;

        public AuthenticationService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,
            IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }

        public async Task<Response<string>> Login(LoginDto model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

            if (result.Succeeded)
            {
                return Response<string>.Success(string.Empty, "Login Succesful");
            }

            return Response<string>.Fail("Invalid Credentials"); ;
        }

        public async Task<Response<string>> Register(RegisterDto model)
        {
            var user = _mapper.Map<AppUser>(model);
            user.UserName = model.Email;

            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, UserRoles.Regular);

                return Response<string>.Success("User created successfully!", user.Id);
            }
            return Response<string>.Fail(GetErrors(result)); ;
        }
        private static string GetErrors(IdentityResult result)
        {
            return result.Errors.Aggregate(string.Empty, (current, err) => current + err.Description + "\n");
        }
    }
}
