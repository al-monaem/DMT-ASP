using BLL.DTOs;
using BLL.Services;
using DMT.Auth;
using System;
using System.Collections.Generic;
using System.IO;
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

        [HttpPost]
        [Route("api/register")]
        public HttpResponseMessage Register(UserRegisterDTO user)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    dynamic error = new { };
                    if (ModelState.ContainsKey("user.id"))
                        error = new { id = "This ID is already in use" };
                    else if (ModelState.ContainsKey("user.name"))
                        error = new { name = "Name must contain 4 to 20 characters" };
                    else if (ModelState.ContainsKey("user.email"))
                        error = new { email = "This email is already in use" };
                    else if (ModelState.ContainsKey("user.password"))
                        error = new { password = "Password and Confirm Password must match" };
                    else if (ModelState.ContainsKey("user.confirmPassword"))
                        error = new { confirmPassword = "Password and Confirm Password must match" };
                    else if (ModelState.ContainsKey("user.phone"))
                        error = new { phone = "Phone must be valid" };
                    else if (ModelState.ContainsKey("user.nid"))
                        error = new { nid = "Nid must be valid" };
                    else if (ModelState.ContainsKey("user.dob"))
                        error = new { dob = "Date of birth is required" };

                    return Request.CreateResponse(HttpStatusCode.OK, new { success = "", error = error, modelState = ModelState });
                }
                AuthService.Register(user);

                string body = string.Empty;
                using (StreamReader reader = File.OpenText("G:\\Projects\\DMT-ASP\\DMT\\DMT\\Email Template\\RegistrationConfirmed.html"))
                {
                    body = reader.ReadToEnd();
                }

                MailController.Send(user.email,"Registration Completed", body);
                return Request.CreateResponse(HttpStatusCode.OK, new { success = "User registered successfully", error="" });
            }
            catch(Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { success = "" , error=e.Message});
            }
        }
    }
}
