using System.Collections.Generic;

namespace Sygic.Maps.Clients.OptimizationApi.Model.Output
{
    public class PlanItem
    {
        public string VehicleId { get; set; }
        public List<VehicleActivity> Activities { get; set; }
        public VehicleStatistics Statistics { get; set; }
    }
}
