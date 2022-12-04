using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace DMT.Auth
{
    [Logged]
    public class Admin : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            string token = actionContext.Request.Headers.Authorization.ToString();
            var admin = AuthService.IsAdmin(token);

            if(!admin)
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(System.Net.HttpStatusCode.Unauthorized, "Permission Denied");
            }

            base.OnAuthorization(actionContext);
        }
    }
}