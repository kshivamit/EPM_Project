using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPM.UI.Helper
{
    public class CustomAuthenticate : TypeFilterAttribute
    {
        public CustomAuthenticate() : base(typeof(AuthenticateUser))
        {

        }
        public class AuthenticateUser : IAuthorizationFilter
        {
            public void OnAuthorization(AuthorizationFilterContext context)
            {
                if (context.HttpContext.Session.GetString("Username") == null)
                {
                    context.Result = new RedirectToActionResult("Index", "Authenticate", null);
                }
            }
        }
    }
}
