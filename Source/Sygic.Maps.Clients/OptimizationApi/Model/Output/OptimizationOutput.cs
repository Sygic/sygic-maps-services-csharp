using System.Collections.Generic;
using Sygic.Maps.Clients.OptimizationApi.Model.Input;

namespace Sygic.Maps.Clients.OptimizationApi.Model.Output
{
    public class OptimizationOutput
    {
        public List<Location> Locations { get; set; }
        public List<PlanItem> Plan { get; set; }
        public OverallStatistics Statistics { get; set; }
        public string Status { get; set; }
        public OptimizationStateEnum State { get; set; }
        public ResponseError Error { get; set; }
    }
}
