using System;

namespace Sygic.Maps.Clients.OptimizationApi.Model.Input
{
    public class Availability
    {
        /// <summary>
        /// Time window start.
        /// </summary>
        public DateTime? EarliestStart { get; set; }

        /// <summary>
        /// Time window end.
        /// </summary>
        public DateTime? LatestEnd { get; set; }
    }
}