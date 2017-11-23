using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WarehousePhysicalAPI.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PassWord { get; set; }
        public bool Enable { get; set; }

        public bool IsAdmin { get; set; }
    }
}