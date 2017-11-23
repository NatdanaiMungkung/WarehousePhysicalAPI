using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WarehousePhysicalAPI.Models
{
    public class JobRequestModel
    {
        public string Prefix { get; set; }
        public int RequesterUserId { get; set; }
    }
}