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
    public class ReconcileSaveController : ApiController
    {
        private IEFDbRepository _repo;
        public ReconcileSaveController(IEFDbRepository repo)
        {
            if (repo == null)
                throw new ArgumentNullException();
            _repo = repo;
        }

        public IEnumerable<ReconcileInputs> Get(int id)
        {
            var job = _repo.Jobs.FirstOrDefault(a => a.Id == id);
            var inputs = _repo.ReconcileInputs.Where(a => a.JobId == id);
            foreach (var each in inputs)
            {
                each.JobName = job.JobName;
            }
            return inputs;
        }

        public bool Post(List<ReconcileInputs> data)
        {
            return _repo.SaveReconcileInput(data);
        }
    }
}
