using AmberAndGrain.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AmberAndGrain.Services
{
    public class BatchRepository
    {
        public bool Create(int recipeId, string cooker)
        {
            using (var db = new SqlConnection(ConfigurationManager.ConnectionStrings["AmberAndGrain"].ConnectionString))
            {
                db.Open();

                // anonymous type
                // creating a new object that is set to the value of the parameter that was passed in
                // execute always return number of rows that were affected/created
               var batchesCreated = db.Execute(@"Insert into Batches (RecipeId, Cooker)
                             Values (@RecipeId, @Cooker)", new {recipeId, cooker});

                return batchesCreated == 1;

            }
        }
    }
}
