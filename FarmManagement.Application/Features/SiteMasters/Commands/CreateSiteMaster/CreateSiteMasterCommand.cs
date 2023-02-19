using FarmManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmManagement.Application.Features.SiteMasters.Commands.CreateSiteMaster
{
    public class CreateSiteMasterCommand : IRequest<BaseResponse>
    {
        public string? SiteCode { get; set; }
        public string? SiteName { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? Province { get; set; }
        public string? Zip { get; set; }
        public Guid OwnerId { get; set; }
        public Guid ParentSiteId { get; set; }
    }
}
