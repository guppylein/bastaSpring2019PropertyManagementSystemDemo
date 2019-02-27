using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Basta.PropertyManagementSystemDemo.Entities;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;

namespace Basta.PropertyManagementSystemDemo
{
    public static partial class GetHotelsFunction
    {
        [FunctionName("GetHotels")]
        public static async Task<List<Hotel>> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]HttpRequestMessage req, TraceWriter log)
        {
            log.Info("Retrieving hotels.");

            var hotels = GetHotels().ToList();

            return hotels;
        }

        private static IEnumerable<Hotel> GetHotels()
        {
            var connectionString = ConfigurationManager
                .ConnectionStrings["pmsData"].ConnectionString;

            using (var sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                var cmd = sqlConnection.CreateCommand();
                cmd.CommandText = "SELECT * FROM Hotels";
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return new Hotel((int)reader["id"], (string)reader["name"]);
                    }
                }
            }
        }
    }
}
