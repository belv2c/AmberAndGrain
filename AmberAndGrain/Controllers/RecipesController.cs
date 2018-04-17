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
    [RoutePrefix("api/recipes")]
    public class RecipesController : ApiController
    {
        // add api endpoint that gets appended to the routeprefix on the class
        [HttpPost, Route("")]
        public HttpResponseMessage AddRecipe (RecipeDto recipe)
        {
            var recipeRepository = new RecipeRepository();
            var success = recipeRepository.Create(recipe);

            if (success)
                return Request.CreateResponse(HttpStatusCode.Created);

            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError,
                "Could not process order, please try again later... ");
        }
        [Route(""), HttpGet]
        public HttpResponseMessage GetAllRecipes()
        {
            var repo = new RecipeRepository();
            List<RecipeDto> recipes = repo.GetAll();

            return Request.CreateResponse(HttpStatusCode.OK, recipes);
        }
    }
}
