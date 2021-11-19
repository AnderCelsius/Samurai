using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Upskillz.Models;
using Upskillz.Models.Dtos.Authentication;
using Upskillz.Utilities;
using Upskillz.Core.Interfaces;
using AutoMapper;
using Upskillz.Data.Abstractions;
using System.Linq;

namespace Upskillz.Core.Services
{
    internal class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AuthenticationService(UserManager<AppUser> userManager, IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<Response<LoginResponseDto>> Login(LoginDto model)
        {
            return null;
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
