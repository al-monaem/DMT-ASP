using BLL.DTOs;
using BLL.Services;
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
    public class LoginController : ApiController
    {
        [HttpPost]
        [Route("api/login")]
        public HttpResponseMessage Login(LoginDTO user)
        {
            var token = AuthService.Authenticate(user);
            return Request.CreateResponse(HttpStatusCode.OK, token);
        }
    }
}
