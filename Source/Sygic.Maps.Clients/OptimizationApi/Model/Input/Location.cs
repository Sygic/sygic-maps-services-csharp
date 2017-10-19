namespace Sygic.Maps.Clients.OptimizationApi.Model.Input
{
    public class Location
    {
        public string LocationId { get; set; }
        public Coordinates Coordinates { get; set; }
        public Availability Availability { get; set; }
    }
}