using System;

namespace Sygic.Maps.Clients.OptimizationApi.Model.Output
{
    public class OverallStatistics
    {
        public uint? TravelDistance { get; set; }

        public TimeSpan? TravelDuration { get; set; }

        public TimeSpan? ServiceDuration { get; set; }

        public TimeSpan WaitDuration { get; set; }

        public TimeSpan? TotalDuration { get; set; }

        public uint? ServedTasks { get; set; }
        public uint? DroppedTasks { get; set; }
        public uint? TotalTasks { get; set; }

        public uint? UsedVehicles { get; set; }
        public uint? TotalVehicles { get; set; }
    }
}
