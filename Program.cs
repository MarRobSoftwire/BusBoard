using BusBoard;

using RestSharp;

class App
{
    static async Task Main()
    {
        BusStopController controller = new BusStopController();
        List<Bus> nextBusses = await controller.getNextBusses("490008660N");
        foreach( Bus bus in nextBusses )
        {
            Console.WriteLine(bus.LineName + ", " + bus.DestinationName + ", " + (int)Math.Ceiling( (double)bus.TimeToStation / (double)60));
        }
    }
}