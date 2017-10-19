using System;

namespace Sygic.Maps.Clients.OptimizationApi.Model.Output
{
    public class VehicleActivity
    {
        public int Sequence { get; set; }
        public DateTime Timestamp { get; set; }
        public string LocationId { get; set; }
        public double TravelDistance { get; set; }
        public TimeSpan TravelDuration { get; set; }
        public TimeSpan ServiceDuration { get; set; }
        public TimeSpan WaitDuration { get; set; }
    }
}
