
using AutoMapper;
using FarmManagement.Application.Features.Cities.Queries.GetCitiesByProvince;
using FarmManagement.Application.Features.ItemMasters.Commands.CreateItemMaster;
using FarmManagement.Application.Features.ItemMasters.Queries.GetItemMasterDetail;
using FarmManagement.Application.Features.ItemMasters.Queries.GetItemMastersList;
using FarmManagement.Application.Features.SiteMasters.Commands.CreateSiteMaster;
using FarmManagement.Application.Features.SiteMasters.Commands.UpdateSiteMaster;
using FarmManagement.Domain.Entitites;

namespace FarmManagement.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // SiteMaster
            CreateMap<SiteMaster, CreateSiteMasterCommand>().ReverseMap();
            CreateMap<SiteMaster, UpdateSiteMasterCommand>().ReverseMap();

            // City
            CreateMap<City, CityVm>().ReverseMap();

            // ItemMaster
            CreateMap<ItemMaster, ItemMasterListVm>()
                .ForMember(d => d.SiteName, o => o.MapFrom(s => s.SiteMaster.SiteName))
                .ReverseMap();
            CreateMap<ItemMaster, ItemMasterDetailVm>()
                .ForMember(d => d.SiteName, o => o.MapFrom(s => s.SiteMaster.SiteName))
                .ReverseMap();
            CreateMap<ItemMaster, CreateItemMasterCommand>().ReverseMap();
        }
    }
}
