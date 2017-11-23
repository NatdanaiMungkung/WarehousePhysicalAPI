using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehousePhysicalAPI.Models;

namespace WarehousePhysicalAPI.Domain
{
    public interface IItileRepository
    {
        //IQueryable<WMS_GESTIONE_UDC> WMS_GESTIONE_UDC { get; }
        IQueryable<WMS_GESTIONE_UDC_PHYSICAL> WMS_GESTIONE_UDC_PHYSICAL { get; }
        IEnumerable<ItileInputs> ConvertToItileInputs(ItileQueryInput input);
    }
}
