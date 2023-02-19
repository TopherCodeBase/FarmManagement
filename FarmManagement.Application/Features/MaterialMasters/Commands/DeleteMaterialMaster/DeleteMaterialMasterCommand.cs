using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmManagement.Application.Features.MaterialMasters.Commands.DeleteMaterialMaster
{
    public class DeleteMaterialMasterCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
