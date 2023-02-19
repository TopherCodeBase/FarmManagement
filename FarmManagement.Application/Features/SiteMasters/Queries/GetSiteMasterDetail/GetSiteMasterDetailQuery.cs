using MediatR;

namespace FarmManagement.Application.Features.SiteMasters.Queries.GetSiteMasterDetail
{
    public class GetSiteMasterDetailQuery : IRequest<SiteMasterDetailVm>
    {
        public Guid Id { get; set; }
    }
}
