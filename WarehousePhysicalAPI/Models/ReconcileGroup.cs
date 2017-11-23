using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WarehousePhysicalAPI.Domain;

namespace WarehousePhysicalAPI.Models
{
    public class ReconcileGroup
    {
        private IEFDbRepository _repo;
        public ReconcileGroup()
        {
            _repo = new EFRepository();
        }
        public int Id { get; set; }
        public string ReconcileGroupId { get; set; }
        public string ReconcileGroupName { get; set; }
        public string ReconcileType { get; set; }
        public string ReconcileTypeName { get; set; }
        public string Sign { get; set; }
        public int ResponseUserId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastChangedDate { get; set; }
        [NotMapped]
        public string ResponsePerson { get
            {
                return _repo.Users.FirstOrDefault(a => a.Id == ResponseUserId)?.UserName;
            } }
    }
}