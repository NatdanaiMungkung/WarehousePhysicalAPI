using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WarehousePhysicalAPI.Models
{
    public class ReconcileInputs
    {
        public int Id { get; set; }
        public int JobId { get; set; }
        [NotMapped]
        public string JobName { get; set; }
        public string Plant { get; set; }
        public string Sloc { get; set; }
        public string MaterialCode { get; set; }
        public string MaterialDescription { get; set; }
        public string Batch { get; set; }
        public string StockType { get; set; }
        public string ReconcileTypeId { get; set; }
        public string ReconcileTypeName { get; set; }
        public string Sign { get; set; }
        public decimal Qty { get; set; }
        public string Unit { get; set; }
        public string ReferenceDoc { get; set; }
        public string ReferenceItem { get; set; }
        public string ReferenceCustomer { get; set; }
        public string ReferenceVendor { get; set; }
        public string ReferenceUL { get; set; }
        public string DataProvider { get; set; }
        public DateTime SavedWhen { get; set; }

    }
}
