using AmberAndGrain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AmberAndGrain.Controllers
{
    [RoutePrefix("api/batches")]
    public class BatchesController : ApiController
    {
        [Route, HttpPost]
        public HttpResponseMessage AddBatch(AddBatchDto addBatch)
        {
            return Request.CreateResponse(HttpStatusCode.Created);
        }
    }
}
