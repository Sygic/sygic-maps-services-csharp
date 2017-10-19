namespace Sygic.Maps.Clients.OptimizationApi.Model.Input
{
    public class OrderTask
    {
        /// <summary>
        /// Task identifier.
        /// </summary>
        public string TaskId { get; set; }

        /// <summary>
        /// Task priority.
        /// </summary>
        public OrderTaskPriorityEnum? Priority { get; set; }

        /// <summary>
        /// Consumed/released vehicle capacity.
        /// </summary>
        public int[] Capacity { get; set; }

        /// <summary>
        /// Activities to be performed:<br/>
        /// Pickup + Delivery<br/>
        /// Visit
        /// </summary>
        public Activity[] Activities { get; set; }
    }
}