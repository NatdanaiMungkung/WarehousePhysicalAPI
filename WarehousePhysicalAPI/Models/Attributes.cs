using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WarehousePhysicalAPI.Models
{
    public class Attributes
    {
        public int Id { get; set; }
        public string Attribute { get; set; }
        public string Description { get; set; }
        public string WHDPlant { get; set; }
        public string WHDSloc { get; set; }
        public string WHEPlant { get; set; }
        public string WHESloc { get; set; }
    }
}