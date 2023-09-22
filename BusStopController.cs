using RestSharp;
using Newtonsoft.Json;

namespace BusBoard
{
    public class BusStopController
    {
        public BusStopController()
        {
            var options = new RestClientOptions("https://api.tfl.gov.uk/StopPoint") {
            };
            client = new RestClient(options);
        }
        
        private readonly RestClient client;

        public async Task<List<Bus>> getNextBusses(string StopId) {
            var request = new RestRequest(StopId + "/Arrivals");
            var response = await client.GetAsync(request);
            return JsonConvert
                .DeserializeObject<List<Bus>>(response.Content)
                .OrderBy((bus) => bus.TimeToStation)
                .Take(5)
                .ToList()
                .Select(bus => );
        }
    }
}