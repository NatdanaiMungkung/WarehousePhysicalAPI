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
    public class ItileSaveController : ApiController
    {
        private IEFDbRepository _repo;
        public ItileSaveController(IEFDbRepository repo)
        {
            if (repo == null)
                throw new ArgumentNullException();
            _repo = repo;
        }

        public IEnumerable<ItileInputs> Get(int id)
        {
            var job = _repo.Jobs.FirstOrDefault(a => a.Id == id);
            var inputs = _repo.ItileInputs.Where(a => a.JobId == id);
            foreach (var each in inputs)
            {
                each.JobName = job.JobName;
            }
            return inputs;
        }

        public bool Post(List<ItileInputs> data)
        {
            return _repo.SaveItileInput(data);
        }
    }
}
