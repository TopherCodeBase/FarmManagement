using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmManagement.Domain.Entitites
{
    public class UOM
    {
        public int Id { get; set; }
        public string? UnitOfMeasure { get; set; }
        //Relationships
        public Guid SiteId{ get; set; }
        public SiteMaster SiteMaster { get; set; }
    }
}
