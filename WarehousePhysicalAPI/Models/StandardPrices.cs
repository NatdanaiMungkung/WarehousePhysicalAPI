using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WarehousePhysicalAPI.Models
{
    public class StandardPrices
    {
        public int Id { get; set; }
        public string Plant { get; set; }
        public string Type { get; set; }
        public string MaterialCode { get; set; }
        public string Description { get; set; }
        public string UOM { get; set; }
        public decimal PricePerUnit { get; set; }
        public string Currency { get; set; }
    }
}