using EPM.Core.UserManagement;
using EPM.Repository.UserManagement;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPM.UI.Controllers.UserManagement
{
    public class AuthenticateController : Controller
    {
        private readonly IAuthenticate _IAuthenticateRepository;
        public AuthenticateController(IAuthenticate authenticateRepository)
        {
            _IAuthenticateRepository = authenticateRepository;
        }
        public IActionResult Index()
        {
            return View("~/Views/UserManagement/Login.cshtml");
        }
        [HttpPost]
        public async Task<IActionResult> Login(Authenticate model)
        {
            var response = await _IAuthenticateRepository.IsAuthenticate(model);
            if (response)
            {
                HttpContext.Session.SetString("Username", model.UserName);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Authenticate");
            }
        }
    }
}
