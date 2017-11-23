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
    public class AttributeController : ApiController
    {
        private IEFDbRepository _repo;
        public AttributeController(IEFDbRepository repo)
        {
            if (repo == null)
                throw new ArgumentNullException();
            _repo = repo;
        }
        public IEnumerable<Attributes> Get()
        {

            return _repo.Attributes;
        }

        public int Post([FromBody]Attributes data)
        {
            return  _repo.SaveAttribute(data);
        }
        [ActionName("delete")]
        public bool AttributeDelete(int id)
        {
            return _repo.DeleteAttribute(id);
        }
    }
}
