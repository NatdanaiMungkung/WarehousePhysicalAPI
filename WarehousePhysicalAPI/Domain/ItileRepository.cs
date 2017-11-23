using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WarehousePhysicalAPI.Models;


namespace WarehousePhysicalAPI.Domain
{
    public class ItileRepository : IItileRepository
    {
        private ITILE itileContext = new ITILE();
        private EFDbContext context = new EFDbContext();
        public IQueryable<WMS_GESTIONE_UDC_PHYSICAL> WMS_GESTIONE_UDC_PHYSICAL
        {
            get
            {
                return itileContext.WMS_GESTIONE_UDC_PHYSICAL;
            }
        }

        //public IQueryable<WMS_GESTIONE_UDC> WMS_GESTIONE_UDC
        //{
        //    get
        //    {
        //        return itileContext.WMS_GESTIONE_UDC;
        //    }
        //}

        public IEnumerable<ItileInputs> ConvertToItileInputs(ItileQueryInput input)
        {
            var existData = context.ItileInputs.Where(a => a.JobId == input.JobId);
            if (existData != null)
            {
                foreach (var each in existData)
                {
                    context.ItileInputs.Remove(each);
                }
                context.SaveChanges();
            }
            var conn = new ITILE();
            List<ItileInputs> returnList = new List<ItileInputs>();
            //var myDataList = conn.Database.SqlQuery<WMS_GESTIONE_UDC>
            //("SELECT * FROM ITILE.WMS_GESTIONE_UDC").ToList();
            var myDataList = itileContext.WMS_GESTIONE_UDC_PHYSICAL.ToList();
            var job = context.Jobs.FirstOrDefault(a => a.Id == input.JobId);
            if (job.WarehouseType == 1) //WHD
            {
                myDataList = myDataList.Where(a => a.AREA.StartsWith("D.")).ToList();
            }
            else
            {
                myDataList = myDataList.Where(a => a.AREA.StartsWith("E.")).ToList();
            }
            myDataList.ForEach(each =>
            {
                //var um = itileContext.T_ARTICOLI_CONF_FLAT.FirstOrDefault(a => a.ACF_IS_STOCK && a.ACF_AR_CODICE == each.ARTICOLO_CODICE);
                var itileInput = new ItileInputs
                {
                    JobId = input.JobId,
                    JobName = job.JobName,
                    Area = each.AREA,
                    AttributeDescription = each.ATTRIBUTO_DESCRIZIONE,
                    AttributeID = each.ATTRIBUTO_CODICE,
                    Batch = each.LOTTO,
                    CreationDate = each.DATA_CREAZIONE,
                    DaysFromIntroduction = Convert.ToInt32((DateTime.Now - each.DATA_CREAZIONE).TotalDays),
                    MaterialCode = each.ARTICOLO_CODICE,
                    MaterialDescription = each.ARTICOLO_DESCRIZIONE,
                    Position = each.POSIZIONE,
                    Qty = each.QTA_INIZIALE.HasValue ? each.QTA_INIZIALE.Value : 0,
                    QtyUMStock = each.QTA_SECONDARIA.HasValue ? each.QTA_SECONDARIA.Value : 0,
                    Tag = each.TAG,
                    UL = each.UDC,
                    UM = each.UM_ALTERNATIVE,
                    UMStock = each.UM_CUSTOM,
                    SavedWhen = DateTime.Now
                    
                };
                returnList.Add(itileInput);
                context.ItileInputs.Add(itileInput);
                
            });
            context.SaveChanges();
            return returnList;
        }
    }
}