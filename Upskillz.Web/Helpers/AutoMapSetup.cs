using AutoMapper;
using System.Linq;
using Upskillz.Models.Dtos.Authentication;
using Upskillz.Models.Dtos.Samurai;
using Upskillz.Web.Models;

namespace Upskillz.Web.Helpers
{
    public class AutoMapSetup : Profile
    {
        public AutoMapSetup()
        {
            //Authentication
            CreateMap<LoginDto, LoginViewModel>().ReverseMap();

            //Samurai
            CreateMap<AddSamuraiViewModel, AddSamuraiDto>().ReverseMap();

        }
    }
}
