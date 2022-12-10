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
using System.Web.Http.Cors;

namespace DMT.Controllers
{
    [EnableCors("*", "*", "*")]
    public class TransactionController : ApiController
    {
        [HttpGet]
        [Route("api/stations")]
        [Logged]
        public HttpResponseMessage GetStations()
        {
            return Request.CreateResponse(HttpStatusCode.OK, TransactionService.GetStations());
        }

        [HttpGet]
        [Route("api/transactions/{id}")]
        [Admin]
        public HttpResponseMessage GetTransactions(string id)
        {
            try
            {
                var transactions = TransactionService.GetTransactions(id);
                return Request.CreateResponse(HttpStatusCode.OK, new { error = "", success = "Request Successful", transactions = transactions});
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { error = "Server under maintenance", success = "" });
            }
        }

        [HttpGet]
        [Route("api/transactions")]
        [Admin]
        public HttpResponseMessage GetTransactionsWithUsers()    
        {
            return Request.CreateResponse(HttpStatusCode.OK, TransactionService.GetTransactions());
        }

        [HttpGet]
        [Route("api/routes")]
        [Logged]
        public HttpResponseMessage GetRoutes()
        
        {
            return Request.CreateResponse(HttpStatusCode.OK, TransactionService.GetRoutes());
        }

        [HttpGet]
        [Route("api/route/{id}")]
        [Logged]
        public HttpResponseMessage GetRoute(int id)

        {
            return Request.CreateResponse(HttpStatusCode.OK, TransactionService.GetRoute(id));
        }

        [HttpPost]
        [Route("api/checkout")]
        [Logged]
        public HttpResponseMessage Checkout(GatewayDTO details)
        {
            try
            {
                var transaction = TransactionService.Checkout(details);
                if(transaction==null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new  {error="Could not complete transaction", success="" });
                }
                return Request.CreateResponse(HttpStatusCode.OK, new { error = "", success = "Payment successful", transaction=transaction });
            }
            catch(Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { error = "Server under maintenance", success = "" });
            }
        }

        [HttpPost]
        [Route("api/success")]
        public HttpResponseMessage success()
        {
            return Request.CreateResponse(HttpStatusCode.BadRequest, new { error = "Server under maintenance", success = "" });
        }
    }
}