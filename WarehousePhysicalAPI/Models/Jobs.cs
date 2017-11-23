using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WarehousePhysicalAPI.Models
{
    public class Jobs
    {
        public int Id { get; set; }
        public string JobName { get; set; }
        public int CreatedById { get; set; }
        public DateTime CreatedDate { get; set; }
        public int WarehouseType { get; set; }
    }
}