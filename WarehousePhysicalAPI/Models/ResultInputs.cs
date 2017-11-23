using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WarehousePhysicalAPI.Models
{
    public class ResultInputs
    {
        public int Id { get; set; }
        public int JobId { get; set; }
        [NotMapped]
        public string JobName { get; set; }
        public string PhysInvDoc { get; set; }
        public int Item { get; set; }
        public string Plant { get; set; }
        public string Sloc { get; set; }
        public string Material { get; set; }
        public string MaterialDescription { get; set; }
        public string StockType { get; set; }
        public string Batch { get; set; }
        public decimal BookBUN { get; set; }
        public string BUN { get; set; }
        public decimal BookLUN { get; set; }
        public string LUN { get; set; }
        public decimal Amount { get; set; }
        public decimal ITileQtyLUN { get; set; }
        public DateTime SavedWhen { get; set; }

    }
}