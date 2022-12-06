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
            return Request.CreateResponse(HttpStatusCode.OK, TransactionService.GetTransactions(id));
        }

        [HttpGet]
        [Route("api/transactions")]
        [Admin]
        public HttpResponseMessage GetTransactionsWithUsers()    
        {
            return Request.CreateResponse(HttpStatusCode.OK, TransactionService.GetTransactions());
        }
    }
}