using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Upskillz.Models.Dtos.Authentication;
using Upskillz.Utilities;

namespace Upskillz.Core.Interfaces
{
    public interface IAuthenticationService
    {
        Task<Response<string>> Login(LoginDto model);
        Task<Response<string>> Register(RegisterDto model);
    }
}
