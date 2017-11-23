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
    public class StandardPriceController : ApiController
    {
        private IEFDbRepository _repo;
        public StandardPriceController(IEFDbRepository repo)
        {
            if (repo == null)
                throw new ArgumentNullException();
            _repo = repo;
        }
        public IEnumerable<StandardPrices> Get()
        {

            return _repo.StandardPrices;
        }

        public int Post([FromBody]StandardPrices data)
        {
            return  _repo.SaveStandardPrices(data);
        }
        [ActionName("delete")]
        public bool StatusDelete(int id)
        {
            return _repo.DeleteStandardPrices(id);
        }
    }
}
