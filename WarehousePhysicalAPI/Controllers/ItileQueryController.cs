using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WarehousePhysicalAPI.Domain;
using WarehousePhysicalAPI.Models;
using WarehousePhysicalAPI.Services;

namespace WarehousePhysicalAPI.Controllers
{
    public class ItileQueryController : ApiController
    {
        private IEFDbRepository _repo;
        private IItileRepository _itileRepo;
        private IExcelFileService _excelService;
        public ItileQueryController(IEFDbRepository repo,IItileRepository itileRepo,IExcelFileService excelService)
        {
            if (repo == null)
                throw new ArgumentNullException();
            if (itileRepo == null)
                throw new ArgumentNullException();
            if (excelService == null)
                throw new ArgumentNullException();
            _repo = repo;
            _itileRepo = itileRepo;
            _excelService = excelService;
        }

        public List<ItileInputs> Post(ItileQueryInput input)
        {
            //var request = Request.f.Files;
            var returnResult = _itileRepo.ConvertToItileInputs(input).ToList();
            return returnResult;
        }

        public string Get (int id)
        {
            return _excelService.GenerateItileExcel(id);
        }
    }
}
