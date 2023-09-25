using BusBoard;

class App
{
    static async Task Main()
    {
        var busController = new BusStopClient();
        var postCodeController = new PostCodeClient();
        Location location = postCodeController.getLocation("NW5 1TL");
        List<BusStop> busStops = await busController.getNearestBusStops(location);
        foreach (BusStop stop in busStops)
        {
            List<Bus> nextBusses = await busController.getNextBusses(stop.NaptanId);
            Console.WriteLine("Next arrivals at: " + stop.NaptanId);
            foreach(Bus bus in nextBusses )
            {
                Console.WriteLine(bus.Output());
            }
        }
    }
}