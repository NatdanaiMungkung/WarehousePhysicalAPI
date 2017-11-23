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
    public class UserController : ApiController
    {
        private IEFDbRepository _repo;
        public UserController(IEFDbRepository repo)
        {
            if (repo == null)
                throw new ArgumentNullException();
            _repo = repo;
        }
        public IEnumerable<Users> Get()
        {

            return _repo.Users;
        }

        public int Post([FromBody]Users data)
        {
            return  _repo.SaveUser(data);
        }
    }
}
