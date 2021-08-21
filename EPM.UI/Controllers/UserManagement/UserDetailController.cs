using EPM.Core.UserManagement;
using EPM.Repository.UserManagement;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPM.UI.Controllers.UserManagement
{
    public class UserDetailController : Controller
    {
        private readonly IAuthenticate _IAuthenticateRepository;
        public UserDetailController(IAuthenticate authenticateRepository)
        {
            _IAuthenticateRepository = authenticateRepository;
        }
        public IActionResult Index()
        {
            return View("~/Views/UserManagement/CreateUser.cshtml");
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(Authenticate model)
        {
            var response = await _IAuthenticateRepository.CreateUser(model);
            return Json(response);
        }
    }
}

