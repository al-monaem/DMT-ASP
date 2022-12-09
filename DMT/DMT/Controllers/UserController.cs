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
            try
            {
                if (!ModelState.IsValid)
                {
                    dynamic error = new { };
                    if (ModelState.ContainsKey("user.name"))
                        error = new { name = "Name must contain 4 to 20 characters" };
                    else if (ModelState.ContainsKey("user.phone"))
                        error = new { phone = "Phone must be valid" };
                    else if (ModelState.ContainsKey("user.nid"))
                        error = new { nid = "Nid must be valid" };
                    else if (ModelState.ContainsKey("user.dob"))
                        error = new { dob = "Date of birth is required" };
                    else
                        error = new { other = "Could not update profile" };

                    return Request.CreateResponse(HttpStatusCode.OK, new { success = "", error = error, modelState = ModelState });
                }
                var message = "Update Successful";
                return Request.CreateResponse(HttpStatusCode.OK, new { User = UserService.Update(user), success = message, error = "" });
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { success = "", error = "Error while updating, try again later" });
            }
        }

        [HttpPost]
        [Route("api/updatePassword")]
        [Logged]
        public HttpResponseMessage UpdatePassword(PasswordResetDTO user)
        {
            try
            {
                if(AuthService.UpdatePassword(user.id, user.currentPassword, user.newPassword) ==1)
                {
                    var message = "Update Successful";
                    return Request.CreateResponse(HttpStatusCode.OK, new{success = message, error = "" });
                }
                return Request.CreateResponse(HttpStatusCode.OK, new { success = "", error = "Current password is not correct" });
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { success = "", error = "Error while updating, try again later" });
            }
        }
    }
}
