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
    public class StatusController : ApiController
    {
        private IEFDbRepository _repo;
        public StatusController(IEFDbRepository repo)
        {
            if (repo == null)
                throw new ArgumentNullException();
            _repo = repo;
        }
        public IEnumerable<Statuses> Get()
        {

            return _repo.Statuses;
        }

        public int Post([FromBody]Statuses data)
        {
            return  _repo.SaveStatus(data);
        }
        [ActionName("delete")]
        public bool StatusDelete(int id)
        {
            return _repo.DeleteStatus(id);
        }
    }
}
