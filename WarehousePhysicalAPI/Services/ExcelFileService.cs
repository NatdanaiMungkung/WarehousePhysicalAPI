using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using WarehousePhysicalAPI.Domain;
using WarehousePhysicalAPI.Models;

namespace WarehousePhysicalAPI.Services
{
    public class ExcelFileService : IExcelFileService
    {
        private XLWorkbook xlWork;
        private IEFDbRepository _repo;
        public ExcelFileService()
        {
            _repo = new EFRepository();
        }

        public string GenerateItileExcel(int jobId)
        {
            var dataList = _repo.ItileInputs.Where(a => a.JobId == jobId);
            //Clean old files
            var path = System.AppDomain.CurrentDomain.BaseDirectory;
            var fileList = Directory.GetFiles(path + @"\");
            var workbook = new XLWorkbook(path + @"\ItileTemplate.xlsx");
            foreach (var each in fileList)
            {
                if (each.Contains("ItileOutput"))
                {
                    if (System.IO.File.GetCreationTime(each) < DateTime.Now.AddDays(-1))
                        System.IO.File.Delete(each);
                }
            }
            var worksheet = workbook.Worksheet(1);
            var row = 6;
            var column = 2;
            dataList.ForEach(data =>
            {
                worksheet.Cell(row, column++).Value = data.JobName;
                worksheet.Cell(row, column++).Value = data.PhysicalDocumentNo;
                worksheet.Cell(row, column++).Value = data.PhysicalDocumentBookNo;
                worksheet.Cell(row, column++).Value = data.UL;
                worksheet.Cell(row, column++).Value = data.Area;
                worksheet.Cell(row, column++).Value = data.Position;
                worksheet.Cell(row, column++).Value = data.MaterialCode;
                worksheet.Cell(row, column++).Value = data.MaterialDescription;
                worksheet.Cell(row, column++).Value = data.Batch;
                worksheet.Cell(row, column++).Value = data.Qty;
                worksheet.Cell(row, column++).Value = data.UM;
                worksheet.Cell(row, column++).Value = data.QtyUMStock;
                worksheet.Cell(row, column++).Value = data.UMStock;
                worksheet.Cell(row, column++).Value = data.AttributeID;
                worksheet.Cell(row, column++).Value = data.AttributeDescription;
                worksheet.Cell(row, column++).Value = data.CreationDate;
                worksheet.Cell(row, column++).Value = data.DaysFromIntroduction;
                worksheet.Cell(row, column++).Value = data.Tag;
                row++;
                column = 2;
            });
            Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            var fileName = $"/ItileOutput{unixTimestamp}.xlsx";
            workbook.SaveAs(path + fileName);
            return fileName;
        }

        public List<ItileInputs> ParseExcelItile(Stream data)
        {
            List<ItileInputs> resultList = new List<ItileInputs>();
            xlWork = new XLWorkbook(data);
            var workSheet = xlWork.Worksheet(1);
            int column = 2;
            int row = 6;
            int? jobId = 0;
            while (workSheet.Cell(row, column).GetString() != "")
            {
                ItileInputs eachRowResult = new ItileInputs();

                eachRowResult.JobName = workSheet.Cell(row, column++).GetString();
                if (jobId == 0)
                    jobId = _repo.Jobs.FirstOrDefault(a => a.JobName == eachRowResult.JobName)?.Id;
                eachRowResult.JobId = jobId.HasValue ? jobId.Value : 0;
                eachRowResult.PhysicalDocumentNo = workSheet.Cell(row, column++).GetString();
                eachRowResult.PhysicalDocumentBookNo = workSheet.Cell(row, column++).GetString();
                eachRowResult.UL = workSheet.Cell(row, column++).GetString();
                eachRowResult.Area = workSheet.Cell(row, column++).GetString();
                eachRowResult.Position = workSheet.Cell(row, column++).GetString();
                eachRowResult.MaterialCode = workSheet.Cell(row, column++).GetString();
                eachRowResult.MaterialDescription = workSheet.Cell(row, column++).GetString();
                eachRowResult.Batch = workSheet.Cell(row, column++).GetString();
                decimal qty = 0;
                Decimal.TryParse(workSheet.Cell(row, column++).GetString(), out qty);
                eachRowResult.Qty = qty;
                eachRowResult.UM = workSheet.Cell(row, column++).GetString();
                Decimal.TryParse(workSheet.Cell(row, column++).GetString(), out qty);
                eachRowResult.QtyUMStock = qty;
                eachRowResult.UMStock = workSheet.Cell(row, column++).GetString();
                eachRowResult.AttributeID = workSheet.Cell(row, column++).GetString();
                eachRowResult.AttributeDescription = workSheet.Cell(row, column++).GetString();
                DateTime date = DateTime.Now;
                DateTime.TryParse(workSheet.Cell(row, column++).GetString(),out date);
                eachRowResult.CreationDate = date;
                int days = 0;
                Int32.TryParse(workSheet.Cell(row, column++).GetString(), out days);
                eachRowResult.DaysFromIntroduction = days;
                eachRowResult.Tag = workSheet.Cell(row, column++).GetString();
                resultList.Add(eachRowResult);
                row++;
                column = 2;
            }
            return resultList;
        }

        public List<ReconcileInputs> ParseExcelReconcile(Stream data)
        {
            
            List<ReconcileInputs> resultList = new List<ReconcileInputs>();
            xlWork = new XLWorkbook(data);
            var workSheet = xlWork.Worksheet(1);
            int column = 2;
            int row = 5;
            int? jobId = 0;
            while (workSheet.Cell(row,column).GetString() != "")
            {
                ReconcileInputs eachRowResult = new ReconcileInputs();
                
                eachRowResult.JobName = workSheet.Cell(row, column++).GetString();
                if (jobId == 0)
                    jobId = _repo.Jobs.FirstOrDefault(a => a.JobName == eachRowResult.JobName)?.Id;
                eachRowResult.JobId = jobId.HasValue ? jobId.Value : 0;
                eachRowResult.Plant = workSheet.Cell(row, column++).GetString();
                eachRowResult.Sloc = workSheet.Cell(row, column++).GetString();
                eachRowResult.MaterialCode = workSheet.Cell(row, column++).GetString();
                eachRowResult.MaterialDescription = workSheet.Cell(row, column++).GetString();
                eachRowResult.Batch = workSheet.Cell(row, column++).GetString();
                eachRowResult.StockType = workSheet.Cell(row, column++).GetString();
                eachRowResult.ReconcileTypeId = workSheet.Cell(row, column++).GetString();
                eachRowResult.ReconcileTypeName = workSheet.Cell(row, column++).GetString();
                eachRowResult.Sign = workSheet.Cell(row, column++).GetString();
                decimal qty = 0;
                Decimal.TryParse(workSheet.Cell(row, column++).GetString(),out qty);
                eachRowResult.Qty = qty;
                eachRowResult.Unit = workSheet.Cell(row, column++).GetString();
                eachRowResult.ReferenceDoc = workSheet.Cell(row, column++).GetString();
                eachRowResult.ReferenceItem = workSheet.Cell(row, column++).GetString();
                eachRowResult.ReferenceCustomer = workSheet.Cell(row, column++).GetString();
                eachRowResult.ReferenceVendor = workSheet.Cell(row, column++).GetString();
                eachRowResult.ReferenceUL = workSheet.Cell(row, column++).GetString();
                eachRowResult.DataProvider = workSheet.Cell(row, column++).GetString();
                resultList.Add(eachRowResult);
                row++;
                column = 2;
            }
            return resultList;
        }

        public List<SAPInputs> ParseExcelSAP(Stream data)
        {
            List<SAPInputs> resultList = new List<SAPInputs>();
            int? jobId = 0;
            xlWork = new XLWorkbook(data);
            var workSheet = xlWork.Worksheet(1);
            int column = 1;
            int row = 2;
            while (workSheet.Cell(row, column).GetString() != "")
            {
                SAPInputs eachRowResult = new SAPInputs();
                eachRowResult.JobName = workSheet.Cell(row, column++).GetString();
                if (jobId == 0)
                    jobId = _repo.Jobs.FirstOrDefault(a => a.JobName == eachRowResult.JobName)?.Id;
                eachRowResult.JobId = jobId.HasValue ? jobId.Value : 0;
                eachRowResult.PhysInvDoc = workSheet.Cell(row, column++).GetString();
                eachRowResult.Item = Convert.ToInt32(workSheet.Cell(row, column++).GetString());
                eachRowResult.Plant= workSheet.Cell(row, column++).GetString();
                eachRowResult.Sloc = workSheet.Cell(row, column++).GetString();
                eachRowResult.MaterialCode = workSheet.Cell(row, column++).GetString();
                eachRowResult.MaterialDescription = workSheet.Cell(row, column++).GetString();
                eachRowResult.StockType = workSheet.Cell(row, column++).GetString();
                eachRowResult.Batch = workSheet.Cell(row, column++).GetString();
                eachRowResult.BookQty= Convert.ToDecimal(workSheet.Cell(row, column++).GetString());
                eachRowResult.BUN = workSheet.Cell(row, column++).GetString();
                eachRowResult.Values = Convert.ToDecimal(workSheet.Cell(row, column++).GetString());
                resultList.Add(eachRowResult);
                row++;
                column = 1;
            }
            return resultList;
        }
    }
}