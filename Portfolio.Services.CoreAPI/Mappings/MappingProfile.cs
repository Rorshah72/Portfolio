using AutoMapper;
using Portfolio.Shared.Models.DTOs;
using Portfolio.Shared.Models;

namespace Portfolio.Services.CoreAPI.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Skill, SkillDto>().ReverseMap();
            CreateMap<Project, ProjectDto>().ReverseMap();
        }
    }
}
