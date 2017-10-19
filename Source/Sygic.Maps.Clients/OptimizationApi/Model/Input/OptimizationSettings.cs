using System;

namespace Sygic.Maps.Clients.OptimizationApi.Model.Input
{
    public class OptimizationSettings
    {
        /// <summary>
        /// Defines routing mode of vehicles.<br/>
        /// Values: shortest|fastest|aerial<br/>
        /// Default: fastest
        /// </summary>
        public RoutingModeEnum RoutingMode { get; set; } = RoutingModeEnum.Fastest;

        /// <summary>
        /// Limits maximum waiting time for all vehicles.<br/>
        /// Format: hh:mm:ss (or d.hh:mm:ss if greater than 24 hours)
        /// Default: &lt;no limit&gt;
        /// </summary>
        public TimeSpan? MaxWaitTime { get; set; }

        /// <summary>
        /// Solutions to identical requests are being cached by default, gives the ability to turn off the caching behavior and force recomputation.
        /// </summary>
        public bool ForceRecompute { get; set; }
    }
}
