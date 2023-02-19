
using AutoMapper;
using FarmManagement.Application.Features.SiteMasters.Commands.CreateSiteMaster;
using FarmManagement.Application.Features.SiteMasters.Commands.UpdateSiteMaster;
using FarmManagement.Domain.Entitites;

namespace FarmManagement.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<SiteMaster, CreateSiteMasterCommand>().ReverseMap();
            CreateMap<SiteMaster, UpdateSiteMasterCommand>().ReverseMap();
        }
    }
}
