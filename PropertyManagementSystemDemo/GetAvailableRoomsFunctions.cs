using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Basta.PropertyManagementSystemDemo.Entities;
using Basta.PropertyManagementSystemDemo.ViewModels;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;

namespace Basta.PropertyManagementSystemDemo
{
    public static class GetAvailableRoomsFunctions
    {
        [FunctionName("GetAvailableRooms")]
        public static async Task<List<RoomViewModel>> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "GetAvailableRooms/{from}/{to}/{capacity}")]HttpRequestMessage req, TraceWriter log,
            string from, string to, int capacity)
        {
            log.Info("Checking available rooms");

            var availableRooms = GetAvailableRooms(DateTime.Parse(from), DateTime.Parse(to), capacity).ToList();

            log.Info("Available rooms: " + availableRooms.Count);

            return availableRooms;
        }

        private static IEnumerable<RoomViewModel> GetAvailableRooms(DateTime from, DateTime to, int capacity)
        {
            //var connectionString = ConfigurationManager
            //    .ConnectionStrings["pmsData"].ConnectionString;
            var connectionString = Environment.GetEnvironmentVariable("ConnectionStrings:pmsData");

            using (var sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                var cmd = sqlConnection.CreateCommand();
                cmd.CommandText = @"SELECT r.Id, r.HotelId, r.Number, h.Name, rt.Capacity
FROM Hotels h 
  INNER JOIN Rooms r ON h.Id = r.HotelId
  INNER JOIN RoomTypes rt ON r.RoomtypeId = rt.Id
  LEFT OUTER JOIN Reservations rv ON rv.RoomId = r.Id
WHERE r.State = 0 
  AND rv.DateFrom >= @from AND rv.DateTo <= @to
  AND rt.Capacity = @capacity";
                cmd.Parameters.AddWithValue("from", from);
                cmd.Parameters.AddWithValue("to", to);
                cmd.Parameters.AddWithValue("capacity", capacity);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return new RoomViewModel((int)reader["Id"], (int)reader["HotelId"], (string)reader["Name"] + " " + (string)reader["Number"], (int)reader["Capacity"]);
                    }
                }
            }
        }
    }
}
