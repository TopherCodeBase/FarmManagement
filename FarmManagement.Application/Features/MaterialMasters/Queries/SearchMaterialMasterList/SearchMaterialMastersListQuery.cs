using FarmManagement.Application.Features.MaterialMasters.Queries.GetMaterialMasterList;
using MediatR;

namespace FarmManagement.Application.Features.MaterialMasters.Queries.SearchMaterialMasterList
{
    public class SearchMaterialMastersListQuery : IRequest<List<MaterialMasterListVm>>
    {
        public string Query { get; set; }
        public Guid SiteId { get; set; }
    }
}
