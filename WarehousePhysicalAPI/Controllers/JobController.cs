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
    public class JobController : ApiController
    {
        private IEFDbRepository _repo;
        public JobController(IEFDbRepository repo)
        {
            if (repo == null)
                throw new ArgumentNullException();
            _repo = repo;
        }
        [ActionName("GetIncompleted")]
        public IEnumerable<Jobs> Get(int id)
        {
            var whdJob = _repo.Jobs.Where(a=>a.CreatedById == id).OrderByDescending(a=>a.CreatedDate);
            //var wheJob = _repo.Jobs.Where(a => a.WarehouseType == 2);
            return whdJob;
        }
        [ActionName("GetCompleted")]
        public IEnumerable<Jobs> GetCompleted(int id)
        {
            var whdJob = _repo.Jobs.Where(a => a.CreatedById == id).OrderByDescending(a => a.CreatedDate);
            //var wheJob = _repo.Jobs.Where(a => a.WarehouseType == 2);
            return whdJob;
        }

        public Jobs Post([FromBody]JobRequestModel data)
        {
            return  _repo.SaveNewJob(data);
        }
    }
}
