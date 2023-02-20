using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmManagement.Application.Features.Uoms.Queries.GetUomDetail
{
    public class GetUomDetailQuery : IRequest<UomDetailVm>
    {
        public int Id { get; set; }
    }
}
