using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Basta.PropertyManagementSystemDemo.Entities;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;

namespace Basta.PropertyManagementSystemDemo
{

    public static partial class GetHotels
    {
        [FunctionName("GetHotels")]
        public static async Task<List<Hotel>> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]HttpRequestMessage req, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

            // parse query parameter
            string name = req.GetQueryNameValuePairs()
                .FirstOrDefault(q => string.Compare(q.Key, "name", true) == 0)
                .Value;

            if (name == null)
            {
                // Get request body
                dynamic data = await req.Content.ReadAsAsync<object>();
                name = data?.name;
            }

            var hotel1 = new Hotel { Id = 1, Name = "Marriott Frankfurt" };
            var hotel2 = new Hotel { Id = 2, Name = "Novotel Frankfurt" };

            var hotels = new List<Hotel> { hotel1, hotel2 };

            return hotels;

            //var roomViewModel = new List<RoomViewModel>
            //{
            //    new RoomViewModel(1, 1, "Marriott Frankfurt-1.01"),
            //    new RoomViewModel(1, 1, "Marriott Frankfurt-1.02"),
            //};


            //return name == null
            //    ? req.CreateResponse(HttpStatusCode.BadRequest, "Please pass a name on the query string or in the request body")
            //    : req.CreateResponse(HttpStatusCode.OK, hotels);
        }
    }
}
