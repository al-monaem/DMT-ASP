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
                if (transactions != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { error = "", success = "Request successful", transactions= transactions });
                }
                return Request.CreateResponse(HttpStatusCode.OK, new { error = "Could not load transactions", success = "" });

            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { error = "Server under maintenance", success = "" });
            }
        }
    }
}
