using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmManagement.Application.Features.SiteMasters.Commands.DeleteSiteMaster
{
    public class DeleteSiteMasterCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
