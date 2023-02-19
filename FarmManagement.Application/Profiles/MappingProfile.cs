using AutoMapper;
using FarmManagement.Application.Features.Cities.Queries.GetCitiesByProvince;
using FarmManagement.Application.Features.ItemMasters.Commands.CreateItemMaster;
using FarmManagement.Application.Features.ItemMasters.Commands.UpdateItemMaster;
using FarmManagement.Application.Features.ItemMasters.Queries.GetItemMasterDetail;
using FarmManagement.Application.Features.ItemMasters.Queries.GetItemMastersList;
using FarmManagement.Application.Features.MaterialMasters.Commands.CreateMaterialMaster;
using FarmManagement.Application.Features.MaterialMasters.Commands.UpdateMaterialMaster;
using FarmManagement.Application.Features.MaterialMasters.Queries.GetMaterialMasterDetail;
using FarmManagement.Application.Features.MaterialMasters.Queries.GetMaterialMasterList;
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
            CreateMap<ItemMaster, CreateItemMasterCommand>().ReverseMap();
            CreateMap<ItemMaster, UpdateItemMasterCommand>().ReverseMap();
            CreateMap<ItemMaster, ItemMasterListVm>()
                .ForMember(d => d.SiteName, o => o.MapFrom(s => s.SiteMaster.SiteName))
                .ReverseMap();
            CreateMap<ItemMaster, ItemMasterDetailVm>()
                .ForMember(d => d.SiteName, o => o.MapFrom(s => s.SiteMaster.SiteName))
                .ReverseMap();

            // MaterialMaster
            CreateMap<MaterialMaster, CreateMaterialMasterCommand>().ReverseMap();
            CreateMap<MaterialMaster, UpdateMaterialMasterCommand>().ReverseMap();
            CreateMap<MaterialMaster,MaterialMasterDetailVm>()
                .ForMember(d => d.SiteName, o => o.MapFrom(s => s.SiteMaster.SiteName))
                .ForMember(d => d.SiteCode, o => o.MapFrom(s => s.SiteMaster.SiteCode))
                .ForMember(d => d.ItemDescription, o => o.MapFrom(s => s.ItemMaster.Description))
                .ForMember(d => d.ItemNo, o => o.MapFrom(s => s.ItemMaster.ItemNo))
                .ForMember(d => d.ItemType, o => o.MapFrom(s => s.ItemMaster.ItemType))
                .ForMember(d => d.ItemUnitOfMeasure, o => o.MapFrom(s => s.ItemMaster.UnitOfMeasure))
                .ReverseMap();
            CreateMap<MaterialMaster, MaterialMasterListVm>()
                .ForMember(d => d.SiteName, o => o.MapFrom(s => s.SiteMaster.SiteName))
                .ForMember(d => d.SiteCode, o => o.MapFrom(s => s.SiteMaster.SiteCode))
                .ForMember(d => d.ItemDescription, o => o.MapFrom(s => s.ItemMaster.Description))
                .ForMember(d => d.ItemNo, o => o.MapFrom(s => s.ItemMaster.ItemNo))
                .ForMember(d => d.ItemType, o => o.MapFrom(s => s.ItemMaster.ItemType))
                .ForMember(d => d.ItemUnitOfMeasure, o => o.MapFrom(s => s.ItemMaster.UnitOfMeasure))
                .ReverseMap();
        }
    }
}
