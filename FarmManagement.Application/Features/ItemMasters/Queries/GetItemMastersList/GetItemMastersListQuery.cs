using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmManagement.Application.Features.ItemMasters.Queries.GetItemMastersList
{
    public class GetItemMastersListQuery : IRequest<List<ItemMasterListVm>>
    {
    }
}
