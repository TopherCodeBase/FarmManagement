using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmManagement.Application.Features.Uoms.Commands.DeleteUom
{
    public class DeleteUomCommand : IRequest
    {
        public int Id { get; set; }
    }
}
