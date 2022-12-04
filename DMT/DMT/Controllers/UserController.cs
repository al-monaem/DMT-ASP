using BLL.DTOs;
using BLL.Services;
using DMT.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Cors;

namespace DMT.Controllers
{
    [EnableCors("*", "*", "*")]
    public class UserController : ApiController
    {
        [HttpGet]
        [Route("api/user")]
        [Logged]
        public HttpResponseMessage Get(string id)
        {
            var user = UserService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, user);
        }
        [HttpGet]
        [Route("api/admin/users")]
        [Admin]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, UserService.Get());
        }
        [HttpPost]
        [Route("api/update")]
        [Logged]
        public HttpResponseMessage Update(UserDTO user)
        {
            var message = "Update Successful";
            return Request.CreateResponse(HttpStatusCode.OK, new {User= UserService.Update(user), message= message } );
        }
    }
}
