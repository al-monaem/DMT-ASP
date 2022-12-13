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
            try
            {
                var token = AuthService.Authenticate(user);
                if(token == null)
                    return Request.CreateResponse(HttpStatusCode.OK, new { success = "", error = "Email or password is incorrect" });
               
                return Request.CreateResponse(HttpStatusCode.OK, new { success = token, error = "" });
            }
            catch(Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { success = "", error = "Server under maintenance" });
            }
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

        [HttpPost]
        [Route("api/passwordreset")]
        public HttpResponseMessage ResetPassword(PasswordResetDTO data)
        {
            try
            {
                if(data == null)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { success = "", error = "Could not send OTP! Try again later" });

                if (data.otp.Equals(""))
                {
                    dynamic result = AuthService.ResetPassword(data);
                    if (result is ResetDTO)
                    {
                        string body = string.Empty;
                        using (StreamReader reader = File.OpenText("G:\\Projects\\DMT-ASP\\DMT\\DMT\\Email Template\\ResetEmail.html"))
                        {
                            body = reader.ReadToEnd();
                        }
                        body = body.Replace("<%= otp %>", result.OTP.ToString());
                        MailController.Send(data.email, "Reset Password", body);
                        return Request.CreateResponse(HttpStatusCode.OK, new { success = "Check your email for OTP", error = "" });
                    }

                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, new { success = "", error = "User do not exist!" });
                    }
                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        var res = AuthService.ResetPassword(data);
                        if (res)
                            return Request.CreateResponse(HttpStatusCode.OK, new { success = "Password Reset Complete", error = "" });
                        return Request.CreateResponse(HttpStatusCode.OK, new { success = "", error = "Could not reset password! Try again later" });
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, new { success = "", error = "Password Error", modelState = ModelState });
                    }
                }
            }catch(Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { success = "", error = e.Message });
            }
        }
    }
}
