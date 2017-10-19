using System;

namespace Sygic.Maps.Clients.OptimizationApi.Model.Output
{
    public class VehicleStatistics
    {
        public uint? TravelDistance { get; set; }
        public TimeSpan? TravelDuration { get; set; }
        public TimeSpan? ServiceDuration { get; set; }
        public TimeSpan WaitDuration { get; set; }
        public TimeSpan? TotalDuration { get; set; }

        public uint? ServedTasks { get; set; }
    }
}
