using RestSharp;
using Newtonsoft.Json;

namespace BusBoard
{
    public partial class BusStopController
    {
        public BusStopController()
        {
            var options = new RestClientOptions("https://api.tfl.gov.uk/StopPoint") {
            };
            client = new RestClient(options);
        }
        
        private readonly RestClient client;

        public async Task<List<Bus>> getNextBusses(string StopId)
        {
            var request = new RestRequest(StopId + "/Arrivals");
            var response = await client.GetAsync(request);
            return JsonConvert
                .DeserializeObject<List<Bus>>(response.Content)
                .OrderBy((bus) => bus.TimeToStation)
                .Take(5)
                .ToList();
        }

        public async Task<List<BusStop>> getNearestBusStops(Location location) 
        {
            var request = new RestRequest($"?lat={location.Latitude}&lon={location.Longitude}&stopTypes=NaptanPublicBusCoachTram");
            var response = await client.GetAsync(request);
            return JsonConvert
                .DeserializeObject<BusStopReturn>(response.Content)
                .StopPoints
                .Take(2)
                .ToList();
        }
    }
}