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
    public class ReconcileGroupController : ApiController
    {
        private IEFDbRepository _repo;
        public ReconcileGroupController(IEFDbRepository repo)
        {
            if (repo == null)
                throw new ArgumentNullException();
            _repo = repo;
        }
        public IEnumerable<ReconcileGroup> Get()
        {

            return _repo.ReconcileGroup;
        }
        [ActionName("getgroup")]
        public IEnumerable<object> ReconcileGroup(int id)
        {
            return _repo.ReconcileGroup.Select(a=>new { a.ReconcileGroupId, a.ReconcileGroupName,a.Sign }).Distinct() ;
        }

        public int Post([FromBody]ReconcileGroup data)
        {
            return  _repo.SaveReconcileGroup(data);
        }
        [ActionName("delete")]
        public bool ReconcileGroupDelete(int id)
        {
            return _repo.DeleteReconcileGroup(id);
        }
    }
}
