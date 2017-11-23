using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WarehousePhysicalAPI.Models
{
    public class ItileInputs
    {
        public int Id { get; set; }
        public int JobId { get; set; }
        [NotMapped]
        public string JobName { get; set; }
        public string PhysicalDocumentNo { get; set; }
        public string PhysicalDocumentBookNo { get; set; }
        public string UL { get; set; }
        public string Area { get; set; }
        public string Position { get; set; }
        public string MaterialCode { get; set; }
        public string MaterialDescription { get; set; }
        public string Batch { get; set; }
        public decimal Qty { get; set; }
        public string UM { get; set; }
        public decimal QtyUMStock { get; set; }
        public string UMStock { get; set; }
        public string AttributeID { get; set; }
        public string AttributeDescription { get; set; }
        public DateTime CreationDate { get; set; }
        public int DaysFromIntroduction { get; set; }
        public string Tag { get; set; }
        public DateTime SavedWhen { get; set; }
    }
}