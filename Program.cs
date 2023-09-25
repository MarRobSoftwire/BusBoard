using BusBoard;

class App
{
    static async Task Main()
    {
        BusStopController busController = new();
        PostCodeController postCodeController = new();
        Location location = await postCodeController.getLocation("NW5 1TL");
        List<BusStop> busStops = await busController.getNearestBusStops(location);
        foreach (BusStop stop in busStops)
        {
            List<Bus> nextBusses = await busController.getNextBusses(stop.NaptanId);
            Console.WriteLine("Next arrivals at: " + stop.NaptanId);
                foreach( Bus bus in nextBusses )
                    {
                        Console.WriteLine(bus.LineName + ", " + bus.DestinationName + ", " + (int)Math.Ceiling( (double)bus.TimeToStation / (double)60));
                    }
        }
    }
}