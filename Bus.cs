namespace BusBoard
{
    public class Bus
    {
        public string LineName { get; set; }
        public string DestinationName { get; set; }
        public int TimeToStation { get; set; }
        
        public string Output() {
            return this.LineName + ", " + 
                this.DestinationName + ", " + 
                (int)Math.Ceiling(this.TimeToStation / (double)60);
        }
    }
}