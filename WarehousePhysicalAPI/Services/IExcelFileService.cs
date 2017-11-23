using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehousePhysicalAPI.Models;

namespace WarehousePhysicalAPI.Services
{
    public interface IExcelFileService
    {
        List<ReconcileInputs> ParseExcelReconcile(Stream data);
        List<SAPInputs> ParseExcelSAP(Stream data);
        List<ItileInputs> ParseExcelItile(Stream data);
        string GenerateItileExcel(int jobId);
    }
}
