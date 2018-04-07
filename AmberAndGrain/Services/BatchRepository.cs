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
            using (var db = GetConnection())
            {
                db.Open();

                // anonymous type
                // creating a new object that is set to the value of the parameter that was passed in
                // execute always returns number of rows that were affected/created
               var batchesCreated = db.Execute(@"Insert into Batches (RecipeId, Cooker)
                             Values (@RecipeId, @Cooker)", new {recipeId, cooker});

                return batchesCreated == 1;

            }
        }

        public Batch GetBatch(int batchId)
        {
            using (var db = GetConnection())
            {
                db.Open();

                // query always returns a list even if there's only one matching
                var getSingleBatch = db.QueryFirst<Batch>(@"select * from batches
                                                            where Id = @batchId", batchId);

                return getSingleBatch;
            }
        }
        public bool Update(Batch batch)
        {
            using (var db = GetConnection())
            {
                db.Open();
                var result = db.Execute(@"UPDATE [dbo].[Batches]
                                           SET [DateBarrelled] = @DateBarrelled
                                              ,[NumberOfBarrels] = @NumberOfBarrels
                                              ,[DateBottled] = @DateBottled
                                              ,[NumberOfBottles] = @NumberOfBottles
                                              ,[Cooker] = @Cooker
                                              ,[PricePerBottle] = @PricePerBottle
                                              ,[NumberOfBottlesLeft] = @NumberOfBottles
                                              ,[Status] = @Status
                                         WHERE id = @BatchId", batch);
                return result == 1;
            }
        }
        private static SqlConnection GetConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["AmberAndGrain"].ConnectionString);
        }
    }
    // add question mark after type - this type is now a nullable of datetime
    // if type is nullable we want to add ? 
    public class Batch
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateBarrelled { get; set; }
        public int? NumberOfBarrels { get; set; }
        public DateTime DateBottled { get; set; }
        public int NumberOfBottles { get; set; }
        public string Cooker { get; set; }
        public double? PricePerBottle { get; set; }
        public int? NumberOfBottlesLeft { get; set; }
        public BatchStatus Status { get; set; }
    }
}
