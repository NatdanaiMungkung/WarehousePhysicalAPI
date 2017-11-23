using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WarehousePhysicalAPI.Domain;
using WarehousePhysicalAPI.Models;

namespace WarehousePhysicalAPI.Controllers
{
    public class ChangePasswordController : ApiController
    {
        private IEFDbRepository _repo;
        public ChangePasswordController(IEFDbRepository repo)
        {
            if (repo == null)
                throw new ArgumentNullException();
            _repo = repo;
        }

        public bool Post(ChangePasswordModel data)
        {
            return _repo.ChangePassword(data.userName, data.oldPass,data.newPass);
        }
    }

    public class ChangePasswordModel
    {
        public string userName { get; set; }
        public string oldPass { get; set; }
        public string newPass { get; set; }
    }
}
