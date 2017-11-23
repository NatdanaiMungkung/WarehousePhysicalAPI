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
    public class LoginController : ApiController
    {
        private IEFDbRepository _repo;
        public LoginController(IEFDbRepository repo)
        {
            if (repo == null)
                throw new ArgumentNullException();
            _repo = repo;
        }

        public Users Post(Users data)
        {
            return _repo.CheckLogin(data);
        }
        [ActionName("changepass")]
        public bool PasswordChangePost(string userName,string oldPass,string newPass)
        {
            return _repo.ChangePassword(userName, oldPass,newPass);
        }
    }
}
