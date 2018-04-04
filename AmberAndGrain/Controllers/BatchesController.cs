using AmberAndGrain.Models;
using AmberAndGrain.Services;
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

            var batchRepository = new BatchRepository();
            // create method in BatchRepository takes in RecipeId and Cooker
            var result = batchRepository.Create(addBatch.RecipeId, addBatch.Cooker);

            if (result)
                return Request.CreateResponse(HttpStatusCode.Created);

            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, 
                "Could not process batch. Please try again later!!!!!");
        }
    }
}
