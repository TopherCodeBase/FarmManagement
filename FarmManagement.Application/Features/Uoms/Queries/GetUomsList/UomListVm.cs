using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmManagement.Application.Features.Uoms.Queries.GetUomsList
{
    public class UomListVm
    {
        public int Id { get; set; }
        public string? UnitOfMeasure { get; set; }
        public Guid SiteId { get; set; }
    }
}
