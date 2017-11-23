using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehousePhysicalAPI.Models;

namespace WarehousePhysicalAPI.Domain
{
    public interface IEFDbRepository
    {
        #region Properties
        IEnumerable<Users> Users { get; }
        IEnumerable<Attributes> Attributes { get; }
        IEnumerable<ReconcileGroup> ReconcileGroup { get; }
        IEnumerable<Statuses> Statuses { get; }
        IEnumerable<StandardPrices> StandardPrices { get; }
        IEnumerable<Jobs> Jobs { get; }
        IEnumerable<SAPInputs> SAPInputs { get; }
        IEnumerable<ReconcileInputs> ReconcileInputs { get; }
        IEnumerable<ItileInputs> ItileInputs { get; }
        IEnumerable<ResultInputs> ResultInputs { get; }
        #endregion
        #region Save
        int SaveUser(Users data);
        int SaveAttribute(Attributes data);
        int SaveReconcileGroup(ReconcileGroup data);
        int SaveStatus(Statuses data);
        int SaveStandardPrices(StandardPrices data);
        Jobs SaveNewJob(JobRequestModel data);
        bool SaveSapInput(List<SAPInputs> data);
        bool SaveReconcileInput(List<ReconcileInputs> data);
        bool SaveItileInput(List<ItileInputs> data);
        bool SaveResultInput(List<ResultInputs> data);
        #endregion

        #region Delete
        bool DeleteAttribute(int data);
        bool DeleteReconcileGroup(int data);
        bool DeleteStatus(int data);
        bool DeleteStandardPrices(int data);
        #endregion
        Users CheckLogin(Users data);
        bool ChangePassword(string userName, string oldPass, string newPass);
    }
}
