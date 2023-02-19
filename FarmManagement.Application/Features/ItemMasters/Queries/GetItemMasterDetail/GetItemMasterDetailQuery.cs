using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmManagement.Application.Features.ItemMasters.Queries.GetItemMasterDetail
{
    public class GetItemMasterDetailQuery : IRequest<ItemMasterDetailVm>
    {
        public Guid Id { get; set; }
    }
}
