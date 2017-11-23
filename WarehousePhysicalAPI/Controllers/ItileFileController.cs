﻿using System;
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
    public class ItileFileController : ApiController
    {
        private IEFDbRepository _repo;
        private IExcelFileService _excelFileService;
        public ItileFileController(IEFDbRepository repo, IExcelFileService excelFileService)
        {
            if (repo == null)
                throw new ArgumentNullException();
            if (excelFileService == null)
                throw new ArgumentNullException();
            _repo = repo;
            _excelFileService = excelFileService;
        }

        public List<ItileInputs> Post()
        {
            var httpRequest = HttpContext.Current.Request;
            List<ItileInputs> returnResult = new List<ItileInputs>();
            //var request = Request.f.Files;
            if (httpRequest.Files.Count < 1)
            {
                return null;
            }

            foreach (string file in httpRequest.Files)
            {
                var postedFile = httpRequest.Files[file];
                var filePath = HttpContext.Current.Server.MapPath("~/" + postedFile.FileName);
                var inputSteam = postedFile.InputStream;
                returnResult = _excelFileService.ParseExcelItile(inputSteam);
                // NOTE: To store in memory use postedFile.InputStream
            }
            return returnResult;
        }
    }
}
