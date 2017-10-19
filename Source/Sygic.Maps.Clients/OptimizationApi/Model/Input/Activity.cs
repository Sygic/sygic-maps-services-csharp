using System;

namespace Sygic.Maps.Clients.OptimizationApi.Model.Input
{
    public class Activity
    {
        public enum ActivityTypeEnum
        {
            Pickup,
            Delivery,
            Visit
        }

        /// <summary>
        /// Activity to be performed.<br/>
        /// Values: pickup|delivery|visit<br/>
        /// Default: visit
        /// </summary>
        public ActivityTypeEnum ActivityType { get; set; } = ActivityTypeEnum.Visit;

        public string LocationId { get; set; }

        /// <summary>
        /// Service time.<br/>
        /// Format: hh:mm:ss (or d.hh:mm:ss if greater than 24 hours)
        /// </summary>
        public TimeSpan? ServiceTime { get; set; }
    }
}
