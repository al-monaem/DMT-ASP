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
    public class AdminController : ApiController
    {
        [Route("api/admin/delete/{id}")]
        [HttpPost]
        [Admin]
        public HttpResponseMessage Delete(string id)
        {
            try
            {
                var result = AdminService.Delete(id);
                if (result)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { error = "", success = "User deleted successfully" });
                }
                return Request.CreateResponse(HttpStatusCode.OK, new { error = "Could not delete user", success = "" });

            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { error = "Server under maintenance", success = "" });
            }
        }

        [Route("api/admin/transactions")]
        [HttpGet]
        [Admin]
        public HttpResponseMessage GetTransactions()
        {
            try
            {
                var transactions = AdminService.GetTransactions();
                var count = AdminService.GetTransactionsCount();
                if (transactions != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { error = "", success = "Request successful", transactions = transactions, count=count });
                }
                return Request.CreateResponse(HttpStatusCode.OK, new { error = "Could not load transactions", success = "" });

            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { error = "Server under maintenance", success = "" });
            }
        }
        [Route("api/admin/revenues")]
        [HttpGet]
        [Admin]
        public HttpResponseMessage GetRevenues()
        {
            try
            {
                var revenues = AdminService.GetRevenues();
                if (revenues != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { error = "", success = "Request successful", revenues = revenues });
                }
                return Request.CreateResponse(HttpStatusCode.OK, new { error = "Could not load transactions", success = "" });

            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { error = "Server under maintenance", success = "" });
            }
        }

        [HttpPost]
        [Admin]
        [Route("api/verifyticket/{id}")]
        public HttpResponseMessage VerifyTicket(string id)
        {
            try
            {
                var res = AdminService.VerifyTicket(id);
                if(res)
                    return Request.CreateResponse(HttpStatusCode.OK, new { error = "", success = "Verification Successful" });

                return Request.CreateResponse(HttpStatusCode.OK, new { error = "Ticket is already used or refunded", success = "" });

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { error = "Server under maintenance", success = "" });
            }
        }

        [Admin]
        [Route("api/sendEmail")]
        public HttpResponseMessage SendEmail(EmailDTO email)
        {
            string body = string.Empty;
            using (StreamReader reader = File.OpenText("G:\\Projects\\DMT-ASP\\DMT\\DMT\\Email Template\\Email.html"))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("<%= body %>", email.body);

            MailController.Send(email.email, email.subject, body);
            return Request.CreateResponse(HttpStatusCode.OK, new { error = "", success = "Email sent to user" });
        }
    }
}
