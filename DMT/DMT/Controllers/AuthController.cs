using BLL.DTOs;
using BLL.Services;
using DMT.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DMT.Controllers
{
    [EnableCors("*", "*", "*")]
    public class AuthController : ApiController
    {
        [HttpPost]
        [Route("api/login")]
        public HttpResponseMessage Login(LoginDTO user)
        {
            var token = AuthService.Authenticate(user);
            return Request.CreateResponse(HttpStatusCode.OK, token);
        }

        [Logged]
        [HttpPost]
        [Route("api/logout")]
        public HttpResponseMessage Logout()
        {
            var rs = AuthService.ExpireToken(Request.Headers.Authorization.ToString());
            if(rs)
                return Request.CreateResponse(HttpStatusCode.OK);

            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
    }
}
