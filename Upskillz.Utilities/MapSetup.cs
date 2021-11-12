using AutoMapper;
using System;
using Upskillz.Models;
using Upskillz.Models.Dtos.Samurai;

namespace Upskillz.Utilities
{
    public class MapSetup : Profile
    {
        public MapSetup()
        {
            // Samurai
            CreateMap<Samurai, AddSamuraiDto>().ReverseMap();
        }
    }
}
