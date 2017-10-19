using System.Collections.Generic;

namespace Sygic.Maps.Clients.OptimizationApi.Model.Input
{
    public class OptimizationInput
    {
        /// <summary>
        /// Available locations.
        /// </summary>
        public List<Location> Locations { get; set; }

        /// <summary>
        /// Available vehicles in fleet.
        /// </summary>
        public List<Vehicle> Vehicles { get; set; }

        /// <summary>
        /// Available tasks.
        /// </summary>
        public List<OrderTask> Tasks { get; set; }

        public OptimizationSettings Settings { get; set; }
    }
}