using AutoMapper;
using Upskillz.Models.Dtos.Authentication;
using Upskillz.Web.Models;

namespace Upskillz.Web.Helpers
{
    public class AutoMapSetup : Profile
    {
        public AutoMapSetup()
        {
            //Authentication
            CreateMap<LoginDto, LoginViewModel>().ReverseMap();
        }
    }
}
