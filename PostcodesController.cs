using RestSharp;
using Newtonsoft.Json;

namespace BusBoard
{
    public partial class PostCodeController
    {
        public PostCodeController()
        {
            var options = new RestClientOptions("https://api.postcodes.io/postcodes") {
            };
            client = new RestClient(options);
        }
        
        private readonly RestClient client;

        public async Task<Location> getLocation(string PostCode) {
            var request = new RestRequest(PostCode);
            var response = await client.GetAsync(request);
            return JsonConvert.DeserializeObject<LocationReturn>(response.Content).Result;
        }
    }
}